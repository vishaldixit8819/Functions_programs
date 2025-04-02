using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class StreamManipulation
    {
        internal static void Test()
        {
            TestFileStreamManipulation();
            TestStreamReadersAndWriters();
            TestBinaryReaderWriter();
        }
        static string RootFolder = @"../../../";
        static void TestFileStreamManipulation()
        {
            var fileName = Path.Combine(RootFolder, "FileStream.txt");
            // FIleStream is a byte-oriented stream, reads/writes bytes of data.
            // FileMode -> Open, OpenOrCreate, create, CreateNew, Append
            using (FileStream fs = new FileStream(
                path: fileName, // required
                mode: FileMode.Create, // required
                access: FileAccess.Write,   // optional
                share: FileShare.ReadWrite))    // optional
            {
                var contents = $"This is file content written on {DateTime.Now.ToString()}";
                var buffer = System.Text.Encoding.UTF8.GetBytes(contents);
                fs.Position = 0;
                fs.Write(buffer: buffer, offset: 0, count: buffer.Length);
                fs.Flush(); // required, OS has a 64k buffers
                fs.Close();
            }
            Console.WriteLine("File contents written successfully.");
            Console.WriteLine("Attempting to read the contents back....");
            using (FileStream fs2 = new FileStream(fileName, FileMode.Open))
            {
                var buffer = new byte[fs2.Length];
                fs2.Read(buffer, 0, buffer.Length); 
                var contents = Encoding.UTF8.GetString(buffer);
                fs2.Close();
                Console.WriteLine($"File contents: {contents}");
            }

            // other ways of creating and opening files
            /*var fs1 = File.OpenRead(fileName);
            fs1.Close();
            fs1 = File.Create(fileName);
            fs1.Close();
            var bytes = File.ReadAllBytes(fileName);*/ // opens the file and reads all the contents
        }

        static void TestStreamReadersAndWriters()
        {
            var fileName = Path.Combine(RootFolder, "StreamReaderWriter.txt");
            var contents = $"This is file content written on {DateTime.Now.ToString()}";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.AutoFlush = true;
                writer.WriteLine(contents);
            }
            Console.WriteLine("Contents written to file successfully using StreamWriter");
            Console.WriteLine("Trying to read contents from file using StreamREader");
            using (StreamReader reader = new StreamReader(fileName))
            {
                contents = reader.ReadToEnd();
                reader.Close();
            }
        }
        static void TestBinaryReaderWriter()
        {
            (var id, double d, var name) = (11993, 99847749.23, "Bengaluru");
            string fileName = Path.Combine(RootFolder, "DataFile.bin");
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    writer.Write(id);
                    writer.Write(d);
                    writer.Write(name);
                    writer.Flush();
                }
            }
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                fs.Position = 0;  // rewind the file position to 0
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    Console.WriteLine($"Id: {reader.ReadInt32()}, d:{reader.ReadDouble()}");
                    Console.WriteLine($"name: {reader.ReadString()}");
                }
                fs.Close();
            }
        }
    }
}
