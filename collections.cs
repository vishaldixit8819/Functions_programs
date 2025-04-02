using System;
using System.Collections;

namespace ConsoleApp1
{
    public class Genericcollection<T>
    {
        List<T> list = new List<T>();
        T newObj = default(T);
        public void Add(T item) => list.Add(item);
        public void Remove(T item) => list.Remove(item);
        public T GetAt(int index) { return list[index]; }
        public T[] GetAll() { return list.ToArray(); }
        public int count { get { return list.Count; } }

        //public void Compare (T sourceObj, T anotherObj)
        //{
        //    if(sourceObj == anotherObj)
        //    {
        //        return;
        //    }
        //}
        public T this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }
    }
    public class Employeecollection : System.Collections.CollectionBase
    {
        ArrayList list = new ArrayList();
        // Method Expression Syntax - shortcut for creating a single line method
        // => lambda operator
        public void Add(employee emp) => list.Add(emp);
        public void Remove(employee emp) => list.Remove(emp);
        public employee GetAt(int index)
        {
            return (employee)list[index];
        }
        public employee[] GetAll()
        {
            return list.ToArray(typeof(employee)) as employee[];
        }
        // "new" keyword is used to hide the base class method - Method hiding
        new public int Count
        {
            get { return list.Count; }
        }

        // indexer property
        public employee this[int index]
        {
            get
            {
                return (employee)list[index];
            }
            set { list[index] = value; }
        }
    }
    internal class collections
    {
        static void Swap<T>(ref T source, ref T target)
        {
            T temp = source;
            source = target;
            target = temp;
        }
        internal static void Test()
        {
            //TestArrayLists();
            //TestHashtables();
            //TestSortedList();
            //TestStacksAndQueues();
            TestCustomCollections();
            int i = 10, j = 20;
            Swap(ref i, ref j);
            double d1 = 10.0, d2 = 20.0;
            Swap(ref d1, ref d2);
            


        }
        // Method Overloading
        // - the number, type or order of parameters should change
        static void SwapNormal(ref int i, ref int j) { }
        static void SwapNormal(ref double d1, ref double d2) { }
        static void SwapNormal(ref string s1, ref string s2) { }
        static void TestHashtables()
        {
            Console.WriteLine("Working with HashTables");
            Hashtable table = new Hashtable(capacity: 10);
            // capacity is the initial capacity to the table
            table.Add(1, "One");
            table.Add(2, "Two");
            table.Add(3, "Three");
            table.Add(4, "Fourth");
            table.Add(5, "Five");
            table.Add(6, "Six");

            if (table.ContainsKey(3))
            {
                table[3] = "Three updated";
            }
            else
            {
                table.Add(3, "Three Added");
                // Access items using the foreach loop

            }
            foreach (var key in table.Keys)
            {
                Console.WriteLine($"{key} - {table[key]}");
            }
        }

        static void TestStacksAndQueues()
        {
            Console.WriteLine("Working with stacks");
            Stack s = new Stack();
            // capacity is the initial capacity to the table
            s.Push("One");
            s.Push("Two");
            s.Push("Three");
            s.Push("Fourth");
            s.Push("Five");
            s.Push("Six");

            while (s.Count > 0)
            {
                var item = s.Peek();

                if (item.ToString() == "Three")
                {
                    Console.WriteLine("Peaked for Three: {0}", item);
                    Console.WriteLine("Popping it now");
                    s.Pop();
                    continue;
                }
                Console.WriteLine("Normal Popping: {0}", s.Pop());
            }
            Console.WriteLine("Working with Queue ");
            Queue queue = new Queue();
            queue.Enqueue("one");
            queue.Enqueue("two");
            queue.Enqueue("three");
            var item1 = queue.Peek();
            Console.WriteLine("Peeked: {0}", item1);
            while (queue.Count > 0)
            {
                Console.WriteLine("Dequeue: {0}", queue.Dequeue());

            }
        }
        static void TestArrayLists()
        {
            Console.WriteLine("Working with ArrayLists");
            ArrayList list = new ArrayList(capacity: 10);
            // capacity is the initial capacity to the list


            // Add items using the Add method or AddRange method
            list.Add(100);
            list.Add("welcome");
            list.Add(3.14);
            list.Add(true);
            list.AddRange(new int[] { 200, 300, 400, 500 });

            // Access items using indexer
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            // Remove Items using the Remove method or RemoveAt method
            list.Remove(3.14);
            list.RemoveAt(4);

            // Iterate over the items using a for loop
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            // Access one item using the indexer and typecasting
            try
            {
                int value = (int)list[2];
                //possibility of exception if the item is not of the expected type

            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        static void TestSortedList()
        {
            Console.WriteLine("Working with SortedLists");
            SortedList table = new SortedList();
            // capacity is the initial capacity to the table
            table.Add(1, "One");
            table.Add(2, "Two");
            table.Add(3, "Three");
            table.Add(4, "Fourth");
            table.Add(5, "Five");
            table.Add(6, "Six");

            if (table.ContainsKey(3))
            {
                table[3] = "Three updated";
            }
            else
            {
                table.Add(3, "Three Added");
                // Access items using the foreach loop

            }
            foreach (var key in table.Keys)
            {
                Console.WriteLine($"{key} - {table[key]}");
            }
        }
        static void TestCustomCollections()
        {
            var e1 = new employee { id = 100, firstName = "John", lastName = "Doe" };
            var e2 = new employee { id = 101, firstName = "Jane", lastName = "Doe" };
            Employeecollection collection = new Employeecollection();
            collection.Add(e1);
            collection.Add(e2);
            // collection.Add(100); // this is not allowed, and not recommended
            for (int i = 0; i < collection.Count; i++)
            {
                employee e = collection[i];
                //employee e = collection.GetAt(i);
                Console.WriteLine(e);
            }

        }
        static void TestGenericcollections()
        {
            Genericcollection<int> intcoll = new Genericcollection<int>();
            intcoll.Add(12);
            intcoll.Add(13);
            var i = intcoll.GetAt(0);

            Genericcollection<string> strcoll = new Genericcollection<string>();
            strcoll.Add("");
            Genericcollection<employee> empColl = new Genericcollection<employee>();
            empColl.Add(new employee());
        }
    }
}
