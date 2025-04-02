using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class ChemicalComposition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ChemicalName { get; set; }
    }

    public class Chemical
    {
        static List<ChemicalComposition> chemicalCompositions = new List<ChemicalComposition>();

        static void AddChemicalComposition(int id, string name, string chemicalName)
        {
            chemicalCompositions.Add(new ChemicalComposition { Id = id, Name = name, ChemicalName = chemicalName });
            Console.WriteLine("Chemical Composition added successfully.");
            DisplayAllChemicalCompositions();
        }

        static List<ChemicalComposition> RetrieveByName(string namePart)
        {
            return chemicalCompositions.Where(c => c.Name.Contains(namePart, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        static List<ChemicalComposition> RetrieveByChemicalName(string chemicalNamePart)
        {
            return chemicalCompositions.Where(c => c.ChemicalName.Contains(chemicalNamePart, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        static void RemoveChemicalComposition(int id)
        {
            var composition = chemicalCompositions.FirstOrDefault(c => c.Id == id);
            if (composition != null)
            {
                chemicalCompositions.Remove(composition);
                Console.WriteLine("Chemical Composition removed successfully.");
            }
            else
            {
                Console.WriteLine("Chemical Composition not found.");
            }
            DisplayAllChemicalCompositions();
        }

        static void DisplayAllChemicalCompositions()
        {
            Console.WriteLine("\nCurrent Chemical Compositions:");
            foreach (var item in chemicalCompositions)
            {
                Console.WriteLine($"{item.Id} - {item.Name} - {item.ChemicalName}");
            }
            Console.WriteLine();
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add Chemical Composition");
            Console.WriteLine("2. Remove Chemical Composition");
            Console.WriteLine("3. Search Chemical Composition by Name");
            Console.WriteLine("4. Search Chemical Composition by Chemical Name");
            Console.WriteLine("5. Exit");
        }

        static void Check()
        {
            bool exit = false;
            while (!exit)
            {
                DisplayMenu();
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Chemical Composition ID:");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Chemical Composition Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Chemical Composition Chemical Name:");
                        string chemicalName = Console.ReadLine();
                        AddChemicalComposition(id, name, chemicalName);
                        break;

                    case 2:
                        Console.WriteLine("Enter Chemical Composition ID to remove:");
                        int removeId = int.Parse(Console.ReadLine());
                        RemoveChemicalComposition(removeId);
                        break;

                    case 3:
                        Console.WriteLine("Enter part of the name to search:");
                        string namePart = Console.ReadLine();
                        var byName = RetrieveByName(namePart);
                        if (byName.Any())
                        {
                            Console.WriteLine("Search results by Name:");
                            foreach (var item in byName)
                            {
                                Console.WriteLine($"{item.Id} - {item.Name} - {item.ChemicalName}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No results found.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter part of the chemical name to search:");
                        string chemicalNamePart = Console.ReadLine();
                        var byChemicalName = RetrieveByChemicalName(chemicalNamePart);
                        if (byChemicalName.Any())
                        {
                            Console.WriteLine("Search results by Chemical Name:");
                            foreach (var item in byChemicalName)
                            {
                                Console.WriteLine($"{item.Id} - {item.Name} - {item.ChemicalName}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No results found.");
                        }
                        break;

                    case 5:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        internal static void Test()
        {
            Check();
        }
    }
}





//// 1. Create a class Tablet with properties: [Id-int, Name-string, Composition-List<ChemicalComposition>, Price-double, MfgDate-Datetime, ExpDate-DateTime, ManufacturerName-string]
////2. Create a class called Pharmacy and write a Test method to include
////all the options given above plus:
////e.Add new Tablet.
////    f.retrieve Tablet details
////g.Update Tablet details
////h.Remove Tablet
////1. exit the program.
////When the user selects Retrieve Tablet Details, provide subchoices
////a.Retrieve by Name (tablet Name or Manufacturer name)
////b.Retrieve by Price range
////c.Retrieve by Expiry Date
////Call Pharmacy.Test() in the Program.Main() method.





//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Diagnostics;
//using System.Linq;
//using static System.Net.Mime.MediaTypeNames;
//using static System.Runtime.InteropServices.JavaScript.JSType;
//using System.Xml.Linq;

//namespace PharmacyApp
//{
//    class ChemicalComposition
//    {
//        public int Id { get; set; }
//        public string Name { get; set; }
//        public string ChemicalName { get; set; }
//    }

//    class Tablet
//    {
//        public string Name { get; set; }
//        public List<ChemicalComposition> Composition { get; set; }
//        public double Price { get; set; }
//        public DateTime MfgDate { get; set; }
//        public DateTime ExpDate { get; set; }
//        public string ManufacturerName { get; set; }

//        public Tablet(int id, string name, List<ChemicalComposition> composition, double price, DateTime mfgDate, DateTime expDate, string manufacturerName)
//        {
//            Id = id;
//            Name = name;
//            Composition = composition;
//            Price = price;
//            MfgDate = mfgDate;
//            ExpDate = expDate;
//            ManufacturerName = manufacturerName;
//        }
//    }
//    class Pharmacy
//    {
//        static List<Tablet> tablets = new List<Tablet>();
//        static void AddTablet(int id, string name, List<ChemicalComposition> composition, double price, DateTime mfgDate, DateTime expDate, string manufacturerName)
//        {
//            var tablet = new Tablet(id, name, composition, price, mfgDate, expDate, manufacturerName);
//            tablets.Add(tablet);
//            Console.WriteLine("Tablet added successfully.");
//        }

//        static List<Tablet> RetrieveByName(string searchTerm)
//        {
//            return tablets.Where(t => t.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || t.ManufacturerName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
//        }

//        static List<Tablet> RetrieveByPriceRange(double minPrice, double maxPrice)
//        {
//            return tablets.Where(t => t.Price >= minPrice && t.Price <= maxPrice).ToList();
//        }

//        static List<Tablet> RetrieveByExpDate(DateTime expDate)
//        {
//            return tablets.Where(t => t.ExpDate == expDate).ToList();
//        }

//        static void UpdateTablet(int id, string newName, List<ChemicalComposition> newComposition, double newPrice, DateTime newMfgDate, DateTime newExpDate, string newManufacturerName)
//        {
//            var tablet = tablets.FirstOrDefault(t => t.Id == id);
//            if (tablet != null)
//            {
//                tablet.Name = newName;
//                tablet.Composition = newComposition;
//                tablet.Price = newPrice;
//                tablet.MfgDate = newMfgDate;
//                tablet.ExpDate = newExpDate;
//                tablet.ManufacturerName = newManufacturerName;
//                Console.WriteLine("Tablet updated successfully.");
//            }
//            else
//            {
//                Console.WriteLine("Tablet not found.");
//            }
//        }

//        static void RemoveTablet(int id)
//        {
//            var tablet = tablets.FirstOrDefault(t => t.Id == id);
//            if (tablet != null)
//            {
//                tablets.Remove(tablet);
//                Console.WriteLine("Tablet removed successfully.");
//            }
//            else
//            {
//                Console.WriteLine("Tablet not found.");
//            }
//        }

//        static void DisplayTabletDetails(List<Tablet> tabletList)
//        {
//            if (tabletList.Any())
//            {
//                foreach (var tablet in tabletList)
//                {
//                    Console.WriteLine($"Id: {tablet.Id}, Name: {tablet.Name}, Price: {tablet.Price}, Manufacturer: {tablet.ManufacturerName}, Expiry Date: {tablet.ExpDate.ToShortDateString()}");
//                }
//            }
//            else
//            {
//                Console.WriteLine("No tablets found.");
//            }
//        }

//        static void DisplayMenu()
//        {
//            Console.WriteLine("Choose an option:");
//            Console.WriteLine("1. Add New Tablet");
//            Console.WriteLine("2. Retrieve Tablet Details");
//            Console.WriteLine("3. Update Tablet Details");
//            Console.WriteLine("4. Remove Tablet");
//            Console.WriteLine("5. Exit");
//        }

//        static void RetrieveTabletDetailsMenu()
//        {
//            Console.WriteLine("Choose an option to retrieve tablets:");
//            Console.WriteLine("a. Retrieve by Name (tablet Name or Manufacturer Name)");
//            Console.WriteLine("b. Retrieve by Price Range");
//            Console.WriteLine("c. Retrieve by Expiry Date");
//        }

//        static void Test()
//        {
//            bool exit = false;
//            while (!exit)
//            {
//                DisplayMenu();
//                int choice = int.Parse(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:
//                        Console.WriteLine("Enter Tablet Id:");
//                        int id = int.Parse(Console.ReadLine());
//                        Console.WriteLine("Enter Tablet Name:");
//                        string name = Console.ReadLine();
//                        Console.WriteLine("Enter Tablet Price:");
//                        double price = double.Parse(Console.ReadLine());
//                        Console.WriteLine("Enter Manufacturing Date (yyyy-mm-dd):");
//                        DateTime mfgDate = DateTime.Parse(Console.ReadLine());
//                        Console.WriteLine("Enter Expiry Date (yyyy-mm-dd):");
//                        DateTime expDate = DateTime.Parse(Console.ReadLine());
//                        Console.WriteLine("Enter Manufacturer Name:");
//                        string manufacturerName = Console.ReadLine();

//                        List<ChemicalComposition> compositions = new List<ChemicalComposition>();
//                        Console.WriteLine("Enter number of compositions:");
//                        int numCompositions = int.Parse(Console.ReadLine());
//                        for (int i = 0; i < numCompositions; i++)
//                        {
//                            Console.WriteLine($"Enter Composition {i + 1} ID:");
//                            int compId = int.Parse(Console.ReadLine());
//                            Console.WriteLine($"Enter Composition {i + 1} Name:");
//                            string compName = Console.ReadLine();
//                            Console.WriteLine($"Enter Composition {i + 1} Chemical Name:");
//                            string compChemicalName = Console.ReadLine();
//                            compositions.Add(new ChemicalComposition { Id = compId, Name = compName, ChemicalName = compChemicalName });
//                        }

//                        AddTablet(id, name, compositions, price, mfgDate, expDate, manufacturerName);
//                        break;

//                    case 2:
//                        RetrieveTabletDetailsMenu();
//                        char subChoice = Console.ReadKey().KeyChar;
//                        Console.WriteLine();

//                        switch (subChoice)
//                        {
//                            case 'a':
//                                Console.WriteLine("Enter name or manufacturer to search:");
//                                string searchTerm = Console.ReadLine();
//                                var tabletsByName = RetrieveByName(searchTerm);
//                                DisplayTabletDetails(tabletsByName);
//                                break;

//                            case 'b':
//                                Console.WriteLine("Enter minimum price:");
//                                double minPrice = double.Parse(Console.ReadLine());
//                                Console.WriteLine("Enter maximum price:");
//                                double maxPrice = double.Parse(Console.ReadLine());
//                                var tabletsByPrice = RetrieveByPriceRange(minPrice, maxPrice);
//                                DisplayTabletDetails(tabletsByPrice);
//                                break;

//                            case 'c':
//                                Console.WriteLine("Enter expiry date (yyyy-mm-dd):");
//                                DateTime expiryDate = DateTime.Parse(Console.ReadLine());
//                                var tabletsByExpDate = RetrieveByExpDate(expiryDate);
//                                DisplayTabletDetails(tabletsByExpDate);
//                                break;

//                            default:
//                                Console.WriteLine("Invalid option.");
//                                break;
//                        }
//                        break;

//                    case 3:
//                        Console.WriteLine("Enter Tablet ID to update:");
//                        int updateId = int.Parse(Console.ReadLine());
//                        Console.WriteLine("Enter new Tablet Name:");
//                        string newName = Console.ReadLine();
//                        Console.WriteLine("Enter new Tablet Price:");
//                        double newPrice = double.Parse(Console.ReadLine());
//                        Console.WriteLine("Enter new Manufacturing Date (yyyy-mm-dd):");
//                        DateTime newMfgDate = DateTime.Parse(Console.ReadLine());
//                        Console.WriteLine("Enter new Expiry Date (yyyy-mm-dd):");
//                        DateTime newExpDate = DateTime.Parse(Console.ReadLine());
//                        Console.WriteLine("Enter new Manufacturer Name:");
//                        string newManufacturerName = Console.ReadLine();

//                        List<ChemicalComposition> newCompositions = new List<ChemicalComposition>();
//                        Console.WriteLine("Enter number of new compositions:");
//                        int numNewCompositions = int.Parse(Console.ReadLine());
//                        for (int i = 0; i < numNewCompositions; i++)
//                        {
//                            Console.WriteLine($"Enter new Composition {i + 1} ID:");
//                            int newCompId = int.Parse(Console.ReadLine());
//                            Console.WriteLine($"Enter new Composition {i + 1} Name:");
//                            string newCompName = Console.ReadLine();
//                            Console.WriteLine($"Enter new Composition {i + 1} Chemical Name:");
//                            string newCompChemicalName = Console.ReadLine();
//                            newCompositions.Add(new ChemicalComposition { Id = newCompId, Name = newCompName, ChemicalName = newCompChemicalName });
//                        }

//                        UpdateTablet(updateId, newName, newCompositions, newPrice, newMfgDate, newExpDate, newManufacturerName);
//                        break;

//                    case 4:
//                        Console.WriteLine("Enter Tablet ID to remove:");
//                        int removeId = int.Parse(Console.ReadLine());
//                        RemoveTablet(removeId);
//                        break;

//                    case 5:
//                        exit = true;
//                        break;

//                    default:
//                        Console.WriteLine("Invalid option. Please try again.");
//                        break;
//                }
//            }
//        }
//    }
//}

