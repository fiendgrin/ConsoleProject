using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    internal class Department
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set {
                while (_name != value)
                {
                    if (value.Length >= 2)
                    {
                        _name = value;
                    }
                    else
                    {
                        Console.WriteLine("Department name cant be less than 2 characters");
                        value = Console.ReadLine();
                    }
                }
            }
        }

        private int _workerLimit;

        public int WorkerLimit
        {
            get { return _workerLimit; }
            set 

            {
                while (_workerLimit != value)
                {
                    string str = value.ToString();
                    if (value >= 1 && int.TryParse(str, out value))
                    {
                        _workerLimit = value;
                    }
                    else
                    {
                        Console.WriteLine("Cant be less than \"1\" and should be a number");
                        value = int.Parse(Console.ReadLine());
                    }
                }
            }
        }

        private double _salaryLimit;

        public double SalaryLimit
        {
            get { return _salaryLimit; }
            set 
            {
                while (_salaryLimit != value)
                {
                    string str1 = value.ToString();
                    if (value >= 1 && double.TryParse(str1, out value))
                    {
                        _salaryLimit = value;
                    }
                    else
                    {
                        Console.WriteLine("Cant be less than \"250\" and should be an amount");
                        value = double.Parse(Console.ReadLine());
                    }
                }
            }
        }

        public Employee[] Employees = { };

        public double CalcSalaryAverage() 
        {
            double sum = 0;
            foreach (Employee emp in Employees) 
            {
                sum += emp.Salary;
            }
            return sum/Employees.Length;
        }
    }
}
