using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM2
{
    public abstract class FileSystemComponent
    {
        public string Name { get; set; }

        public FileSystemComponent(string name)
        {
            Name = name;
        }

        public abstract void Display(int indent = 0);
        public abstract int GetSize();
    }

    public class File : FileSystemComponent
    {
        public int Size { get; set; }

        public File(string name, int size) : base(name)
        {
            Size = size;
        }

        public override void Display(int indent = 0)
        {
            Console.WriteLine($"{new string(' ', indent)}Файл: {Name} (размер: {Size} KB)");
        }

        public override int GetSize()
        {
            return Size;
        }
    }

    public class Directory : FileSystemComponent
    {
        private List<FileSystemComponent> components = new List<FileSystemComponent>();

        public Directory(string name) : base(name) { }

        public void Add(FileSystemComponent component)
        {
            if (!components.Contains(component))
            {
                components.Add(component);
            }
        }

        public void Remove(FileSystemComponent component)
        {
            components.Remove(component);
        }

        public override void Display(int indent = 0)
        {
            Console.WriteLine($"{new string(' ', indent)}Папка: {Name}");
            foreach (var component in components)
            {
                component.Display(indent + 2);
            }
        }

        public override int GetSize()
        {
            int totalSize = 0;
            foreach (var component in components)
            {
                totalSize += component.GetSize();
            }
            return totalSize;
        }
    }

    public class Program
    {
        public static void Main()
        {
            File file1 = new File("File1.txt", 100);
            File file2 = new File("File2.txt", 200);
            File file3 = new File("File3.txt", 50);

            Directory root = new Directory("Root");
            Directory folder1 = new Directory("Folder1");
            Directory folder2 = new Directory("Folder2");
            Directory subfolder1 = new Directory("SubFolder1");

            root.Add(folder1);
            root.Add(folder2);
            folder1.Add(file1);
            folder1.Add(file2);
            folder2.Add(subfolder1);
            subfolder1.Add(file3);

            Console.WriteLine("Содержимое файловой системы:");
            root.Display();
            Console.WriteLine($"\nОбщий размер файловой системы: {root.GetSize()} KB");
        }
    }
}
