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
        private  Department[] _departments;

        public  Department[] Departments
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

        public void AddEmployee(string no, string fullName, string position, double salary, string departmentName,ref Employee[] employees)
        {
            int size = employees.Length;
            Employee employee = new Employee();
            employee.No = no;
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

        public Department[] GetDepartments()
        {
            return _departments;
        }
    }
}
