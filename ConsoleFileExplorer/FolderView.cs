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

     private int _pos;

     private string _currentView;

     private string[] _in;

     public string ParentFolderPath { get { return Convert.ToString(Directory.GetParent(_currentView)); } }
     public string CurrentFileName { get { return Path.GetFullPath(_in[_pos]); } }
     public FolderView(string path) {_currentView = path; _in = Directory.GetFileSystemEntries(path); }

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
            for(; ;)
            {
                var path = "@demofile1.txt";
                 Console.Clear();
                  Console.WriteLine("You have chosen to create a file\n");
                   Console.Write("Enter name of the file: ");
                    var uInput = Console.ReadLine();
                     var uFile = $"{uInput}.txt";
                      Thread.Sleep(2000);
                       var exists = File.Exists(path);

                         if (exists == true)
                          {
                            Console.WriteLine(exists);
                             Console.WriteLine("Already a file with that name \n" +
                              "Deleting file\n");                                                      
                                Thread.Sleep(2000);
                                 Console.WriteLine("Deleting file..");
                                   try { 
                                    File.Delete(path); Console.WriteLine("File deleted");}
                                      catch (IOException ex)
                                       {Console.WriteLine(ex.Message);}

                                         finally
                                          {FileInfo fi = new FileInfo(path);
                                            using (FileStream fs = fi.Create()){
                                             Byte[] info = new UTF8Encoding(true).GetBytes("This is your fresh of the\n" +
                                              "bandwagon file of text");
                                                fs.Write(info, 0, info.Length);
                                                 fs.Close();
                                                  Console.WriteLine("File created");
                                                                                       }

                                                                                          }
                    
                                                                                             }
                                                                                               break;
                                                                                                      }
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

             Console.WriteLine            ();
               Console.WriteLine          ("\nArray Position: ");
                 Console.WriteLine        (_pos);
                   Console.WriteLine      ("\nCurrent Folder: ");
                     Console.WriteLine    (_currentView);
                       Console.WriteLine  ("\nParent Folder: ");
                       Console.WriteLine  (ParentFolderPath);
                      Console.WriteLine   ("\nSelected Folder: ");
                     Console.WriteLine    ("\nPress c to create file");
                    Console.WriteLine     ("");
                   Console.WriteLine      (Dir);
                  Console.Clear           ();
                 Console.WriteLine        ();

            for (var x = 0; x < _in.Length; x++)
            {
                if (_pos == x)
                {
                    Console.BackgroundColor = ConsoleColor.Magenta;
                      Console.ForegroundColor = ConsoleColor.DarkBlue;

                    if (File.Exists(_in[x]))
                    {   Console.WriteLine($"- {Path.GetFileName(_in[x])}");
                        Dir = ""; }

                    if (Directory.Exists(_in[x]))
                    {   Dir = Path.GetFileName(_in[x]);
                        Console.WriteLine($"# {Dir}"); }
                        Console.ResetColor();
                }
                else
                {  if (File.Exists(_in[x])) Console.WriteLine($"- {Path.GetFileName(_in[x])}");
                    if (Directory.Exists(_in[x])) Console.WriteLine($"# {Path.GetFileName(_in[x])}");
                }

            }
            
         
        }

    
    }
}
