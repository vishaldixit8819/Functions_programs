using static System.Console;
using System.Threading;
using System.Diagnostics;
using System.Text;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    internal class ParallelProgramming
    {
        internal static void Test()
        {
            WriteLine("Press a key to begin execution...");
            ReadKey();

            //SequentialProcess();

            WriteLine("Begining of sequentioal execution...");
            ParallelProcess();
            ReadKey();

            WriteLine("Press a key to terminate...");
            ReadKey();

        }
        const int MaxSize = 1_00_000;

        static void SequentialProcess()
        {
            WriteLine($"Beginning {nameof(SequentialProcess)} now...");
            Stopwatch sw = Stopwatch.StartNew();
            for(int i=0; i < MaxSize; i++)
            {
                var aes = Aes.Create(); // using System.Security.Cryptography
                aes.GenerateIV();   // generates the initialization vector
                aes.GenerateKey();  // generates a key
                var bytes = aes.Key;
                _ = ConvertHexString( bytes );

                // _ is called a discard, the return value is discarded here.
            }
            sw.Stop();
            WriteLine($"Time taken to process the loop: {sw.Elapsed.Microseconds}");
        }

        static void ParallelProcess()
        {
            WriteLine($"Beginning {nameof(ParallelProgramming)} now..");
            Stopwatch sw = Stopwatch.StartNew();
            for(int i=0;i < MaxSize; i++)
            {
                var aes = System.Security.Cryptography.Aes.Create();
                aes.GenerateIV();
                aes.GenerateKey();
                var bytes = aes.Key;
                _= ConvertHexString( bytes );
            }
            sw.Stop(); WriteLine($"Time taken the process the loop: {sw.ElapsedMilliseconds}");
        }
        static string ConvertHexString(byte[] bytes)
        {
            StringBuilder sb = new();
            bytes.ToList().ForEach(c => sb.AppendFormat("{0:X}", c));
            return sb.ToString();
        }
    }
}
