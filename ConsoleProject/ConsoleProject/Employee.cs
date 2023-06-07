using ConsoleProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class Employee
    {
        public string No;
        public string FullName;
        private string _position;

        public string Position
        {
            get { return _position; }
            set
            {
                while (_position != value)
                {
                    if (value.Length >= 2)
                    {
                        _position = value;
                    }
                    else
                    {
                        Console.WriteLine("Position name cant be less than 2 characters");
                        value = Console.ReadLine();
                    }
                }
            }
        }

        private double _salary;

        public double Salary
        {
            get { return _salary; }
            set
            {
                while (_salary != value)
                {
                    if (_salary >= 250)
                    {
                        _salary = value;
                    }
                    else
                    {
                        Console.WriteLine("Salary cant be less than 250");
                        value = double.Parse(Console.ReadLine());
                    }
                }
            }
        }

        public string DepartmentName;

    }
}
