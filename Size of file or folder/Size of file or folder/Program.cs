using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Size_of_file_or_folder
{
	class Program
	{
        static ulong totalBytes = 0;
        static void Main(string[] args)
        {
            Console.Write("Enter the path: ");
            string path = "";
            Console.WriteLine();
            if (args.Length > 0)
            {
                path = args[0];
            }
            else
            {
                path = Console.ReadLine();
            }
            Console.WriteLine();
            if (File.Exists(path))
            {
                ProcessFile(path);
            }
            else if (Directory.Exists(path))
            {
                ProcessDirectory(path);
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", path);
            }
            Console.WriteLine();
            Console.WriteLine($"Total size of \"{path}\" is {totalBytes} bytes ({totalBytes / 1024f} KB)");
            Console.ReadLine();
        }

        public static void ProcessDirectory(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            string[] subDirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subDirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        public static void ProcessFile(string path)
        {
            totalBytes += (ulong)File.ReadAllBytes(path).Length;
            Console.WriteLine($"\"{path}\"");
        }
    }
}
