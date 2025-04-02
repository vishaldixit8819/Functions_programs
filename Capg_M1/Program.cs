using System;

namespace PreparationM1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of PersonOperations
            PersonOperations personOperations = new PersonOperations();

            // Subscribe to the PersonAddedEvent
            personOperations.PersonAddedEvent += (person) =>
            {
                Console.WriteLine($"Person added: {person.FirstName} {person.LastName}, City: {person.City}");
            };

            try
            {
                // Add new persons
                var person1 = new Person(1, "John", "Doe", "New York");
                var person2 = new Person(2, "Jane", "Smith", "Los Angeles");

                personOperations.AddNewPerson(person1);  // This should trigger the event
                personOperations.AddNewPerson(person2);  // This should trigger the event

                // Try adding a person with the same ID to see the exception
                var person3 = new Person(1, "James", "Brown", "Chicago");
                personOperations.AddNewPerson(person3);  // This should throw PersonExistsException
            }
            catch (PersonExistsException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // List persons based on a search criteria (e.g., "Doe")
            var searchResult = personOperations.ListPersons("Doe");
            Console.WriteLine("Search Result:");
            foreach (var person in searchResult)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}, City: {person.City}");
            }

            // Find a person by name (e.g., "Jane")
            var foundPerson = personOperations.FindPerson("Jane");
            if (foundPerson != null)
            {
                Console.WriteLine($"Found Person: {foundPerson.FirstName} {foundPerson.LastName}, City: {foundPerson.City}");
            }

            // Remove persons from a specific city (e.g., "New York")
            personOperations.RemovePersonsByCity("New York");

            // Verify removal
            Console.WriteLine("Persons after removal:");
            foreach (var person in personOperations.PersonCollection.Values)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}, City: {person.City}");
            }
        }
    }

}
