using System;
using static System.Console;

// File-Scoped namespace
namespace ConsoleApp1
    //another namespace cannot be defined in this file.
    // namespace Myname;
    // sub-namespaces are not allowed within this file.
    // namespace 
{
    public class FileSystemManipulation
    {
        internal static void Test()
        {
            TestDirectoryClass();
            TestFileInfoAndDirectoryInfoClasses();  
            TestDriveInfo();
        }
        static string RootFolder = @"C:\TestFolder";
        static string BaseFileName = "SampleFile.txt";
        static void TestDirectoryClass()
        {
            if (!Directory.Exists(RootFolder))
            {
                Directory.CreateDirectory(RootFolder);
            }
            var directories = Directory.GetDirectories(@"C:\");
            foreach (var d in directories) { WriteLine($"Dir => {d}"); }
            var cwd = Directory.GetCurrentDirectory();
            WriteLine("\nCurrent working Directory is {0}", cwd);

            // Get all the files in the current working directory
            var files = Directory.GetFiles(cwd);
            // Loop through all the files and print only the file name without the Complete Path
            // we use the Path class GetFileName() method to get the filename part
            foreach (var file in files) { WriteLine($"File => {Path.GetFileName(file)}"); }

            if(Directory.Exists(RootFolder))
                Directory.Delete(path: RootFolder, recursive: true);
        }
        static void TestFileClass()
        {
            if (!Directory.Exists(RootFolder)) { Directory.CreateDirectory(RootFolder); }
            // combines "C;\TestFolder" and "SampleFile.txt" into "C:\TestFolder\SampleFile.txt"
            var filePath = Path.Combine(RootFolder, BaseFileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            // create the file
            File.Create(filePath).Close(); // touch operation

            // write contents to the file.
            File.WriteAllText(filePath, "welcome to C# and .NET programming ");
            WriteLine($"Last accessed: {File.GetLastAccessTime(filePath)}");
            WriteLine($"Created on {File.GetLastAccessTime(filePath)}");

            // copy the file
            var file2 = Path.Combine(RootFolder, "SampleFileCopy.txt");
            File.Copy(
                sourceFileName: filePath,
                destFileName: file2);

            // Read all the contents from the copied file and print it.
            var contents = File.ReadAllText(file2);
            WriteLine($"Copied file contains:\n\t{contents}");
        }
        static void TestFileInfoAndDirectoryInfoClasses()
        {
            if (!Directory.Exists(RootFolder)) { Directory.CreateDirectory(RootFolder); }
            var dInfo = new DirectoryInfo(RootFolder);
            var files = dInfo.GetFiles(); //Directory.GetFiles(Path);
            WriteLine($"Folder created on : {dInfo.CreationTime}");
            var fInfo = new FileInfo(Path.Combine(RootFolder, BaseFileName));
            WriteLine($"File created on: {fInfo.CreationTime}");
            WriteLine($"Full FIle Name: {fInfo.FullName}");
        }
        static void TestDriveInfo()
        {
            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                WriteLine($"Drive : {drive}");
                WriteLine($"volume Name: {drive.VolumeLabel}");
                WriteLine($"Total size: {drive.TotalSize}");
                WriteLine($"Free space: {drive.TotalFreeSpace}");
            }
        }
    }
}
