using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleProject.Models;

namespace ConsoleProject.Interfaces
{
    internal interface IHumanResourceManager
    {
        Department[] Departments { get; }
        void AddDepartment(string name, int workerlimit, double SalaryLimit);
        Department[] GetDepartments();
        void EditDepartaments(string name, string newname, int workerlimit, double salarylimit);
        void AddEmployee(string fullName, string position, double salary, string departmentName);
        void RemoveEmployee(string empno, string depname);
        void EditEmploye(string departmentName, string no, double salary, string position);
        bool CheckDepartments(string depname);
        void ShowAllEmp();
        void EmpbyDep(string depName);
        bool CheckNo(string No);
        bool CheckWorkerLimit(string DepName);
        bool CheckSalaryLimit(string DepName, double Salary);
        Employee[] GetEmployees(string depName);
        double SalarySum(string DepName);
        Department GetDepartment(string DepName);
        Employee GetEmployee(string DepName, string No);
    }
}
