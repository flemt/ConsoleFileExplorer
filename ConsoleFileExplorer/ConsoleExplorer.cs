using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFileExplorer
{
    class ConsoleExplorer
    {
        public ConsoleKey ReadKey { get; private set; }

        public void Run()
        {
            string path = Path.GetFullPath(".");
            ViewState _viewstate = ViewState.List;
            var ki = Console.ReadKey();

            while (true)
            {
                FolderView _folderView = new FolderView(path);

                if (_viewstate == ViewState.List)
                {
                    while (true)
                    {
                        _folderView.PrintList();

                        ConsoleKey input = Console.ReadKey().Key;
                        if (input == ConsoleKey.DownArrow)
                        {
                            _folderView.Up();
                        }
                        else if (input == ConsoleKey.UpArrow)
                        {
                            _folderView.Down();
                        }
                        else if (input == ConsoleKey.Spacebar)
                        {
                            _viewstate = ViewState.FileView;
                            break;
                        }
                        else if (input == ConsoleKey.Enter)
                        {
                            path = _folderView.Forward(path);
                            break;
                        }  
                        else if (input == ConsoleKey.Y)
                        {
                             _folderView.Yes(path);
                            break;
                        }
                        else if (input == ConsoleKey.Backspace)
                        {
                            path = _folderView.Back();
                            break;
                        }
                        else
                            continue;
                    }
                }

                if (_viewstate == ViewState.FileView)
                {
                    Console.Clear();
                    while (true)
                    {
                        using (StreamReader sr = new StreamReader(_folderView.CurrentFileName))
                        {
                            string line = "";
                            while ((line = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                            }
                        }
                        Console.WriteLine("\nPress any key to return to Folder View...");
                        Console.ReadKey();
                        break;
                    }
                    _viewstate = ViewState.List;
                }
            }
        }


        public void Key()
        {
            while (true)
            {

                var path = "@demofile1.txt";
                var yes = Console.ReadKey().Key == ConsoleKey.Y;                           
                var exists = File.Exists(path);
                FileInfo fi = new FileInfo(path);
                if (exists == true)             
                {
                    Console.WriteLine(exists);
                    Console.WriteLine("Already a file with that namen \n" +
                        "Do u want to delete the file?\n" +
                        "Y/N");
                    string userInput;
                    userInput = Console.ReadLine();
                                      
                    if (yes)
                    {
                        Console.WriteLine("Deleting file..");
                        try
                        {
                            File.Delete(path);
                            Console.WriteLine("File deleted");  
                        }
                        catch (IOException ex)
                        { Console.WriteLine(ex.Message); }

                        finally
                        {
                            using (FileStream fs = fi.Create())
                            {
                                Byte[] info =
                                  new UTF8Encoding(true).GetBytes("text in the file.");
                                fs.Write(info, 0, info.Length);
                                fs.Close();
                                Console.WriteLine("File created");
                            }

                        }
                    }

                    

                } break;
            } 
        }





    }
}

