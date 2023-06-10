using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleProject.Interfaces;

namespace ConsoleProject
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
        public void RemoveEmployee(string empno, string depname)
        {
        check:
            if (CheckDepartments(depname))
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
                            }
                        }

                    }
                }


            }
            else
            {
                Console.WriteLine("this department name doesnt exist");
                depname = Console.ReadLine();
                goto check;
            }
        }
        public void EditEmploye(string departmentName, string no, string fullname, double salary, string position)
        {            
            for (int i = 0; i < _departments.Length; i++)
            {
                if (departmentName == _departments[i].Name)
                {
                    for (int j = 0; j < _departments[i].Employees.Length; j++)
                    {
                        if (_departments[i].Employees[j].No == no)
                        {
                            _departments[i].Employees[j].FullName = fullname;
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

        
    }
}
