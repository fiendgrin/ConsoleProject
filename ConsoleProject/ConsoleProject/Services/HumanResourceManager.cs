using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleProject.Interfaces;
using ConsoleProject.Models;

namespace ConsoleProject.Services
{
    internal class HumanResourceManager : IHumanResourceManager
    {
        private Department[] _departments;
        public HumanResourceManager()
        {
            _departments = new Department[0];
        }
        public Department[] Departments
        {
            get { return _departments; }

        }


        public void AddDepartment(string name, int workerlimit, double SalaryLimit)
        {
            Department department = new Department();
            department.Name = name;
            department.WorkerLimit = workerlimit;
            department.SalaryLimit = SalaryLimit;
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = department;
        }

        public void AddEmployee(string fullName, string position, double salary, string departmentName)
        {

            Employee employee = new Employee(departmentName);
            employee.FullName = fullName;
            employee.Position = position;
            employee.Salary = salary;
            employee.DepartmentName = departmentName;
            for (int i = 0; i < _departments.Length; i++)
            {
                if (_departments[i].Name == employee.DepartmentName)
                {
                    Array.Resize(ref _departments[i].Employees, _departments[i].Employees.Length + 1);
                    _departments[i].Employees[_departments[i].Employees.Length - 1] = employee;
                }
            }

        }

        public void EditDepartaments(string name, string newname, int workerlimit, double salarylimit)
        {

            for (int i = 0; i < _departments.Length; i++)
            {
                if (_departments[i].Name == name)
                {
                    _departments[i].Name = newname;
                    _departments[i].WorkerLimit = workerlimit;
                    _departments[i].SalaryLimit = salarylimit;
                }
            }
        }

        public Department[] GetDepartments()
        {
            return _departments;
            //for (int i = 0; i < _departments.Length; i++)
            //{
            //    Console.WriteLine($"{i + 1}:\nName:{_departments[i].Name}\nWorker Limit:{_departments[i].WorkerLimit}\nSalary Limit:{_departments[i].SalaryLimit}");
            //}
        }
        public Employee[] GetEmployees(string depName)
        {
            Employee[] Employees = { };
            foreach (Department item in _departments)
            {
                if (item.Name == depName)
                {
                    Employees = item.Employees;
                }
            }
            return Employees;
        }
        public void RemoveEmployee(string empno, string depname)
        {
            for (int i = 0; i < _departments.Length; i++)
            {
                if (_departments[i].Name == depname)
                {
                    for (int j = 0; j < _departments[i].Employees.Length; j++)
                    {
                        if (_departments[i].Employees[j].No == empno)
                        {
                            _departments[i].Employees[j] = _departments[i].Employees[_departments[i].Employees.Length - 1];
                            Array.Resize(ref _departments[i].Employees, _departments[i].Employees.Length - 1);
                            break;
                        }
                    }

                }
            }
        }
        public void EditEmploye(string departmentName, string no, double salary, string position)
        {
            for (int i = 0; i < _departments.Length; i++)
            {
                if (departmentName == _departments[i].Name)
                {
                    for (int j = 0; j < _departments[i].Employees.Length; j++)
                    {
                        if (_departments[i].Employees[j].No == no)
                        {
                            _departments[i].Employees[j].Salary = salary;
                            _departments[i].Employees[j].Position = position;
                        }
                    }
                }
            }
        }
        public bool CheckDepartments(string depname)
        {
            for (int i = 0; i < _departments.Length; i++)
            {
                if (_departments[i].Name == depname)
                {
                    return true;
                }
            }
            return false;
        }
        public void ShowAllEmp()
        {
            Console.Clear();
            for (int i = 0; i < _departments.Length; i++)
            {
                for (int j = 0; j < _departments[i].Employees.Length; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"({i + 1}.{j + 1})\nDepartment Name:{_departments[i].Employees[j].DepartmentName}" +
                        $"\nFull Name:{_departments[i].Employees[j].FullName}\nPosition:{_departments[i].Employees[j].Position}" +
                        $"\nSalary:{_departments[i].Employees[j].Salary}\nNo:{_departments[i].Employees[j].No}");
                    Console.ResetColor();
                }
            }
        }
        public void EmpbyDep(string depName)
        {
            for (int i = 0; i < _departments.Length; i++)
            {
                if (_departments[i].Name == depName)
                {
                    for (int j = 0; j < _departments[i].Employees.Length; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{j + 1}\nFull Name:{_departments[i].Employees[j].FullName}\nPosition:{_departments[i].Employees[j].Position}" +
                        $"\nSalary:{_departments[i].Employees[j].Salary}\nNo:{_departments[i].Employees[j].No}");
                        Console.ResetColor();
                    }
                    break;
                }
            }
        }
        public bool CheckNo(string No)
        {
            for (int i = 0; i < _departments.Length; i++)
            {
                for (int j = 0; j < _departments[i].Employees.Length; j++)
                {
                    if (_departments[i].Employees[j].No == No)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CheckWorkerLimit(string DepName)
        {
            for (int i = 0; i < _departments.Length; i++)
            {
                if (_departments[i].Name == DepName && _departments[i].WorkerLimit == _departments[i].Employees.Length)
                {
                    return false;
                }
            }
            return true;
        }
        public bool CheckSalaryLimit(string DepName, double Salary)
        {
            double sum = 0;
            for (int i = 0; i < _departments.Length; i++)
            {
                if (_departments[i].Name == DepName)
                {
                    for (int j = 0; j < _departments[i].Employees.Length; j++)
                    {
                        sum += _departments[i].Employees[j].Salary;
                    }
                    if (Salary > (_departments[i].SalaryLimit - sum) || (_departments[i].SalaryLimit - sum) < 250)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public double SalarySum(string DepName)
        {
            double sum = 0;
            for (int i = 0; i < _departments.Length; i++)
            {
                if (_departments[i].Name == DepName)
                {
                    for (int j = 0; j < _departments[i].Employees.Length; j++)
                    {
                        sum += _departments[i].Employees[j].Salary;
                    }
                }
            }
            return sum;
        }
        public Department GetDepartment(string DepName)
        {
            foreach (Department item in GetDepartments())
            {
                if (item.Name == DepName)
                {
                    return item;
                }
            }
            return null;
        }
        public Employee GetEmployee(string DepName, string No)
        {

            foreach (Department dep in _departments)
            {
                if (DepName == dep.Name)
                {
                    foreach (Employee item in dep.Employees)
                    {
                        if (item.No == No)
                        {
                            return item;
                        }
                    }
                }
            }
            return null;
        }
    }
}
