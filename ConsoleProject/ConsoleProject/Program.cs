using ConsoleProject.Interfaces;
using ConsoleProject.Models;
using ConsoleProject.Services;
using System.Runtime.Intrinsics.X86;

namespace ConsoleProject
{
    class Program
    {
        public static void ShowAllDep(IHumanResourceManager humanResourceManager)
        {
            Console.Clear();
            for (int i = 0; i < humanResourceManager.GetDepartments().Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{i + 1}:\nName:{humanResourceManager.GetDepartments()[i].Name}" +
                    $"\nEmployee count:{humanResourceManager.GetDepartments()[i].Employees.Length}" +
                    $"\nAverage salary:{humanResourceManager.GetDepartments()[i].CalcSalaryAverage()}");
                Console.ResetColor();
            }
        }

        public static void AddDep(ref IHumanResourceManager humanResourceManager)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Insert the name of a Department:");
            Console.ResetColor();
            string name = Console.ReadLine();
            while (name.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Department name cant be less than 2 characters!!!");
                Console.ResetColor();
                name = Console.ReadLine();

            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Insert the Worker Limit:");
            Console.ResetColor();
            string strWorLim = Console.ReadLine();
            int workerlimit;
            while (!int.TryParse(strWorLim, out workerlimit) || workerlimit < 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Cant be less than \"1\" and should be a number!!!");
                Console.ResetColor();
                strWorLim = Console.ReadLine();

            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Insert the Salary Limit:");
            Console.ResetColor();
            string strSalLim = Console.ReadLine();
            double SalaryLimit;
            while (!double.TryParse(strSalLim, out SalaryLimit) || SalaryLimit < 250)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Cant be less than \"250\" and should be an amount!!!");
                Console.ResetColor();
                strSalLim = Console.ReadLine();
            }
            humanResourceManager.AddDepartment(name, workerlimit, SalaryLimit);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Department succesfully added!");
            Console.ResetColor();
        }

        public static void DepEdit(ref IHumanResourceManager humanResourceManager)
        {
            Console.Clear();
            if (humanResourceManager.GetDepartments().Length < 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No Departments exist !!!");
                Console.ResetColor();
                return;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Insert the Department name:");
            Console.ResetColor();
            string depName = Console.ReadLine();
            if (!humanResourceManager.CheckDepartments(depName))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("This department name does not exist!!!");
                Console.ResetColor();
                return;
            }

            foreach (Department dep in humanResourceManager.GetDepartments())
            {
                if (dep.Name == depName)
                {
                    Console.WriteLine(dep.ToString());
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Insert the new name of a Department:");
            Console.ResetColor();
            string Name = Console.ReadLine();
            while (Name.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Department name can't be less than 2 characters!!!");
                Console.ResetColor();
                Name = Console.ReadLine();

            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Insert the new Worker Limit:");
            Console.ResetColor();
        editWorkerLim:
            string str = Console.ReadLine();
            int Workerlimit;
            while (!int.TryParse(str, out Workerlimit) || Workerlimit < 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Can't be less than \"1\" and should be a number!!!");
                Console.ResetColor();
                str = Console.ReadLine();

            }
            if (humanResourceManager.GetEmployees(depName).Length > Workerlimit)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Worker limit cant be less that the amount of existing workers!!!");
                Console.ResetColor();
                goto editWorkerLim;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Insert the new Salary Limit:");
            Console.ResetColor();
        EditSalaryLim:
            string str1 = Console.ReadLine();
            double SalaryLimit;
            while (!double.TryParse(str1, out SalaryLimit) || SalaryLimit < 250)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Can't be less than \"250\" and should be an amount");
                Console.ResetColor();
                str1 = Console.ReadLine();
            }
            if (humanResourceManager.SalarySum(depName) > SalaryLimit)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Salary Limit can't be less than summary of salarys in department");
                Console.ResetColor();
                goto EditSalaryLim;
            }

            humanResourceManager.EditDepartaments(depName, Name, Workerlimit, SalaryLimit);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Department succesfully edited!");
            Console.ResetColor();
        }

        public static void AddEmp(ref IHumanResourceManager humanResourceManager)
        {
            Console.Clear();
            if (humanResourceManager.GetDepartments().Length < 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No Departments exist !!!");
                Console.ResetColor();
                return;
            }

        insDepName:
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Insert Employee's Department name:");
            Console.ResetColor();
            string DepName = Console.ReadLine();
            if (!humanResourceManager.CheckWorkerLimit(DepName))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Worker Limit is reached in this department!!!");
                Console.ResetColor();
                return;
            }
            if (!humanResourceManager.CheckDepartments(DepName))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("This department name does not exist!!!");
                Console.ResetColor();
                goto insDepName;
            }
        insSalary:
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Insert Employee's Salary:");
            Console.ResetColor();
            string strSalary = Console.ReadLine();
            if (!double.TryParse(strSalary, out double Salary))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid insert!!!");
                Console.ResetColor();
                goto insSalary;
            }
            while (Salary < 250)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Salary cant be less than 250!!!");
                Console.ResetColor();
                Salary = double.Parse(Console.ReadLine());
            }
            if (!humanResourceManager.CheckSalaryLimit(DepName, Salary))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Salary Limit Overflow!!!");
                Console.ResetColor();
                return;
            }
        nameins:
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Insert the full name of an employee:");
            Console.ResetColor();
            string Name = Console.ReadLine();
            int count = 0;
            if (String.IsNullOrWhiteSpace(Name))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid name(Example:Abbas Abbasov)!!!");
                Console.ResetColor();
                goto nameins;
            }
            foreach (string item in Name.Split(" "))
            {
                count++;
                if (!char.IsUpper(item[0]))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid name(Example:Abbas Abbasov)!!!");
                    Console.ResetColor();
                    goto nameins;
                }
            }
            if (count < 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid name(Example:Abbas Abbasov)!!!");
                Console.ResetColor();
                goto nameins;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Insert Employee's Position:");
            Console.ResetColor();
            string Position = Console.ReadLine();
            while (Position.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Position name cant be less than 2 characters!!!");
                Console.ResetColor();
                Position = Console.ReadLine();
            }


            humanResourceManager.AddEmployee(Name, Position, Salary, DepName);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Employee succesfully added!");
            Console.ResetColor();
        }

        public static void ShowAllEmpbyDep(IHumanResourceManager humanResourceManager)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Insert the name of depatment:");
            Console.ResetColor();
            string DepName = Console.ReadLine();
            bool check = humanResourceManager.CheckDepartments(DepName);
            if (!check)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("This department name does not exist!!!");
                Console.ResetColor();
                return;
            }
            Console.Clear();
            humanResourceManager.EmpbyDep(DepName);
        }

        public static void EditEmp(ref IHumanResourceManager humanResourceManager)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Insert the Number of the employee:");
            Console.ResetColor();
            string No = Console.ReadLine();
            if (!humanResourceManager.CheckNo(No))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid Number!!!");
                Console.ResetColor();
                return;
            }

        insDepName:
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Insert Employee's Department name:");
            Console.ResetColor();
            string DepName = Console.ReadLine();
            if (!humanResourceManager.CheckDepartments(DepName))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("This department name does not exist!!!");
                Console.ResetColor();
                goto insDepName;
            }           
            foreach (Department dep in humanResourceManager.GetDepartments())
            {
                if (dep.Name == DepName)
                {
                    foreach (Employee item in dep.Employees)
                    {
                        if (item.No == No)
                        {                            
                            Console.WriteLine(item.ToString());
                        }
                    }
                }
            }
        insSalary:
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Insert Employee's new Salary:");
            Console.ResetColor();
            string strSalary = Console.ReadLine();
            if (!double.TryParse(strSalary, out double Salary))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid insert!!!");
                Console.ResetColor();
                goto insSalary;
            }
            while (Salary < 250)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Salary cant be less than 250!!!");
                Console.ResetColor();
                Salary = double.Parse(Console.ReadLine());
            }
            if (humanResourceManager.SalarySum(DepName) - humanResourceManager.GetEmployee(DepName,No).Salary + Salary > humanResourceManager.GetDepartment(DepName).SalaryLimit)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Salary Limit Overflow!!!");
                Console.ResetColor();
                goto insSalary;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Insert new Employee's Position:");
            Console.ResetColor();
            string Position = Console.ReadLine();
            while (Position.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Position name cant be less than 2 characters!!!");
                Console.ResetColor();
                Position = Console.ReadLine();
            }


            humanResourceManager.EditEmploye(DepName, No, Salary, Position);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Employee succesfully edited!");
            Console.ResetColor();
        }
        public static void RemoveEmp(ref IHumanResourceManager humanResourceManager)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Insert the Department name:");
            Console.ResetColor();
            string depName = Console.ReadLine();
            if (!humanResourceManager.CheckDepartments(depName))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("This department name does not exist!!!");
                Console.ResetColor();
                return;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Insert the Number of the employee:");
            Console.ResetColor();
            string No = Console.ReadLine();
            if (!humanResourceManager.CheckNo(No))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid Number!!!");
                Console.ResetColor();
                return;
            }
            humanResourceManager.RemoveEmployee(No, depName);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Employee succesfully removed!");
            Console.ResetColor();
        }
        public static void Main(string[] args)
        {
            IHumanResourceManager humanResourceManager = new HumanResourceManager();
            do
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("1 - Show all departments");
                Console.WriteLine("2 - Add department");
                Console.WriteLine("3 - Edit department");
                Console.WriteLine("4 - Show all employees");
                Console.WriteLine("5 - Show all employees in a department");
                Console.WriteLine("6 - Add employee");
                Console.WriteLine("7 - Edit employee");
                Console.WriteLine("8 - Remove employee");
                Console.WriteLine("=========================================");
            check1:
                Console.Write("Choose one of the options above(1-8):");
                string option = Console.ReadLine();
                if (!int.TryParse(option, out int op) || op > 8 || op < 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("invalid input!!!");
                    Console.ResetColor();
                    goto check1;
                }
                switch (op)
                {
                    case 1:
                        ShowAllDep(humanResourceManager);
                        break;
                    case 2:
                        AddDep(ref humanResourceManager);
                        break;
                    case 3:
                        DepEdit(ref humanResourceManager);
                        break;
                    case 4:
                        humanResourceManager.ShowAllEmp();
                        break;
                    case 5:
                        ShowAllEmpbyDep(humanResourceManager);
                        break;
                    case 6:
                        AddEmp(ref humanResourceManager);
                        break;
                    case 7:
                        EditEmp(ref humanResourceManager);
                        break;
                    case 8:
                        RemoveEmp(ref humanResourceManager);
                        break;
                }
            } while (true);
        }
    }
}
