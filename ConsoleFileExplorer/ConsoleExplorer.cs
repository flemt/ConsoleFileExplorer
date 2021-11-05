using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ConsoleFileExplorer
{
    class ConsoleExplorer
    {

        //    █████▒▒█████   ██▓    ▓█████▄ ▓█████  ██▀███    ██████ ▄▄▄█████▓ █    ██   █████▒ █████▒
        //  ▓██   ▒▒██▒  ██▒▓██▒    ▒██▀ ██▌▓█   ▀ ▓██ ▒ ██▒▒██    ▒ ▓  ██▒ ▓▒ ██  ▓██▒▓██   ▒▓██   ▒ 
        //  ▒████ ░▒██░  ██▒▒██░    ░██   █▌▒███   ▓██ ░▄█ ▒░ ▓██▄   ▒ ▓██░ ▒░▓██  ▒██░▒████ ░▒████ ░ 
        //  ░▓█▒  ░▒██   ██░▒██░    ░▓█▄   ▌▒▓█  ▄ ▒██▀▀█▄    ▒   ██▒░ ▓██▓ ░ ▓▓█  ░██░░▓█▒  ░░▓█▒  ░ 
        //  ░▒█░   ░ ████▓▒░░██████▒░▒████▓ ░▒████▒░██▓ ▒██▒▒██████▒▒  ▒██▒ ░ ▒▒█████▓ ░▒█░   ░▒█░    
        //   ▒ ░   ░ ▒░▒░▒░ ░ ▒░▓  ░ ▒▒▓  ▒ ░░ ▒░ ░░ ▒▓ ░▒▓░▒ ▒▓▒ ▒ ░  ▒ ░░   ░▒▓▒ ▒ ▒  ▒ ░    ▒ ░    
        //   ░       ░ ▒ ▒░ ░ ░ ▒  ░ ░ ▒  ▒  ░ ░  ░  ░▒ ░ ▒░░ ░▒  ░ ░    ░    ░░▒░ ░ ░  ░      ░      
        //   ░ ░   ░ ░ ░ ▒    ░ ░    ░ ░  ░    ░     ░░   ░ ░  ░  ░    ░       ░░░ ░ ░  ░ ░    ░ ░    
        //             ░ ░      ░  ░   ░       ░  ░   ░           ░              ░                    
        //                           ░                                                                

        private void ShowFolder()
        {
            string path = Path.GetFullPath(".");
            FolderView _folderView = new FolderView(path);
            while (!false)
            {   _folderView.PrintList();
                ConsoleKey input = Console.ReadKey().Key;
                if (input == ConsoleKey.DownArrow)
                {_folderView.Up();}

                else if (input == ConsoleKey.UpArrow)
                {_folderView.Down();}

                else if (input == ConsoleKey.Spacebar)
                {if (File.Exists(_folderView.CurrentFileName)){
                ShowFileContent(_folderView);break;}
                else {break;}}

                else if (input == ConsoleKey.Enter)
                {if (Directory.Exists(_folderView.Dir)) 
                {path = _folderView.Forward(path); 
                break;}else {break;} }

                else if (input == ConsoleKey.Backspace)
                {path = _folderView.Back();break;}

                else if (input == ConsoleKey.C)
                {_folderView.Create();break;}

                else if (input == ConsoleKey.D)
                {   if (File.Exists(_folderView.CurrentFileName)) 
                    { _folderView.DeleteFile();break; }
                    else  {break;} } else { continue;
                }
            }
        }

            

             private void ShowFileContent(FolderView _folderView)
             {
                ViewState _viewstate = ViewState.FileView;
                string breakLine = new string('-', 30);
                if (_viewstate == ViewState.FileView)
                {   Console.Clear();
                    Console.WriteLine($"{_folderView.SelectedFile}\n{breakLine}");
                    while (!false)
                    {
                        using (StreamReader sr = new StreamReader(_folderView.CurrentFileName))
                        {    string line = "";
                            while ((line = sr.ReadLine()) != null)
                            {Console.WriteLine(line);}
                        }
                        Console.WriteLine("\nPress any key to return to Folder View...");
                        Console.ReadKey();
                        break;
                    }
                    _viewstate = ViewState.List;
                    return;
                }
             }
                 public void Run()
                {
                    while (!false)
                    {
                        ViewState _viewstate = ViewState.List;
                        if (_viewstate == ViewState.List)
                        {
                            ShowFolder();
                        }
                    }
                }
            
        
    }
}

