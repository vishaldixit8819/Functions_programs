using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IBase
    {
        void DoWork(); // Method declarartion
    }
    public interface IChild : IBase // IBase // Interface inheritance
    {
        void PerformTask();  // Method declarartion
        string Name { get;  }   // Property declaration

    }
    // another interface which contains the same method declaration as defined in Ichild
    public interface ITransact
    {
        void PerformTask();
    }
    public /*abstract */ class InterfaeImplementation : IBase, IChild, ITransact
    {
        // From IChild Interface
        public string Name { get { return "Interface Implementation"; } }
        // From IBase interface
        public void DoWork() {
            Console.WriteLine("InterfaceImplementation.DoWrok() called.");
        }
        // public abstract void DoWork();
        // From IChild and ITransact interfaces

        public void PerformTask()
        {
            Console.WriteLine("InterfaceImplementation.Performance() called.");
        }
        public void ShowDetails()
        {
            Console.WriteLine("ITransact.SowDetails() in new version is called");
            // these bmethods, though can be defined, are practically surface.
        }
        void IChild.PerformTask() {
            Console.WriteLine("IChild.PerformTask() called.");
        }
        void ITransact.PerformTask()
        {
            Console.WriteLine("ITransact.PerformTask() called.");
        }     
    }
        internal class Interfaces
        {
            internal static void Test()
            {
                InterfaeImplementation ii = new InterfaeImplementation();
                ii.DoWork();
                ii.PerformTask();
                Console.WriteLine(ii.Name);
                Console.WriteLine("===================");

                // Interface pointers/references
                IBase ib = ii; // assigning an object of a class to an interface  reference
                ib.DoWork(); // invoke members defined in the interface
                //ib.Name; // Not allowed as the interface does not contain the property declaration
                Console.WriteLine("===================");

                IChild ic = ii; // assigning an object of a class to an interface  reference
                // invoke members from the IChild interface and its base interface IBase
                ic.DoWork(); 
                ic.PerformTask();
                Console.WriteLine(ic.Name);
                Console.WriteLine("===================");

                ITransact it = ii;  // assigning an object of a class to an interface refrence
                it.PerformTask();   // invoke members defined in the iTransact interface 
                //it.ShowDetails();

            }
            // call the interface.Test() method in the Main() method and run the application. 
        }

    }
