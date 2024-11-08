using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
    public abstract class FileSystemComponent
    {
        protected string _name;

        public FileSystemComponent(string name)
        {
            _name = name;
        }

        public abstract void Display(int depth);

        public virtual void Add(FileSystemComponent component)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(FileSystemComponent component)
        {
            throw new NotImplementedException();
        }

        public virtual FileSystemComponent GetChild(int index)
        {
            throw new NotImplementedException();
        }
    }

    public class File : FileSystemComponent
    {
        public File(string name) : base(name)
        {
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + " File: " + _name);
        }
    }

    public class Directory : FileSystemComponent
    {
        private List<FileSystemComponent> _children = new List<FileSystemComponent>();

        public Directory(string name) : base(name)
        {
        }

        public override void Add(FileSystemComponent component)
        {
            _children.Add(component);
        }

        public override void Remove(FileSystemComponent component)
        {
            _children.Remove(component);
        }

        public override FileSystemComponent GetChild(int index)
        {
            return _children[index];
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + " Directory: " + _name);
            foreach (var component in _children)
            {
                component.Display(depth + 2);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Directory root = new Directory("Root");
            File file1 = new File("File1.txt");
            File file2 = new File("File2.txt");

            Directory subDir = new Directory("SubDirectory");
            File subFile1 = new File("SubFile1.txt");

            root.Add(file1);
            root.Add(file2);
            subDir.Add(subFile1);
            root.Add(subDir);

            root.Display(1);
        }
    }
}
