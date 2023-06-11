using ConsoleProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Models
{
    internal class Employee
    {
        public Employee(string departmentName)
        {
            _count++;
            _departmentName = departmentName;
            GenerateEmployeeNo();

        }
        private string _no;

        public string No { get; set; }

        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        private string _position;

        public string Position
        {
            get { return _position; }
            set
            {
                _position = value;
            }
        }

        private double _salary;

        public double Salary
        {
            get { return _salary; }
            set
            {
                _salary = value;
            }
        }

        private string _departmentName;

        public string DepartmentName
        {
            get { return _departmentName; }
            set
            {
                _departmentName = value;
            }
        }

        private static int _count = 999;
        private void GenerateEmployeeNo()
        {
            No = $"{DepartmentName.Substring(0, 2).ToUpper()}{_count}";
        }
    }
}
