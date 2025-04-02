using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MemoryManagement : IDisposable
    {
        private readonly int counter; // readonly - can be initialized only in the constructor
        const int MaxSize = 1_00_000; // digit seperator (_) - compiler feature
        // const fields are implicity static and readonly. They are complile-time constants
        private string[] names;
        public void Dispose()
        {
            names = null;
            Console.WriteLine($"XXXXXXXXXX==> Object {counter} DISPOSED <===XXXXXXXX");
            GC.SuppressFinalize( this ); // suppress the destructor from getting 
        }
        public MemoryManagement(int ctr)
        {
            names = new string[MaxSize];
            for (int i = 0; i < MaxSize; i++)
            {
                names[i] = $"This is a long string to fill memory quickly {i}";
            }
            counter = ctr;
            Console.WriteLine($">>> OBJECT {counter} created <<<");
        }
        ~MemoryManagement() {
            names = null;
            Console.WriteLine($"<<<<<<<<<<< OBJECT {counter} destroyed >>>>>>>>>>>>>>>>>>>>>>>");

        }
        internal static void Test()
        {
            Console.Clear();
            Console.WriteLine("Memory Management");
            MemoryManagement m;
            string format = "__Generation of 'm' {0} collection attempt: {1}___";
            for (int i = 0; i < 100; i++)
            {
                m = new MemoryManagement(i);
                if (i > 35 && i < 65)
                {
                    Console.WriteLine(format, "before lst", GC.GetGeneration(m));
                    GC.Collect(); // one forcible collection attempt
                    Console.WriteLine(format, "after lst", GC.GetGeneration(m));
                    if (i > 40 && i < 50)
                    {
                        GC.Collect();
                        Console.WriteLine(format, "after 2nd", GC.GetGeneration(m));
                    }
                }
                if(i<85 && i < 95)
                {
                    m.Dispose();
                }
            }

            using (MemoryManagement m2 = new MemoryManagement(99999))
            {
                Console.WriteLine("Inside the 'using' block");
            }
            MemoryManagement m3 = null;
            try
            {
                m3 = new MemoryManagement(100000);
            }
            finally
            {
                m3?.Dispose();
            }

            //for(int i = 0; i < 1000; i++)
            //{
            //    MemoryManagement m = new MemoryManagement(i);
            //}


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
