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

        public void Yes()
        {
            ConsoleExplorer cosPlo = new ConsoleExplorer();
            cosPlo.Key();       
        
        }
        //----------------------------------------------- 
        public void PrintList()
        {
            Console.Clear();
            Console.WriteLine();
            for (int i = 0; i < _in.Length; i++)
            {
                if (_pos == i)
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    if (File.Exists(_in[i]))
                    {
                        Console.WriteLine($"- {Path.GetFileName(_in[i])}");
                        Dir = "";
                    }
                    if (Directory.Exists(_in[i]))
                    {
                        Dir = Path.GetFileName(_in[i]);
                        Console.WriteLine($"# {Dir}");
                    }
                    Console.ResetColor();
                }
                else
                {
                    if (File.Exists(_in[i]))
                        Console.WriteLine($"- {Path.GetFileName(_in[i])}");
                    if (Directory.Exists(_in[i]))
                        Console.WriteLine($"# {Path.GetFileName(_in[i])}");
                }

            }
            
            Console.WriteLine();
            Console.WriteLine("\nArray Position: ");
            Console.WriteLine(_pos);
            Console.WriteLine("\nCurrent Directory: ");
            Console.WriteLine(_currentView);
            Console.WriteLine("\nParent Directory: ");
            Console.WriteLine(ParentFolderPath);
            Console.WriteLine("\nSelected Directory: ");
            Console.WriteLine("\nPress Y to create textfile");
            Console.WriteLine("");            
            Console.WriteLine(Dir);
        }

    
    }
}
