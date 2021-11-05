using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleFileExplorer


//  ██████╗ ██████╗  ██████╗ ██████╗ ███████╗██████╗ ████████╗██╗███████╗███████╗
//  ██╔══██╗██╔══██╗██╔═══██╗██╔══██╗██╔════╝██╔══██╗╚══██╔══╝██║██╔════╝██╔════╝
//  ██████╔╝██████╔╝██║   ██║██████╔╝█████╗  ██████╔╝   ██║   ██║█████╗  ███████╗
//  ██╔═══╝ ██╔══██╗██║   ██║██╔═══╝ ██╔══╝  ██╔══██╗   ██║   ██║██╔══╝  ╚════██║
//  ██║     ██║  ██║╚██████╔╝██║     ███████╗██║  ██║   ██║   ██║███████╗███████║
//  ╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚═╝╚══════╝╚══════╝
//                                                                               

{
    class FolderView
    {
        private string _File { get; set; }
        public string Dir { get; private set; }
        public string SelectedDir { get; private set; }

        private int _pos;

        private string _currentView;

        private string[] _in;
        public string SelectedFile { get; private set; }

        string path = Path.GetFullPath(".");
        public string ParentFolderPath { get { return Convert.ToString(Directory.GetParent(_currentView)); } }
        public string CurrentFileName { get { return Path.GetFullPath(_in[_pos]); } }
        public FolderView(string path) { _currentView = path; _in = Directory.GetFileSystemEntries(path); }

        ///
        //  ██████╗ ██╗██████╗ ███████╗ ██████╗████████╗██╗ ██████╗ ███╗   ██╗███████╗   ██╗  ██╗███████╗██╗   ██╗
        //  ██╔══██╗██║██╔══██╗██╔════╝██╔════╝╚══██╔══╝██║██╔═══██╗████╗  ██║██╔════╝   ██║ ██╔╝██╔════╝╚██╗ ██╔╝
        //  ██║  ██║██║██████╔╝█████╗  ██║        ██║   ██║██║   ██║██╔██╗ ██║███████╗   █████╔╝ █████╗   ╚████╔╝ 
        //  ██║  ██║██║██╔══██╗██╔══╝  ██║        ██║   ██║██║   ██║██║╚██╗██║╚════██║   ██╔═██╗ ██╔══╝    ╚██╔╝  
        //  ██████╔╝██║██║  ██║███████╗╚██████╗   ██║   ██║╚██████╔╝██║ ╚████║███████║██╗██║  ██╗███████╗   ██║   
        //  ╚═════╝ ╚═╝╚═╝  ╚═╝╚══════╝ ╚═════╝   ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝╚═╝╚═╝  ╚═╝╚══════╝   ╚═╝   
        //                                                                                                        
        public void Up() { if (_pos <= _in.Length - 1) _pos++; }
        public void Down() { if (_pos > 0) _pos--; }
        public string Forward(string olD)
        { return olD + Path.DirectorySeparatorChar + Dir; }
        public string Back() { return ParentFolderPath; }


        //   ██████╗██████╗ ███████╗ █████╗ ████████╗███████╗   ███████╗██╗██╗     ███████╗
        //  ██╔════╝██╔══██╗██╔════╝██╔══██╗╚══██╔══╝██╔════╝   ██╔════╝██║██║     ██╔════╝
        //  ██║     ██████╔╝█████╗  ███████║   ██║   █████╗     █████╗  ██║██║     █████╗  
        //  ██║     ██╔══██╗██╔══╝  ██╔══██║   ██║   ██╔══╝     ██╔══╝  ██║██║     ██╔══╝  
        //  ╚██████╗██║  ██║███████╗██║  ██║   ██║   ███████╗██╗██║     ██║███████╗███████╗
        //   ╚═════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝   ╚═╝   ╚══════╝╚═╝╚═╝     ╚═╝╚══════╝╚══════╝
        //                                                                                 


        //   ██╗ █████╗ ███╗   ██╗██████╗     ██████╗ ███████╗███╗   ███╗ ██████╗ ██╗   ██╗███████╗██╗ 
        //  ██╔╝██╔══██╗████╗  ██║██╔══██╗    ██╔══██╗██╔════╝████╗ ████║██╔═══██╗██║   ██║██╔════╝╚██╗
        //  ██║ ███████║██╔██╗ ██║██║  ██║    ██████╔╝█████╗  ██╔████╔██║██║   ██║██║   ██║█████╗   ██║
        //  ██║ ██╔══██║██║╚██╗██║██║  ██║    ██╔══██╗██╔══╝  ██║╚██╔╝██║██║   ██║╚██╗ ██╔╝██╔══╝   ██║
        //  ╚██╗██║  ██║██║ ╚████║██████╔╝    ██║  ██║███████╗██║ ╚═╝ ██║╚██████╔╝ ╚████╔╝ ███████╗██╔╝
        //   ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═════╝     ╚═╝  ╚═╝╚══════╝╚═╝     ╚═╝ ╚═════╝   ╚═══╝  ╚══════╝╚═╝ 
        //                                                                                             

        public void Create()
        {
            while (!false)
            {
                 Console.Clear();
                  string path = Path.GetFullPath(".");
                   FolderView _folderView = new FolderView(path);
                    Console.WriteLine("You have chosen to create a file\n");
                     Console.WriteLine("Please write down your most frequently used password here: ");
                      var uInput = Console.ReadLine();
                       var uFile = $"{uInput}";
                        Thread.Sleep(1000);
                         Console.WriteLine($"Creating file..");
                        var text = uFile;
                       var file = new StreamWriter(_folderView.CurrentFileName, false, Encoding.UTF8);
                      file.Write(uFile);
                     Console.WriteLine("File Created!");
                    Thread.Sleep(2000);
                   file.Close();
                  break;
            }

        }
        public void DeleteFile()
        {
            Console.Clear();
            Console.WriteLine($"Remove object?:\n");
            Console.WriteLine($"\"{SelectedFile}\"?\n\nY/N\n");
            ConsoleKey del = Console.ReadKey().Key;
            if (del == ConsoleKey.Y)
            {
                File.Delete(SelectedFile);
            }
            else
            {return; }
        }




        //  ██████╗ ██████╗  █████╗ ██╗    ██╗     ██████╗ ██████╗ ███╗   ██╗███████╗ ██████╗ ██╗     ███████╗
        //  ██╔══██╗██╔══██╗██╔══██╗██║    ██║    ██╔════╝██╔═══██╗████╗  ██║██╔════╝██╔═══██╗██║     ██╔════╝
        //  ██║  ██║██████╔╝███████║██║ █╗ ██║    ██║     ██║   ██║██╔██╗ ██║███████╗██║   ██║██║     █████╗  
        //  ██║  ██║██╔══██╗██╔══██║██║███╗██║    ██║     ██║   ██║██║╚██╗██║╚════██║██║   ██║██║     ██╔══╝  
        //  ██████╔╝██║  ██║██║  ██║╚███╔███╔╝    ╚██████╗╚██████╔╝██║ ╚████║███████║╚██████╔╝███████╗███████╗
        //  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝ ╚══╝╚══╝      ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝ ╚═════╝ ╚══════╝╚══════╝
        //                                                                                                    

        public void PrintList()
        {
            Console.Clear();
            Console.WriteLine();
            for (int i = 0; i < _in.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine("\nPosition in list: ");
                Console.WriteLine(_pos);
                Console.WriteLine("\nFolder: ");
                Console.WriteLine(_currentView);
                Console.WriteLine("\nParent Folder: ");
                Console.WriteLine(ParentFolderPath);
                Console.WriteLine("\nSelected Folder: ");
                Console.WriteLine(Dir);
                Console.WriteLine("\nSelected File: ");
                Console.WriteLine(SelectedFile);
                Console.WriteLine("\nPress c to create a file");
                Console.WriteLine("\nc");

                if (_pos == i)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    if (File.Exists(_in[i]))
                    {   Console.WriteLine($"- {Path.GetFileName(_in[i])}");
                        FileInfo fi = new FileInfo(Path.GetFileName(_in[i]));
                        Dir = "";
                        SelectedFile = fi.Name;}
                    if (Directory.Exists(_in[i]))
                    {   Dir = Path.GetFileName(_in[i]);
                        SelectedFile = "";
                        Console.WriteLine($"# {Dir}");}
                        Console.ResetColor();
                }
                else
                {if (File.Exists(_in[i])) Console.WriteLine($"- {Path.GetFileName(_in[i])}");
                    if (Directory.Exists(_in[i])) Console.WriteLine($"# {Path.GetFileName(_in[i])}");
                }
            }
         
        }



    }
}
