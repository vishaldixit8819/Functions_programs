using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // 1. Define a class which will be used to pass the event arguments or event data 
    // usually this class inherits from System.EvetArgs base class in .NET

    public class RegistrationEventArgs : EventArgs
    {
        public int Number { get; set; }
        public string Message { get; set; }
    }
    // 2. Define a delegate to which the signature of the method that will handle the event
    public delegate void RegistrationEventHandler(object source, RegistrationEventArgs args);
     // 3. Define a class which will raise the event - called Publisher
    public class Publisher {
        //3.1 Define an event of the delegate type
        public event RegistrationEventHandler RegistrationEvent;

        // 3.2 Define a method which will raise the event
        public void RaiseNotification()
        {
            // 3.3 Loop through the numbers and 
            for (int i = 0; i < 10; i++)
            {
                // 3.4 check if the number is 5 or 6 
                if (i == 5 || i == 6)
                {
                    // 3.5 Define the event arguments
                    var args = new RegistrationEventArgs()
                    {
                        Number = i,
                        Message = $"Registration Number {i} is raised"
                    };
                    // 3.6 Check if the event is null or not
                    if (RegistrationEvent != null)
                    {
                        RegistrationEvent(this, args);
                        // RegistrationEvent.Invoke(this, args);
                    }

                }
            }
        }
    }
    // 4. Define a class which will handle the event - called Subscriber
    public class Subscriber { 
        
        //4.1 Define a method which matches with the signature of the delegate
        public void HandlerEvent(object source, RegistrationEventArgs args)
        {
            // 4.2 Write the code to handle the event and print the details.
            Console.WriteLine($"Subscriber:[Number: {args.Number}, \n Message:{args.Message}]");

        }
    
    }
        // 5. This class will bind the publisher and subscriber and execute tasks to raise the event
        internal class EventHandling
        {
            // 5.1 Define the test method
            internal static void Test()
            {
                // 5.2 create an instance of the Publisher
                Publisher pub = new Publisher();

                // 5.3 create an instance of the Subscriber
                Subscriber sub = new Subscriber();

                // 5.4 Bind the subscriber with the publisher - Step 2 of Delegates Instantiation
                pub.RegistrationEvent += new RegistrationEventHandler(sub.HandlerEvent);

                // 5.5 call the function which Raises the notification from the publisher
                pub.RaiseNotification();
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
