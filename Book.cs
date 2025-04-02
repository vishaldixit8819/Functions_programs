//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    [Serializable]
//    public class Book
//    {
//        private string _isbn = "Not Assigned";
//        public string Title { get; set; }
//        public decimal Price { get; set; }
//        public string Author { get; set; }
//        public override string ToString() => $"{Title} {Price} {Author} {_isbn}";

    
        
//    }
//    internal class SerializationExample
//    {
//        static string RootFolder = "@sample.com";
        

//        static Book CreateBook()
//        {
//            return new Book() { Title = "title 1", Price = 12345.67M, Author = "Unknown"};
//        }
//        static void TestBinarySerialization()
//        {
//            var fileName = Path.Combine(RootFolder, binFile);
//            var book = CreateBook();
//            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
//            {
//#pragma warning disable SYSLIB0011   
//                BinaryFormatter bf = new BinaryFormatter();
//#pragma warning disable SYSLIB0011
//                bf.Serialize(fs, book);
//                fs.Flush();
//                fs.Close();
//            }
//            // Deserialize
//            using (FileStream fs2 = new FileStream(fileName, FileMode.Open))
//            {
//#pragma warning disable SYSLIB0011
//                BinaryFormatter bf = new BinaryFormatter();
//#pragma warning disable SYSLIB0011
//                var b = bf.Deserialize(fs2) as Book;
//                Console.WriteLine($"Book Deserialized:\n\t{b}");
//            }
//        }
//    }
//}
