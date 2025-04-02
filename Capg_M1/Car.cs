using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreparationM1
{
    public class Car
    {
        protected string name;
        public Car(string name)
        {
            this.name = name;
        }

        public int CarId { get; set; } = 1;
    }

}
