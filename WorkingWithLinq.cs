using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public record order (int OrderId, DateTime OrderDate);
    public record OrderDetails(int OrderId, int ProductId, int Quantity, double Price);

    // Write a static function in WorkingWithLinq class called TestingJoins();
    // In the function, create a List of Order List<Order> and add 2 objects to it.
    // In the same function, create another list for OrderDetails List<OrderDetails>
    // and add 4 objects, 2 objects with the first OrderId and 2 objects with the second OrderId
    internal class WorkingWithLinq
    {
        static List<string> cities = new List<string>
        {
            "Bengaluru", "Chennai", "Panaji", "Hyderabad", "Mumbai", "Thiruvananthpuram", "Amaravati", "Bhopal",
            "Ranchi", "Raipur", "Patna", "Kolkata", "Bhubaneshwar", "Jaipur", "Gandhinagar", "Lucknow", "Dehradun",
            "Shimla", "Srinagar", "Leh", "Gangtok", "Chandigarh", "Dispur", "Aizwal", "Imphal", "Shilong", "Itanagar",
            "New Delhi", "Agartala", "Kohima"
        };

        static string line = "".PadLeft(50, '=');
        static int counter = 1;
        static void PrintList(IEnumerable<string> list, string header)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"*************Test {counter++}. {header} ********************").AppendLine(line)
                .AppendLine("");
            foreach (string city in list)
            {
                sb.AppendFormat($"{city,-20}");
            }
            sb.AppendLine(line);
            Console.WriteLine(sb.ToString());
        }
        internal static void Test()
        {
            //PrintList(null, "");  // Do not type this line or type this comment
            //BasicQuery();
            //ProjectionOperators();
            //RestrictionOperator();
            //SortingOperators();
            //AggregationOperators();
            //GroupingOperators();
            //PartitionOperators();
            //ElementOperator();
            //QuantifierOperators();
            TestingJoins();

           
        }


        static void TestingJoins()
        {
            // Create a List of Orders and add 2 objects to it
            List<order> orders = new List<order>
            {
                new order(1, new DateTime(2024, 1, 17)),
                new order(2, new DateTime(2024, 1, 19))
            };

            // Create a List of OrderDetails and add 4 objects (2 for each OrderId)
            List<OrderDetails> orderDetails = new List<OrderDetails>
            {
                new OrderDetails(1, 201, 3, 500), 
                new OrderDetails(1, 202, 4, 150), 
                new OrderDetails(2, 203, 5, 300), 
                new OrderDetails(2, 204, 6, 120)  
            };

            // Perform a LINQ join between Orders and OrderDetails on OrderId
            var joinQuery = from detail in orderDetails
                            join order in orders on detail.OrderId equals order.OrderId
                            select new
                            {
                                order.OrderId,
                                order.OrderDate,
                                detail.ProductId,
                                detail.Quantity,
                                detail.Price
                            };

            // Display the results of the join
          
            foreach (var item in joinQuery)
            {
                Console.WriteLine($"Order Id: {item.OrderId}\tDate: {item.OrderDate}");
                Console.WriteLine($"\t{item.ProductId},{item.Price},{item.Quantity}");
            }


            //var orderDetails = new List<OrderDetails> {
            //    new OrderDetails(1, 1, 100, 100),
            //    new OrderDetails(1, 2, 200, 222),
            //    new OrderDetails(2, 1, 650, 666),
            //    new OrderDetails(2, 2, 750, 777)
            //};
            //var q1 = from ProductId in orderDetails
            //         select ProductId;
            ////q.ToList().ForEach(x => Console.WriteLine(x));
            //var q2 = from OrderDetails.Select(c => c.ProductId).Cast<int>().ToList();
            //q2.ToList().ForEach(x => Console.WriteLine($"{x}, Type: {x.GetType().Name}"));

            //int counter = 1;
            //var q3 = orderDetails.ToDictionary(x => x.ProductId, x => x);
            //foreach (var key in q3.Keys)
            //{
            //    Console.WriteLine($"{key} => {q3[key]}");
            //}
        }

        static void ElementOperator()
        {
            // First, last, ElementAt
            // ==> if retreival fails, throws 
            // FirstOrDefault, LastOrDefault, ElementOrDefault
            // => returns default values if there are no matching elements
            var first = cities.First();
            var last = cities.Last();
            var firstCondition = cities.First(c => c.Length == 10);
            var lastCondition = cities.Last(c => c.EndsWith("ar"));
            var s = $"First: {first}\nLast: {last}";
            s += $"\nConditional [First: {firstCondition}, Last: {lastCondition} ]";

            var elemAt = cities.ElementAt(5);
            s += $"\nElement at 5 position: {elemAt}";
            Console.WriteLine(s) ;

            var firstOrDefault = cities.FirstOrDefault(C => C.EndsWith("Tokyo"));
            Console.WriteLine($"First or Default: {firstOrDefault}");

            //firstOrDefault = cities.First(c => c.EndsWith("Tokyo"));
            //Console.WriteLine($"First only: {firstOrDefault}");
        }



        //static void JoinOperators()
        //{
        //    var chemList = new List<chemicalComposition>();
        //    {
        //        new chemicalComposition(id:1, name:"Hdrogeny", chemicalName:"H"),
        //        new chemicalComposition(id: 1, name: "Oxygen", chemicalName: "O"),
        //        new chemicalComposition(id: 1, name: "Sodium", chemicalName: "Na"),
        //        new chemicalComposition(id: 1, name: "Chlorine", chemicalName: "Cl"),
        //    };
        //    var tabList = new List<Tablet>
        //    {
        //        new Tablet(id:1, name:"Water", price:30, mfgDate:DateTime.Now,
        //        expDate:DateTime.Now, manufacture
        //        )
        //    };
        //}

        static void QuantifierOperators()
        {
            // Any, All, Contains
            // Any -> any element in the list matches, returns true, else false
            // All -> all element that matches, returns true, else false
            // Contains -> any element that matches, return true, else false

            var any = cities.Any(c => c.StartsWith("S"));
            var all = cities.All(c => c.StartsWith("S"));
            var contains = cities.Contains("Itanagar");
            var s = $"Any matches 'S': {any}\nAll matches 'S': {all}";
            s += $"List contains 'Itanagar': {contains}";
            Console.WriteLine(s);

            // Find, FindAll, FindIndex, FindLastIndex, IndexOf, LastIndexOf
            // Find -> finds the first matching element
            // FindAll -> finds all the matching elements
            // FindIndex -> returns the index of the first matching element
            // FindLastIndex -> returns the index of the index of the last matching element
            // IndexOf -> gets the index of the first matching element
            // LastIndexOf -> returns the index of the last matching element
            // FindLast -> returns the last matching element
            var result = cities.Find(c => c.Equals("Leh"));
            Console.WriteLine(result);
        }

        static void PartitionOperators()
        {
            // Take, skip, Takewhile, skipWhile, chunk
            // cannot use the query syntax, need to use the Method syntax only.

            var q1 = cities.Take(5);
            PrintList(q1, "First 5 items");
            var q2 = cities.Skip(10);
            PrintList(q2, "Skip 10 items");
            var q3 = cities.TakeWhile(c => c.Length < 10);
            var q4 = cities.SkipWhile(c => c.Length < 10);
            PrintList(q3, "Take while length < 10");
            PrintList(q4, "Skip while length < 10");
            // break the list into chunks of 10 items.
            var q5 = cities.Chunk(10);
            foreach (var chunk in q5)
            {
                foreach (var item in chunk)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
            }
        }

        static void GroupingOperators()
        {
            // group by...
            var q1 = from city in cities
                     group city by city[0] into g
                     orderby g.Key descending
                     select g;
            Console.WriteLine($"********** Test {counter++}, Group Operator");
            Console.WriteLine(line);
            foreach (var group in q1)
            {
                Console.WriteLine($"Cities that start with {group.Key}");
                var items = group.ToList();  // extract items that belong to the key

                foreach (var item in items)
                    Console.Write($"{item, -20}");
                Console.WriteLine();
                Console.WriteLine(line);
            }
            Console.WriteLine(line);
            var q2 = cities.Where(c => c[0]=='A' || c[0]=='D' || c[0]=='R' || c[0]=='T')
                .GroupBy(c => c[0], c => new {Char = c[0], city = c })
                .OrderByDescending(g => g.Key)
                .Select(g => g);
            Console.WriteLine($"******** Test {counter++}, Group Operators");
            Console.WriteLine(line);
            foreach(var group in q2)
            {
                Console.WriteLine($"Cities that start with {group.Key}");
                // var items = group.ToList(); // extract items that belong to the key
                var items = group.ToList();
                var sortedList = from x in items
                                 orderby x.city[1] descending
                                 select x;
                foreach (var item in sortedList)
                {
                    Console.WriteLine(item.city, -20);
                    Console.WriteLine();
                    Console.WriteLine(line);
                }
                Console.WriteLine(line);
            }
                //.OrderByDescending(x => x.ToList().
        }

        static void AggregationOperators()
        {
            // Count, Sum, Min, Max, Average
            var list = new int[] { 1, 34, 54, 33, 232, 66, 56, 32, 2, 24 };
            var count = list.Count();
            var sum = list.Sum(x => x); // sum the values
            var min = list.Min(x => x); // get the minimum value;
            var max = list.Max(x => x); // get the maximum value
            var avg = list.Average(x => x);
            Console.WriteLine($"**************** Test {counter++}, Aggregation Operators");
            Console.WriteLine(line);
            Console.WriteLine($"List: {string.Join(", ", list)}");
            Console.WriteLine($"\tCount: {count}\n\tSum:{sum}\n\tMin:{min}\n\tMax:{max}");
            Console.WriteLine($"\tAverage:{avg}");
            Console.WriteLine(line);
            //Console.WriteLine($);
        }
        static void SortingOperators()
        {
            // orderBy. ThenBy, OrderByDescending, ThenByDescending
            var q1 = from c in cities
                      orderby c[0] ascending, c[1] descending
                      select c;
            PrintList(q1, "Sorted on c[0] ASC and C[1] DESC");
            var q2 = cities
                .OrderByDescending(c => c[0])
                .ThenBy(c => c[1])
                .Select(c => c);
            PrintList(q2, "Sorted on c[0] DESC and C[1] ASC");

            // Write a query which woll sort the cities on their length
            // and display the result.

            // Write a query which will sort the cities on length and display the output as (sort in descending order)
            // Length           City
            // 18               Thiruvananthapuram
            // 15               XYZ....
        }
        static void RestrictionOperator()
        {
            // where
            // exact cites where the length of the city name is > 10 chars
            var q1 = from c in cities
                     where c.Length > 10
                     select c;
            PrintList(q1, "Cities Length > 10");
            var q2 = cities.Where(c => c.StartsWith("A")).Select(c => c);
            PrintList(q2, "Cities Starts With A");

            // Compound conditions using && and ||
            var q3 = from c in cities
                     where c.Length > 5 && c.StartsWith("B")
                     select c;
            PrintList(q3, "Cities Starts With 'B' and Length greater than 5 ");
            var q4 = from c in cities
                     where c.Length <8 || c.Length>12
                     select c;
            PrintList(q4, "Cities length less than 8 or length greater than 12");


            //var numbers = Enumerable.Range(0, 100).ToList();
            //var evenNumbers = from x in numbers
            //                  where x % 2 == 0
            //                  select x;

        }
        static void ProjectionOperators()
        {
            // Select, SelectMany
            // shows contents from the collection in the specified formats
            var q1 = from c in cities
                     select new
                     {
                         StartsWith = c[0],
                         Length = c.Length,
                         Name = c
                     };

            Console.WriteLine($"********************* Test {counter++}.Projection 1 *******************");
            Console.WriteLine(line);
            Console.WriteLine($"{"Starts With",-11}{"Length",-7} Name");
            foreach (var item in q1)
            {
                Console.WriteLine($"{item.StartsWith,-11}{item.Length} {item.Name}");
            }
            Console.WriteLine($"\n{line}");

            var q2 = cities.Select(c => new
            {
                StartsWith = c[0],
                Length = c.Length,
                Name = c
            });
            Console.WriteLine($"********************* Test {counter++}.Projection 2 *******************");
            Console.WriteLine(line);
            Console.WriteLine($"{"Starts With",-11}{"Length",-7} Name");
            //foreach(var item in q2)
            //{

            //}
        }

        static void BasicQuery()
        {
            // LINQ Expression can be written in Query Syntax and Method Syntax
            /* Query Syntax ->
             * from     item in collection
             * left     declare query level variables
             * join     another set based on criteria
             * where    restriction clause
             * orderby  columnlist
             * select   projectionList
             * --> is not evaluated at compile time - processed at runtime
             * --> deferred queries or Lazy execution
             */

            var q1 = from city in cities
                     select city;
            PrintList(q1, "List of cities (Query Syntax)");
            // Method Syntax
            var q2  = cities.Select(city => city);   // Immediate Execution
            PrintList(q2, "List of cities (Method Syntax)");
        }
    }
}


