using System.ComponentModel;
using System.Xml.Linq;
//using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace ConsoleApp1
{

    //public enum DayOfWeek
    //{
    //    Sunday = 1,
    //    Monday,
    //    Tuesday,
    //    Wednesday,
    //    Thursday,
    //    Friday,
    //    Saturday
    //}

    internal class Program
    {
        
        public static void Main(string[] args)
        {

            //string email = "someone@example.com";
            //if(email.IsValid()) // Extensions.IsValid(email)
            //{
            //    Console.WriteLine(
            //}


            //Inheritance.Test();
            //Interfaces.Test();
            //ExceptionHandling.Test();
            //MemoryManagement.Test();
            //collections.Test();
            //EventHandling.Test();
            //WorkingWithThreads.Test();
            //Synchronization.Test();
            //ParallelProgramming.Test();
            //WorkingWithTasks.Test();
            //WorkingWithTasks.Test2();
            //FileSystemManipulation.Test();
            //StreamManipulation.Test();
            //Time.Test();
            WorkingWithLinq.Test();
            //Chemical.Test();


        }

    }
    


    //public static class Extensions
    //{
    //    // Extension Methods
    //    public static bool IsValid(this string value)
    //    {
    //        return value.Contains("@");
    //    }

    //}
     
    



    //Console.WriteLine("Hello, World!");
    //for (int i = 0; i < 10; i++)
    //{
    //    Console.WriteLine($"{i}");
    //}
    //ArraysExample.Test();    //ClassnameReference .MethodName is how static method are invoked. 
    // Console.WriteLine($"Result: {SortSorting(Console.ReadLine()??"")


    //Student s1 = new Student();
    //Console.WriteLine("Enter RollNo: ");
    //s1.rollNo = Convert.ToInt32(Console.ReadLine());
    //Console.WriteLine("Enter Name: ");
    //s1.name = Console.ReadLine();
    //Console.WriteLine("Enter Course: ");
    //s1.course = Console.ReadLine();
    //Console.WriteLine("Enter Marks: ");
    //s1.marks = Convert.ToDouble(Console.ReadLine());
    //s1.show();


    //    int choice = 0;
    //    Console.Clear();
    //    EmployeeProcess ep = new EmployeeProcess();
    //    do
    //    {
    //        Console.WriteLine("********* MENU ******");
    //        Console.WriteLine(" 1. Add Employee Details");
    //        Console.WriteLine(" 2. Show Employee Details");
    //        Console.WriteLine("* ");
    //        Console.WriteLine("* 0.Quit");
    //        Console.WriteLine("************************************");
    //        Console.WriteLine("\nEnter choice");
    //        choice = Convert.ToInt32(Console.ReadLine());
    //        if (choice == 1)
    //        {
    //            ep.GetInputs();
    //        }
    //        else if (choice == 2)
    //        {
    //            ep.showDetails();
    //        }
    //        Console.WriteLine("\n===========> END\n\n");
    //    }
    //    while (choice != 0);
    //}

    //Implicity typed variables
    //employee e1 = new employee();
    //var e2 = new employee();
    //var s = new employee();
    //var s = "String";
    //var x = 10;    //Error: Implicity typed variables must be initialized

    ////Anonymous Types
    //var a1 = new { Name = "John", Age = 25 };
    //Console.WriteLine("");


    //static int Main()
    //{
    //    Console.WriteLine();
    //    return 0;
    //}

    /* EmployeeProcess process = new EmployeeProcess();
     process.Details();
     process.Show();

    */
    //TestEnums();
    //TestStudents();



    //}
    //static void TestEnums()
    //{
    //    DayOfWeek day = DayOfWeek.Monday;
    //    Console.WriteLine("Day of week: {0}", day);
    //    day = (DayOfWeek)5;
    //    Console.WriteLine("Day of week: {0}", day);
    //    switch (day)
    //    {
    //        case DayOfWeek.Sunday:
    //            Console.WriteLine("Sunday");
    //            break;
    //        default:
    //            Console.WriteLine("othey Day");
    //            break;
    //    }
    //}
    //    static void TestStudents()
    //    {
    //        Student2 student = new Student2();
    //        int rollNo = int.Parse(Console.ReadLine());
    //        string studentName = Console.ReadLine();
    //        string course = Console.ReadLine();
    //        double marks = double.Parse(Console.ReadLine());

    //        // Calling the GetStudentObject function to create a Student object
    //        var s1 = Student2.GetStudentObject(rollNo, studentName, course, marks);
    //    }


    //}
}