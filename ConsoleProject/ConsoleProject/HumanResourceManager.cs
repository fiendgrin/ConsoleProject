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
        private static Department[] _departments;

        public Department[] Departments
        {
            get { return _departments; }

        }
        public HumanResourceManager()
        {
            _departments = new Department[0];
        }

        public void AddDepartment(string name, int workerlimit, double SalaryLimit)
        {
            int size = Departments.Length;
            Department department = new Department();
            department.Name = name;
            department.WorkerLimit = workerlimit;
            department.SalaryLimit = SalaryLimit;
            Array.Resize(ref _departments, size + 1);
            Departments[size - 1] = department;
        }

        public void AddEmployee(string fullName, string position, double salary, string departmentName, ref Employee[] employees)
        {
            int size = employees.Length;
            Employee employee = new Employee();
            employee.FullName = fullName;
            employee.Position = position;
            employee.Salary = salary;
            employee.DepartmentName = departmentName;
            Array.Resize(ref employees, size + 1);
            employees[size - 1] = employee;
        }

        public void EditDepartaments(string name, string newname)
        {
            foreach (Department item in Departments)
            {
                if (item.Name == name)
                {
                    item.Name = newname;
                    break;
                }
            }
        }

        public void GetDepartments()
        {
            for (int i = 0; i < _departments.Length; i++)
            {
                Console.WriteLine($"{i + 1}:\nName:{_departments[i].Name}\nWorker Limit:{_departments[i].WorkerLimit}\nSalary Limit:{_departments[i].SalaryLimit}");
            }
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
            throw new NotImplementedException();
        }
        public static bool CheckDepartments(string depname)
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
