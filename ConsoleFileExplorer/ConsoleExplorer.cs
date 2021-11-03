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
                        
                       
                        if (ki.Key == ConsoleKey.DownArrow)
                        {
                            _folderView.Up();
                        }
                        else if (ki.Key == ConsoleKey.UpArrow)
                        {
                            _folderView.Down();
                        }
                        else if (ki.Key == ConsoleKey.Spacebar)
                        {
                            _viewstate = ViewState.FileView;
                            break;
                        }
                        else if (ki.Key == ConsoleKey.Enter)
                        {
                            path = _folderView.Forward(path);
                            break;
                        }
                        else if (ki.Key == ConsoleKey.Backspace)
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
    }
}

