using System.Threading;
using System;
using static System.Console;

//File-scoped Namesapce declarations
// All the types defined in this file will be part of this namespace
namespace ConsoleApp1
{
    public class WorkingWithThreads
    {
        internal static void Test()
        {

            WriteLine("Working with Threads");
            ThreadStart ts1 = new ThreadStart(Run);
            Thread t1 = new Thread(ts1);
            t1.Name = "First Thread";
            t1.Start();

            Thread t2 = new Thread(Run);
            t2.Name = "Second Thread";
            t2.Start();

            ParameterizedThreadStart pts = new ParameterizedThreadStart(RunObject);
            Thread t3 = new Thread(pts);
            t3.Name = "Third Thread";
            t3.Start("Data");


            WriteLine("Thread 1 Started. Press a key to terminate......  ");
            ReadKey();
        }
        // created a function which matches the ThreadStart delegate signature void target(void)
        static void Run()
        {
            var name = Thread.CurrentThread.Name;
            WriteLine($"Thread {name} is running");
            Thread.Sleep(millisecondsTimeout: 5000); // wait for 5 seconds
            WriteLine($"Thread {name} is completed ");
        }
        // create a function which matches the PerameterizedThreadStart delegate signature void target (object)
        static void RunObject(object data)
        {
            var str = data as string;
            var name  = Thread.CurrentThread.Name;
            WriteLine($"Thread {name} is running with data {str}");
            Thread.Sleep(millisecondsTimeout: 1000);  // wait for 1 seconds
            WriteLine($"Thread {name} is completed");
        }
    }
}
