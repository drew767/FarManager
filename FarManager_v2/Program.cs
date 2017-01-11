using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarManager_v2;

namespace FarManager_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowPosition(0, 0);
            Draw d = new Draw();

            FileList[] f = new FileList[2];
            f[0] = new FileList();
            f[1] = new FileList();
            d.FolderInfo(f);
            d.Files(f, false, false);

            bool side = true;
            int main_directory = 0;

            d.Files(f, side, true);
            d.FileInfo(f[main_directory], true);

            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.DownArrow:
                        {
                            f[main_directory].plusPos();
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            f[main_directory].minusPos();
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            f[main_directory].goLeftPos();
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            f[main_directory].goRightPos();
                            break;
                        }
                    case ConsoleKey.Tab:
                        {
                            if (main_directory == 0)
                            {
                                main_directory = 1;
                            }
                            else
                            {
                                main_directory = 0;
                            }
                            d.Files(f, side, false);
                            side = !side;
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            f[main_directory].GoTo();
                            d = new Draw();
                            d.FolderInfo(f);
                            d.Files(f, !side, false);
                            break;
                        }
                }
                d.Files(f, side, true);
            }
        }
    }
}
