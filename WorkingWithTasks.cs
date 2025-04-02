using System;
using static System.Console;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class WorkingWithTasks
    {
        internal static void Test()
        {
            WriteLine("Working with Tasks");
            //Action, Func, Predicate
            // Action Delegate invokes functions which do not return values
            // Func delegate invokes functions which return values
            // Predicate delegate invokes functions which returns bool true/false

           /* void Print()
            {
                WriteLine("Action a1 called.");
            }
            Action a1 = new Action(Print);*/

            Action a1 = () => { WriteLine("Action a1 called"); };
            a1();
            Action<string> a2 = (str) => { WriteLine($"Input value: {str}"); };
            a2("Hello World");
            // Action<int, int, int, int, ... 16 parameters

            Func<string> f1 = () => "Hello World";
            WriteLine($"Output from f1: {f1()}");
            Func<int, int, string> f2 = (a,b) => (a+b).ToString();
            WriteLine($"Output from f2(10,20): {f2(10, 20)}");

            Predicate<string> ContainsSymbol = (input) => input.Contains("@");
            var status = ContainsSymbol("someone@example.com");
            WriteLine($"Email {(status ? "is" : "is not")} valid.");

            WriteLine("Working with Tasks");
            Task task = new Task(() => { Thread.Sleep(500);  WriteLine("Task 1 executing"); });
            task.Start();
            // Task is a background thread. The CLR uses one thread from its ThreadPool to exeute the task.
            WriteLine("All tasks started");
        }
        internal static void Test2()
        {
            ForegroundColor = ConsoleColor.Green;
            Method1();
            Method2();
            WriteLine("sequence one completed. Press a key to start second sequence");
            ReadKey();
            ResetColor();

            Method1Async();
            Method2();
            WriteLine("All methods started");
        }
        static void Method1()
        {
            for (int i = 0; i < 25; i++)
            {
                WriteLine($"Method 1: {i}");
                Task.Delay(100).Wait();
            }
        }
        static void Method2()
        {
            for(int i = 0;i < 25; i++)
            {
                WriteLine($"\tMethod 2: {i}");
                Task.Delay(100).Wait();
            }
        }
        static async Task Method1Async()
        {
            await Task.Run(() =>
            {
                for(int i = 0; i < 25; i++)
                {
                    WriteLine($"Method 1: {1}");
                    Task.Delay(100).Wait();
                }
            });
        }
    }
}
