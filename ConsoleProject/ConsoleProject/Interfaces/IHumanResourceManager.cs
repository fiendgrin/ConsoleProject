using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Interfaces
{
    internal interface IHumanResourceManager
    {
        Department[] Departments { get; }
        public void AddDepartment(string name, int workerlimit, double SalaryLimit);
        public void GetDepartments(Department[] departments);
        public string EditDepartaments(string name);
        public void AddEmployee(string No, string FullName, string Position, double Salary, string DepartmentName);
    }
}
