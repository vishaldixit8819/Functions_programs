using System.Threading;
using static System.Console;


namespace ConsoleApp1
{
    internal class Synchronization
    {
        private int counter;
        private object _syncLock;

        public void RunNormal()
        {
            var name  = Thread.CurrentThread.Name;
            WriteLine($"Thread{name} begins execution");
            // loop 100 times
            while(counter < 100)
            {
                // assign the value or temp variable
                int temp = counter++;
                temp++;
                // put the current thread to sleep for 1ms. This will allow other threads to run
                Thread.Sleep(millisecondsTimeout:1);
                counter = temp;
            }
            WriteLine($"Thread {name} ends execution");
        }

        // copy the statements from the RunNormal() and paste it here
        public void RunWithMonitor()
        {

            // get the current thread name
            var name = Thread.CurrentThread.Name;
            WriteLine($"Thread {name} begins execution");
            // loop 100 times
            while (counter < 100)
            {
                // ==> using the lock(_syncLock)
                Monitor.TryEnter(
                    obj:_syncLock,
                    millisecondsTimeout: 1000   // Monitor waits for 1second to lock the object, 
                            // If it cannot lock, throws exception and terminates the block.
                            // Avoids deadlocks
                    );
                    // assign the value to temp variable
                    int temp = counter;
                    // increment the temp value
                    temp++;
                    // put the current thread to sleep for 1 ms. This allow other threads to
                    Thread.Sleep(millisecondsTimeout: 1);
                    WriteLine($"Thread {name} is reports counter at {counter}");
                    // assign the incremented temp value to counter
                    counter = temp;

                    Monitor.Exit(_syncLock);  // ==> end of lock block
                }
            WriteLine($"Thread {name} ends execution");
        }
        
        public void CreatThreadAndStartExecution()
        {
            WriteLine("Working with Threads");
            // created an array of 5 threads
            Thread[] myThread = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                myThread[i] = new Thread(RunNormal);
                myThread[i].Name = $"({1})";
                myThread[i].Start();
            }
        }
        internal static void Test()
        {
            WriteLine("Press a key to start the operation.");
            ReadKey();

            var sync = new Synchronization();
            sync.CreatThreadAndStartExecution();

            //sync.RunWithMonitor();
            WriteLine("All threads started. Press a key to terminated...");
            ReadKey();
        }
    }
}
