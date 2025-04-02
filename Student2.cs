using System;
    public class Student2
    {
        public int RollNo { get; set; }
        public string StudentName { get; set; }
        public string Course { get; set; }
        public double Marks { get; set; }


    //Constructor to initialize the properties
    //    public Student2(int rollNo, string stu_name, string course, double marks)
    //{
    //    RollNo = rollNo;
    //    StudentName = stu_name;
    //    Course = course;
    //    Marks = marks;
    //}

    public static Student2 GetStudentObject(int rollNo, string studentName, string course, double marks)
    {
        if (!string.IsNullOrEmpty(studentName))
        {
            return null;
        }
        if (studentName.Length < 3)
        {
            return null;
        }
        if (marks < 0 || marks > 100)
        {
            return null;
        }

        if (course.ToLower() != "engineering")
        {
            return null;
        }
        return new Student2 { RollNo = rollNo, StudentName = studentName, Course = course, Marks = marks };
    }

    public void DisplayStudentInfo()
    {
        //Console.WriteLine($"Roll Number: {RollNo}");
        //Console.WriteLine($"Student Name: {StudentName}");
        //Console.WriteLine($"Course: {Course}");
        //Console.WriteLine($"Marks: {Marks}");

        Console.WriteLine("Enter the RollNo: ");
        int rollNo = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the StudentName: ");
        string studentName = Console.ReadLine();
        Console.WriteLine("Enter the Course: ");
        string course = Console.ReadLine();
        Console.WriteLine("Enter the Marks: ");
        double marks = double.Parse(Console.ReadLine());
    }


    // Main method to test the function
    //public static void Main(string[] args)
    //{
    //    Student2 student = new Student2();
        

    //    // Calling the GetStudentObject function to create a Student object by using 2 methods
    //    //var s1 = Student2.GetStudentObject(rollNo,studentName,course,marks); // 1.
    //    student.DisplayStudentInfo();

    //    //GetStudentObject(rollNo, studentName, course, marks); // 2.
    //}

}

