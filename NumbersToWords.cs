//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    internal class NumbersToWords
//    {
//        //static Dictionary<int, string> words = new Dictionary<int, string>
//        //{
//        //    { 0, "zero" },
//        //    { 1, "One" },
//        //    { 2, "Two" },
//        //    { 3, "Three" },
//        //    { 4, "Fourth" },
//        //    { 5, "Five" },
//        //    { 6, "Six" },
//        //    { 7, "Seven" },
//        //    { 8, "Eight" },
//        //    { 9, "Nine" },
//        //    { 10, "Ten" },
//        //    { 11, "Eleven" },
//        //    { 12, "Tweleve" },
//        //    { 14, "Fourteen" },
//        //    { 15, "Fifteenteen" },
//        //    { 16, "Sixteen" },
//        //    { 17, "Seventeen" },
//        //    { 18, "Eightteen" },
//        //}
     
     
//        internal static void Test()
//        {
//            Console.WriteLine("Enter a number \n");
//            int number = Convert.ToInt32(Console.ReadLine());
//            StringBuilder sb = new StringBuilder();
//            if (number > 100)
//            {
//                int hundreds = number / 100;
//                sb.Append($"{words[hundreds]} {words[100]}");
//                number = number % 100;
//            }
//            if(number > 20)
//            {
//                int tens = number / 10;
//                sb.Append($"{words[tens * 10]}");
//                number = number % 10;
//            }
//            if (number > 0) { }
//            {
//                sb.Append($"{words[number]} ");
//            }
//            Console.WriteLine(sb.ToString());
//        }
//    }
//}
