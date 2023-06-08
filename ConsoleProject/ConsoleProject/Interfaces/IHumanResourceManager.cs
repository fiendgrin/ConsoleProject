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
        void AddDepartment(string name, int workerlimit, double SalaryLimit,Department department);
        Department[] GetDepartments();
        void EditDepartaments(string name, string newname);
        void AddEmployee(string fullName, string position, double salary, string departmentName);
        void RemoveEmployee(string empno, string depname);
        void EditEmploye(string departmentName, string no, string fullname, double salary, string position);
    }
}
