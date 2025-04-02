using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreparationM1
{
    public class PersonExistsException : Exception
    {
        // Default constructor
        public PersonExistsException() : base("Person already exists in the dictionary.") { }

        // Constructor with message
        public PersonExistsException(string message) : base(message) { }

        // Constructor with message and inner exception
        public PersonExistsException(string message, Exception innerException) : base(message, innerException) { }
    }
}
