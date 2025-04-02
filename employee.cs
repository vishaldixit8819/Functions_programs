using System;

namespace ConsoleApp1
{
    public class employee
    {
        #region Fields
        private int _id;
        private string _firstName;
        private string _lastName;
        private double _basicsalary;
        private double _grosssalary;
        private double _hra;
        private double _da;
        private double _pf;
        private double _income_tax;
        private double _net_salary;
        #endregion


        #region Properties
        public int id { get { return _id; } set { _id = value; } }
        public string firstName { get { return _firstName; } set { _firstName = value; } }
        public string lastName { get { return _lastName; } set { _lastName = value; } }
        public double basicsalary { get { return _basicsalary; } set { } }
        public double grosssalary { get; set; }

        public double Hra
        {
            get
            {
                _hra = 0.5*basicsalary;
                return _hra;
            }
        }
        public double Da
        {
            get
            {
                _da = 0.2 * basicsalary;
                return _da;
            }
        }

        public double Pf
        {
            get
            {
                _pf = 0.12 * basicsalary;
                return _pf;
            }
        }
        public double Income_tax
        {
            get
            {
                _income_tax = 0.1 * grosssalary;
                return _income_tax;
            }
        }

        public double Net_salary
        {
            get
            {
                _net_salary = basicsalary + Hra + Da - Pf - Income_tax;
                return _net_salary;
            }
        }
        #endregion
    }
}
