using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFileExplorer
{
    class FolderView
    {
        public string Dir { get; private set; }
        private int _pos;
        private string _currentView;
        private string[] _in;
       // ------------------------------------------------
        public string ParentFolderPath
        { get { return Convert.ToString(Directory.GetParent(_currentView)); } }
        public string CurrentFileName
        { get { return Path.GetFullPath(_in[_pos]); } }
        public FolderView(string path)
        {
            _currentView = path;
            _in = Directory.GetFileSystemEntries(path);
        }
        //-----------------------------------------------
        public void Up()
        { if (_pos <= _in.Length - 1) _pos++; }
        public void Down()
        { if (_pos > 0) _pos--; }
        public string Forward(string oldPath)
        { return oldPath + Path.DirectorySeparatorChar + Dir; }
        public string Back()
        { return ParentFolderPath; }
        //-----------------------------------------------

        public void PrintList()
        {
            Console.Clear();
            Console.WriteLine();
            for (int i = 0; i < _entries.Length; i++)
            {
                if (_position == i)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (File.Exists(_entries[i]))
                    {
                        Console.WriteLine($"- {Path.GetFileName(_entries[i])}");
                        SelectedDir = "";
                    }
                    if (Directory.Exists(_entries[i]))
                    {
                        SelectedDir = Path.GetFileName(_entries[i]);
                        Console.WriteLine($"# {SelectedDir}");
                    }
                    Console.ResetColor();
                }
                else
                {
                    if (File.Exists(_entries[i]))
                        Console.WriteLine($"- {Path.GetFileName(_entries[i])}");
                    if (Directory.Exists(_entries[i]))
                        Console.WriteLine($"# {Path.GetFileName(_entries[i])}");
                }

            }
            Console.WriteLine();
            Console.WriteLine("\nArray Position: ");
            Console.WriteLine(_position);
            Console.WriteLine("\nCurrent Directory: ");
            Console.WriteLine(_currentView);
            Console.WriteLine("\nParent Directory: ");
            Console.WriteLine(ParentFolderPath);
            Console.WriteLine("\nSelected Directory: ");
            Console.WriteLine(SelectedDir);
        }

    
    }
}
