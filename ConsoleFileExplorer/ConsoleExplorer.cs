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


        public void ShowFolder()
        {
            string path = Path.GetFullPath(".");
            FolderView _folderView = new FolderView(path);
            ViewState _viewstate = ViewState.List;

            if (_viewstate == ViewState.List)
            {
                while (!false)
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
                    else if (input == ConsoleKey.C)
                    {
                        _folderView.Create();
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

        }

        private void FileContent(FolderView _folderView)
        {            
            ViewState _viewstate = ViewState.List;
            string breakLine = new string('-', 30);
            if (_viewstate == ViewState.FileView)
            {
                Console.Clear();
               // Console.WriteLine($"{_folderView.SelectedFile}\n{breakLine}");
                for (; ; )
                {
                    var path = Path.GetFullPath(".");
                    using var reader = new StreamReader(_folderView.CurrentFileName, Encoding.UTF8);
                    {
                        string line = "";
                        while ((line = reader.ReadLine()) != null)
                        { Console.WriteLine(line); }
                    }
                    Console.WriteLine("\nPress random button and return to Folder View 2000.");
                    Console.ReadKey(); 
                    break;                                    
                }
                _viewstate = ViewState.List;
                return;
            }
        }
        public void Run()
        {
            for (; ; )
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

