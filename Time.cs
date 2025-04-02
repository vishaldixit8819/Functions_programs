using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public struct Time
    {
        public int hh, mm, ss;
        public Time(int h, int m, int s)
        {
            hh = h; mm = m; ss = s;
        }
        public Time(int seconds)
        {
            hh = seconds / 3600;
            mm = (seconds % 3600) / 60;
            ss = seconds % 60;
        }
        public int Totalseconds()
        {
            return hh * 3600 + mm * 60 + ss;
        }
        public override string ToString()
        {
            return $"Time is: {hh:00}:{mm:00}:{ss:00}";
        }
        //syntax for op overloading
        //[public] [static] <returnType> operator <op> (<arg1>,<arg2>)
        //operator that can be overlaoded as Airthmatic,relational, logical,Bitwise
        //Relational operators have to overload in pairs (>,<), (>=,<=), (==,!=)
        public static Time operator +(Time a, Time b)
        {
            return new Time(a.Totalseconds() + b.Totalseconds());
        }
        public static bool operator >(Time a, Time b)
        {
            return a.Totalseconds() > b.Totalseconds();
        }
        public static bool operator <(Time a, Time b)
        {
            return a.Totalseconds() < b.Totalseconds();
        }
        public static implicit operator Time(int input)
        {
            return new Time(input);
        }
        public static explicit operator int(Time a) { return a.Totalseconds(); }
        internal static void Test()
        {
            Time t1 = new Time(3, 4, 5);
            Time t2 = new Time(4, 5, 6);
            Console.WriteLine($"Timw 1: {t1}");
            Console.WriteLine($"Timw 2: {t2}");
            Time t3 = t1 + t2;
            Console.WriteLine($"Time 3:{t3}");
            if (t1 > t2)
            {
                Console.WriteLine($"Time {t1} is greater than Time {t2}");
            }
            else
            {
                Console.WriteLine($"Time {t2} is greater than Time {t1}");
            }
            int totalSeconds = (int)t3;
            Console.WriteLine($"Total Seconds i  time 3: {totalSeconds}");
            Time t4 = 3661;
            Console.WriteLine($"Time 4:{t4}");
        }
    }
}