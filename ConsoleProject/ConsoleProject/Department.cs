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
        private Employee[] _employees;
        public Department()
        {
            _employees = new Employee[0];
            
        }
        public ref  Employee[] Employees 
        { 
            get { return ref _employees; } 
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _workerLimit;
        public int WorkerLimit
        {
            get { return _workerLimit; }
            set  {  _workerLimit = value;}
        }
        private double _salaryLimit;
        public double SalaryLimit
        {
            get { return _salaryLimit; }
            set
            {
                _salaryLimit = value;
            }
        }
        public double CalcSalaryAverage()
        {
            double sum = 0;
            foreach (Employee emp in Employees)
            {
                sum += emp.Salary;
            }
            return sum / Employees.Length;
        }
        public override string ToString()
        {
            return $"\nOld Name:{this._name}\nOld Worker Limit:{this._workerLimit}\nOld Salary Limit:{this._salaryLimit}";
        }
    }
}
