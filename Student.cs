using System;

namespace ConsoleApp1
{
    public class Student
    {
        #region Fields
        private int _rollNo;
        private string _name;
        private string _course;
        private double _marks;
        #endregion

        #region Methods
        public void show()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("Student Details: \n");
            sb.AppendLine($"Roll No: {_rollNo}");
            sb.AppendFormat("Name: {0}\n", _name);
            sb.AppendLine($"Course: {_course}");
            sb.AppendLine($"Marks: {_marks}");

            string outputString = sb.ToString();    // Converts the string string builder to string
            Console.WriteLine(outputString); ;
        }

        #region Properties
        public int rollNo
        {
            get { return _rollNo; }
            set { _rollNo = value; }
        }
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string course
        {
            get { return _course; }
            set { _course = value; }
        }
        public double marks
        { get { return _marks; } 
            set { _marks = value; } 
        }

        public double Average
        {
            get { return _marks / 6; }
        }
        private string _conduct;
        public string conduct
        {
            get { return _conduct; }
        }

        #endregion

        #region Methods
        public void Read()
        {
            Console.WriteLine("Enter RollNo: ");
            _rollNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name: ");
            _name = Console.ReadLine();
            Console.WriteLine("Enter Course: ");
            _course = Console.ReadLine();
            Console.WriteLine("Enter Marks: ");
            _marks = Convert.ToDouble(Console.ReadLine());
        }
        #endregion

    }

}
#endregion