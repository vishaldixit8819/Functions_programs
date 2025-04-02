using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class EmployeeProcess
    {
        employee e1 = new employee();
        // Field
        private employee _info;

        //Method
        public void GetInputs()
        {
            if (_info == null)
            {
                _info = new employee();
            }
            Console.WriteLine("Enter the Employee_Id: ");
            _info.id = Convert.ToInt32(e1.id);
            ///......
        }
        public void Show()
        {
            if (e1 == null)
            {
                Console.WriteLine("Error");
                return;
            }
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("Employee Details: \n");
            sb.AppendLine($"ID: {e1.id}");
            sb.AppendLine($"Name: {e1.firstName} + {e1.lastName}");
            sb.AppendLine($"Salary: {e1.basicsalary:C}");
            sb.AppendLine($"Salary: {e1.grosssalary:C}");

            string outstring = sb.ToString();
            Console.WriteLine(outstring);
            Console.WriteLine(e1.Net_salary);
            //.........rest of code
        }

        public void Details()
        {
            if (e1 == null)
            {
                e1 = new employee();
            }
            Console.WriteLine("Enter Employee Id: ");
            e1.id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Employee First Name: ");
            e1.firstName = Console.ReadLine();

            Console.WriteLine("Enter Employee Last Name: ");
            e1.lastName = Console.ReadLine();

            Console.WriteLine("Enter Employee Basic Salary: ");
            e1.basicsalary = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Employee Gross Salary: ");
            e1.grosssalary = double.Parse(Console.ReadLine());
        }

        //public static void Main(string[] args)
        //{
        //    EmployeeProcess process = new EmployeeProcess();
        //    process.Details();
        //    process.Show();
        //}
    }
}
