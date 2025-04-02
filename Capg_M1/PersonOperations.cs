//Write a program which notifies the user when an Item is added to the Dictionary. The dictionary stores int and Person objects.
//The Person class has following properties:
//Id - int, FirstName - string, LastName - string, City - string
//PersonExists Exception class inherits from System.Exception class. Overload appropriate
//constructors Create a class PersonOperations which has the following public properties and methods:
//1.PersonCollection property Dictionarycint, Person> 2. event PersonAddedEvent of type ActioncPerson>
//3. AddNew Person(Person) returns true if added successfully, else false.
//If the person exists in the dictionary, the application should throw PersonExists Exception. If the person is added successfully, then the application
//4. should trigger a notification providing the details of the Person. ListPerson(criteria-string) this method should find all the persons in the dictionary and returns the List<Persons>
//5. FindPerson(name-string) this method should find the person whose name matches the given string. It can be in the firstName or the lastName. Match the whole string og)
//and return the Person Object 6. RenovePersons(city-string)-
//this method will remove all the persons from the ches the dictionary which matches the city parameter




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreparationM1
{
    public class PersonOperations
    {
        // Dictionary to store persons, using their Id as the key
        public Dictionary<int, Person> PersonCollection { get; set; } = new Dictionary<int, Person>();

        // Event to notify when a person is added
        public event Action<Person> PersonAddedEvent;
        public bool AddNewPerson(Person person)
        {
            // Check if the person already exists in the dictionary by Id
            if (PersonCollection.ContainsKey(person.Id))
            {
                throw new PersonExistsException("Person with this Id already exists.");
            }

            // Add the person if not already present
            PersonCollection.Add(person.Id, person);

            // Trigger the event if a person is added successfully
            PersonAddedEvent?.Invoke(person);

            return true;
        }

        // Method to list all persons with a matching criteria (part of name or city)
        public List<Person> ListPersons(string criteria)
        {
            return PersonCollection.Values
                .Where(p => p.FirstName.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                            p.LastName.Contains(criteria, StringComparison.OrdinalIgnoreCase) ||
                            p.City.Contains(criteria, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Method to find a person by first or last name
        public Person FindPerson(string name)
        {
            return PersonCollection.Values
                .FirstOrDefault(p => p.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase) ||
                                     p.LastName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // Method to remove persons from a specific city
        public void RemovePersonsByCity(string city)
        {
            var personsToRemove = PersonCollection.Values
                .Where(p => p.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var person in personsToRemove)
            {
                PersonCollection.Remove(person.Id);
            }
        }
    }

}
