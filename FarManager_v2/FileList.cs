using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager_v2
{
    class FileList
    {
        List<string> files;
        List<string> directories;
        string root;
        int position;

        public FileList()
        {
            root = Directory.GetCurrentDirectory();
            files = Directory.GetFiles(root).ToList<string>();
            directories = Directory.GetDirectories(root).ToList<string>();
            position = 0;

            foreach (var dir in directories)
            {
                files.Add(dir);
            }
            files.Sort();
            files.Insert(0, "..");
        }
        public List<string> getFiles()
        {
            return files;
        }
        public List<string> getDirs()
        {
            return directories;
        }
        public int getFoldersNum()
        {
            return directories.Count;
        }
        public int getFilesNum()
        {
            return files.Count - directories.Count;
        }
        public int getPos()
        {
            return position;
        }
        public string getRoot()
        {
            return root;
        }
        public void plusPos()
        {
            if (position < files.Count - 1)
            {
                position++;
            }
        }
        public void minusPos()
        {
            if (position > 0)
            {
                position--;
            }
        }
        public void goLeftPos()
        {
            if (files.Count / 2 <= position)
            {
                if (files.Count > 18)
                {
                    position = position - (files.Count / 2) - 1;
                }
            }
        }
        public void goRightPos()
        {
            if (files.Count / 2 >= position)
            {
                if (files.Count > 18)
                {
                    position = position + (files.Count / 2) + 1;
                }
                if (position >= files.Count - 1)
                {
                    position = files.Count - 1;
                }
            }
        }
        public void GoTo()
        {
            if (files[position].Equals(".."))
            {
                if (!root.Substring(root.Length - 2).Equals(":\\") )
                {
                    root = Directory.GetParent(root).ToString();
                    Console.WriteLine("{0}", root);
                    files = Directory.GetFiles(root).ToList<string>();
                    directories = Directory.GetDirectories(root).ToList<string>();
                    position = 0;
                    foreach (var dir in directories)
                    {
                        files.Add(dir);
                    }
                    files.Sort();
                    files.Insert(0, "..");
                }
            }
            else if (directories.IndexOf(files[position]) != -1)
            {
                root = files[position];
                Console.WriteLine("{0}", root);
                files = Directory.GetFiles(root).ToList<string>();
                directories = Directory.GetDirectories(root).ToList<string>();
                position = 0;
                foreach (var dir in directories)
                {
                    files.Add(dir);
                }
                files.Sort();
                files.Insert(0, "..");
            }
            else
            {
                System.Diagnostics.Process.Start(files[position]);
            }
        }
    }
}
