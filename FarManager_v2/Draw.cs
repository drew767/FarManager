using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager_v2
{
    class Draw
    {
        public Draw()
        {
            Console.SetWindowSize(80, 26);
            Console.SetBufferSize(80, 26);

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;

            BackGround();
            Borders();
            FooterButtons();
            ColumnName();
            SystemTime();
        }
        public void BackGround()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 22; i++)
            {
                Console.WriteLine("                                                                               ");
            }
        }
        public void Borders()
        {
            // double line
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("\u2554");
            Console.SetCursorPosition(0, 1);
            for (int i = 0; i < 21; i++)
            {
                Console.WriteLine("\u2551");
            }
            Console.Write("\u255A");
            for (int i = 0; i < 78; i++)
            {
                Console.Write("\u2550");
            }
            Console.Write("\u255D");
            for (int i = 0; i < 22; i++)
            {
                Console.SetCursorPosition(79, i);
                Console.Write("\u2551");
            }
            Console.SetCursorPosition(1, 0);
            for (int i = 0; i < 78; i++)
            {
                Console.Write("\u2550");
            }
            Console.Write("\u2557");

            Console.SetCursorPosition(39, 0);
            Console.WriteLine("\u2557\u2554");
            for (int i = 0; i < 21; i++)
            {
                Console.SetCursorPosition(39, i + 1);
                Console.Write("\u2551\u2551");
            }
            Console.SetCursorPosition(39, 22);
            Console.Write("\u255D\u255A");

            // single line
            Console.SetCursorPosition(0, 20);
            Console.Write("\u255F");
            for (int i = 0; i < 38; i++)
            {
                Console.Write("\u2500");
            }
            Console.Write("\u2562\u255F");
            for (int i = 0; i < 38; i++)
            {
                Console.Write("\u2500");
            }
            Console.Write("\u2562");

            // vertical single line left
            Console.SetCursorPosition(19, 0);
            Console.Write("\u2564");
            for (int i = 0; i < 19; i++)
            {
                Console.SetCursorPosition(19, i + 1);
                Console.Write("\u2502");
            }
            Console.SetCursorPosition(19, 20);
            Console.Write("\u2534");

            // vertical single line right
            Console.SetCursorPosition(59, 0);
            Console.Write("\u2564");
            for (int i = 0; i < 19; i++)
            {
                Console.SetCursorPosition(59, i + 1);
                Console.Write("\u2502");
            }
            Console.SetCursorPosition(59, 20);
            Console.Write("\u2534");
        }
        public void FooterButtons(int pos = -1)
        {
            String str = "";
            Console.SetCursorPosition(0, 24);
            for (int i = 0; i < 10; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(i + 1);
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.Black;

                switch (i)
                {
                    case 0:
                        str = "Help  ";
                        break;
                    case 1:
                        str = "UserMn";
                        break;
                    case 2:
                        str = "View  ";
                        break;
                    case 3:
                        str = "Edit  ";
                        break;
                    case 4:
                        str = "Copy  ";
                        break;
                    case 5:
                        str = "RenMov";
                        break;
                    case 6:
                        str = "MkFold";
                        break;
                    case 7:
                        str = "Delete";
                        break;
                    case 8:
                        str = "ConfMn";
                        break;
                    case 9:
                        str = "Quit  ";
                        break;
                }
                Console.Write("{0}", str);
                if (i < 9)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
            }

        }
        public void ColumnName()
        {
            Console.SetCursorPosition(1, 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("n      Name");
            Console.SetCursorPosition(41, 1);
            Console.WriteLine("n      Name");
            Console.SetCursorPosition(25, 1);
            Console.WriteLine("Name");
            Console.SetCursorPosition(67, 1);
            Console.WriteLine("Name");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public void SystemTime()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(75, 0);
            if (DateTime.Now.Hour < 10)
            {
                Console.Write("0{0}:", DateTime.Now.Hour);
            }
            else
            {
                Console.Write("{0}:", DateTime.Now.Hour);
            }
            if (DateTime.Now.Minute < 10)
            {
                Console.Write("0{0}", DateTime.Now.Minute);
            }
            else
            {
                Console.Write("{0}", DateTime.Now.Minute);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }
        public void Files(FileList[] fi, bool side, bool on_off)
        {
            FileList f = side ? fi[0] : fi[1];
            int left1 = side ? 1 : 41;
            int left2 = side ? 20 : 60;
            var files = f.getFiles();
            var directories = f.getDirs();
            int pos = f.getPos();

            int start1 = 0, start2 = 0, end1 = 0, end2 = 0;

            if (files.Count < 19)
            {
                start1 = 0;
                end1 = Math.Min(18, files.Count);
            }
            else if (files.Count < 37)
            {
                start1 = 0;
                end1 = 18;
                start2 = 18;
                end2 = Math.Min(start2 + 18, files.Count);
            }
            else
            {
                if (pos < files.Count / 2)
                {
                    start1 = Math.Max(pos - 17, 0);
                    end1 = Math.Max(pos, start1 + 18);
                    start2 = start1 + files.Count / 2;
                    end2 = Math.Min(files.Count - 1, start2 + 18);
                }
                else
                {
                    start2 = Math.Max(pos - 17, files.Count / 2);
                    end2 = Math.Max(pos, Math.Min(start2 + 18, files.Count));
                    start1 = start2 - files.Count / 2;
                    end1 = start1 + 18;
                }
            }

            // first part of files in the list
            for (int i = start1, k = 0; i < end1; i++, k++)
            {
                if (files[i].Split('.').Last().Equals("exe"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if ((File.GetAttributes(files[i]) & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    if (f.getPos() == i && on_off)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }
                }
                else if (directories.IndexOf(files[i]) != -1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.SetCursorPosition(left1, 2 + k);

                if (f.getPos() == i && on_off)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }

                if (Path.GetFileName(files[i]).Length < 19)
                {
                    Console.Write("{0}", Path.GetFileName(files[i]));
                    for (int j = 0; j < 18 - Path.GetFileName(files[i]).Length; j++)
                    {
                        Console.Write(" ");
                    }
                }
                else
                {
                    Console.Write("{0}", Path.GetFileName(files[i]).Substring(0, 18));
                }
            }

            // second part of files in the list
            for (int i = start2, k = 0; i < end2; i++, k++)
            {
                if (files[i].Split('.').Last().Equals("exe"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if ((File.GetAttributes(files[i]) & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    if (f.getPos() == i && on_off)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }
                }
                else if (directories.IndexOf(files[i]) != -1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.SetCursorPosition(left2, 2 + k);

                if (f.getPos() == i && on_off)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }

                if (Path.GetFileName(files[i]).Length < 19)
                {
                    Console.Write("{0}", Path.GetFileName(files[i]));
                    for (int j = 0; j < 18 - Path.GetFileName(files[i]).Length; j++)
                    {
                        Console.Write(" ");
                    }
                }
                else
                {
                    Console.Write("{0}", Path.GetFileName(files[i]).Substring(0, 18));
                }
            }
            FileInfo(f, side);
            FolderStatus(fi, side);
        }
        public void FileInfo(FileList f, bool b)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            int top = 21, left;
            int pos = f.getPos();
            var files = f.getFiles();
            var directories = f.getDirs();

            if (b)
            {
                left = 1;
            }
            else
            {
                left = 41;
            }
            Console.SetCursorPosition(left, top);
            Console.WriteLine("                                      ");
            Console.SetCursorPosition(left, top);

            // print last 18 letters of file name
            Console.Write("{0}",
                Path.GetFileName(files[pos]).Substring(
                    Math.Max(0, Path.GetFileName(
                        files[pos]).Length - 14)));
            if (Path.GetFileName(files[pos]).Length < 15)
            {
                for (int l = 0; l < 14 - Path.GetFileName(files[pos]).Length; l++)
                {
                    Console.Write(" ");
                }
            }

            Console.SetCursorPosition(left + 15, top);
            if (files[pos].Equals(".."))
            {
                Console.Write("Up");
            }
            else if (directories.IndexOf(files[pos]) != -1)
            {
                Console.Write("Folder");
            }
            else
            {
                long length = new System.IO.FileInfo(files[pos]).Length;
                string size = "";
                if (length > 99999)
                {
                    length /= 1024;
                    size = " K";
                }
                if (length > 99999)
                {

                    length /= 1024;
                    size = " M";
                    
                }
                if (length > 99999)
                {
                    size = " G";
                    length /= 1024;
                }

                Console.Write("{0}{1}", length, size);
            }
            Console.SetCursorPosition(left + 24, top);

            var t = File.GetLastWriteTime(files[pos]);
            if (t.Day < 10)
            {
                Console.Write("0{0}.", t.Day);
            }
            else
            {
                Console.Write("{0}.", t.Day);
            }
            if (t.Month < 10)
            {
                Console.Write("0{0}.", t.Month);
            }
            else
            {
                Console.Write("{0}.", t.Month);
            }
            Console.Write("{0} ", t.Year.ToString().Substring(2));
            if (t.Hour < 10)
            {
                Console.Write("0{0}:", t.Hour);
            }
            else
            {
                Console.Write("{0}:", t.Hour);
            }
            if (t.Minute < 10)
            {
                Console.Write("0{0}", t.Minute);
            }
            else
            {
                Console.Write("{0}", t.Minute);
            }
        }
        public void FolderInfo(FileList[] f)
        {
            // folder info left
            string dir = f[0].getRoot();
            int top = 22, left = 1;

            long length = 0;
            var files = new DirectoryInfo(dir).GetFiles().ToList();
            for (int i = 0; i < files.Count; i++)
            {
                length += files[i].Length;
            }
            string str = "";
            if (length > 99999)
            {
                length /= 1024;
                str = " K";
                if (length > 9999)
                {
                    length /= 1024;
                    str = " M";
                    if (length > 9999)
                    {
                        length /= 1024;
                        str = " G";
                    }
                }
            }

            Console.SetCursorPosition(left, top);
            Console.WriteLine(" Bytes: {0}{1}, files: {2}, folders: {3}", length, str, files.Count, f[0].getFoldersNum());


            // folder info right
            dir = f[1].getRoot();
            left = 41;

            length = 0;
            files = new DirectoryInfo(dir).GetFiles().ToList();
            for (int i = 0; i < files.Count; i++)
            {
                length += files[i].Length;
            }
            str = "";
            if (length > 99999)
            {
                length /= 1024;
                str = " K";
                if (length > 9999)
                {
                    length /= 1024;
                    str = " M";
                    if (length > 9999)
                    {
                        length /= 1024;
                        str = " G";
                    }
                }
            }

            Console.SetCursorPosition(left, top);
            Console.WriteLine(" Bytes: {0}{1}, files: {2}, folders: {3} ", length, str, files.Count, f[1].getFoldersNum());
        }
        public void FolderStatus(FileList[] f, bool b)
        {
            if (b)
            {
                // folder info left
                string dir = f[0].getRoot();

                // adress in topper left
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                if (dir.Length < 34)
                {
                    Console.SetCursorPosition(19 - dir.Length / 2, 0);
                    Console.Write(" {0} ", dir);
                }
                else
                {
                    Console.SetCursorPosition(1, 0);
                    Console.Write(" {0}...{1} ", dir.Substring(0, 3), dir.Substring(dir.Length - 30));
                }

                // adress in topper right
                dir = f[1].getRoot();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                if (dir.Length < 23)
                {
                    Console.SetCursorPosition(58 - dir.Length / 2, 0);
                    Console.Write(" {0} ", dir);
                }
                else
                {
                    Console.SetCursorPosition(41, 0);
                    Console.Write(" {0}...{1} ", dir.Substring(0, 3), dir.Substring(dir.Length - 25));
                }
                dir = f[0].getRoot();
                // adress in footer

                Console.SetCursorPosition(0, 23);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("                                                                                ");
                Console.SetCursorPosition(0, 23);
                if (dir.Length < 34)
                {
                    Console.Write("{0}>", dir);
                }
                else
                {
                    Console.Write("{0}...{1}>", dir.Substring(0, 3), dir.Substring(dir.Length - 30));
                }
            }
            else
            {
                // folder info right
                string dir = f[1].getRoot();

                // adress in topper right
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                if (dir.Length < 23)
                {
                    Console.SetCursorPosition(58 - dir.Length / 2, 0);
                    Console.Write(" {0} ", dir);
                }
                else
                {
                    Console.SetCursorPosition(41, 0);
                    Console.Write(" {0}...{1} ", dir.Substring(0, 3), dir.Substring(dir.Length - 25));
                }

                // adress in topper left
                dir = f[0].getRoot();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                if (dir.Length < 34)
                {
                    Console.SetCursorPosition(19 - dir.Length / 2, 0);
                    Console.Write(" {0} ", dir);
                }
                else
                {
                    Console.SetCursorPosition(1, 0);
                    Console.Write(" {0}...{1} ", dir.Substring(0, 3), dir.Substring(dir.Length - 30));
                }
                dir = f[1].getRoot();
                // adress in footer
                Console.SetCursorPosition(0, 23);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;

                Console.Write("                                                                                ");
                Console.SetCursorPosition(0, 23);
                if (dir.Length < 34)
                {
                    Console.Write("{0}>", dir);
                }
                else
                {
                    Console.Write("{0}...{1}>", dir.Substring(0, 3), dir.Substring(dir.Length - 30));
                }
            }
        }
    }
}
