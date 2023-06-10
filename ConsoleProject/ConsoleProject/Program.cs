using ConsoleProject.Interfaces;

namespace ConsoleProject
{
    class Program
    {
        public static void ShowAllDep(IHumanResourceManager humanResourceManager)
        {
            for (int i = 0; i < humanResourceManager.GetDepartments().Length; i++)
            {
                Console.WriteLine($"{i + 1}:\nName:{humanResourceManager.GetDepartments()[i].Name}" +
                    $"\nEmployee count:{humanResourceManager.GetDepartments()[i].Employees.Length}" +
                    $"\nAverage salary:{humanResourceManager.GetDepartments()[i].CalcSalaryAverage()}");

            }
        }

        public static void AddDep(ref IHumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Insert the name of a Department:");
            string name = Console.ReadLine();
            while (name.Length < 2)
            {
                Console.WriteLine("Department name cant be less than 2 characters");
                name = Console.ReadLine();

            }
            Console.WriteLine("Insert the Worker Limit:");
            int workerlimit = int.Parse(Console.ReadLine());
            string str = workerlimit.ToString();
            while (workerlimit < 1 || !int.TryParse(str, out workerlimit))
            {
                Console.WriteLine("Cant be less than \"1\" and should be a number");
                workerlimit = int.Parse(Console.ReadLine());

            }

            Console.WriteLine("Insert the Salary Limit:");
            double SalaryLimit = double.Parse(Console.ReadLine());
            string str1 = SalaryLimit.ToString();
            while (SalaryLimit < 250 || !double.TryParse(str1, out SalaryLimit))
            {
                Console.WriteLine("Cant be less than \"250\" and should be an amount");
                SalaryLimit = double.Parse(Console.ReadLine());
            }
            humanResourceManager.AddDepartment(name, workerlimit, SalaryLimit);
        }

        public static void DepEdit(ref IHumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Insert the Department name:");
            string depName = Console.ReadLine();
            if (!humanResourceManager.CheckDepartments(depName))
            {
                Console.WriteLine("This department name does not exist!!!");
                return;
            }

            foreach (Department dep in humanResourceManager.GetDepartments())
            {
                if (dep.Name == depName)
                {
                    Console.WriteLine(dep.ToString() + "\n");
                }
            }


            Console.WriteLine("Insert the new name of a Department:");
            string Name = Console.ReadLine();
            while (Name.Length < 2)
            {
                Console.WriteLine("Department name cant be less than 2 characters");
                Name = Console.ReadLine();

            }
            Console.WriteLine("Insert the new Worker Limit:");
            int Workerlimit = int.Parse(Console.ReadLine());
            string str = Workerlimit.ToString();
            while (Workerlimit < 1 || !int.TryParse(str, out Workerlimit))
            {
                Console.WriteLine("Cant be less than \"1\" and should be a number");
                Workerlimit = int.Parse(Console.ReadLine());

            }

            Console.WriteLine("Insert the new Salary Limit:");
            double SalaryLimit = double.Parse(Console.ReadLine());
            string str1 = SalaryLimit.ToString();
            while (SalaryLimit < 250 || !double.TryParse(str1, out SalaryLimit))
            {
                Console.WriteLine("Cant be less than \"250\" and should be an amount");
                SalaryLimit = double.Parse(Console.ReadLine());
            }
            humanResourceManager.EditDepartaments(depName, Name, Workerlimit, SalaryLimit);
        }

        public static void AddEmp(ref IHumanResourceManager humanResourceManager)
        {
        nameins:
            Console.WriteLine("Insert the full name of an employee:");
            string Name = Console.ReadLine();
            int count = 0;
            if (String.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Invalid name(Example:Abbas Abbasov)");
                goto nameins;
            }
            foreach (string item in Name.Split(" "))
            {
                count++;
                if (!char.IsUpper(item[0]))
                {
                    Console.WriteLine("Invalid name(Example:Abbas Abbasov)");
                    goto nameins;
                }
            }
            if (count < 2)
            {
                Console.WriteLine("Invalid name(Example:Abbas Abbasov)");
                goto nameins;
            }

            Console.WriteLine("Insert Employee's Position:");
            string Position = Console.ReadLine();
            while (Position.Length < 2)
            {
                Console.WriteLine("Position name cant be less than 2 characters");
                Position = Console.ReadLine();
            }
        insSalary:
            Console.WriteLine("Insert Employee's Salary:");
            string strSalary = Console.ReadLine();
            if (!double.TryParse(strSalary, out double Salary))
            {
                Console.WriteLine("Invalid insert!!!");
                goto insSalary;
            }
            while (Salary < 250)
            {
                Console.WriteLine("Salary cant be less than 250");
                Salary = double.Parse(Console.ReadLine());
            }
        insDepName:
            Console.WriteLine("Insert Employee's Department name:");
            string DepName = Console.ReadLine();
            if (!humanResourceManager.CheckDepartments(DepName))
            {
                Console.WriteLine("This department name does not exist!!!");
                goto insDepName;
            }

            humanResourceManager.AddEmployee(Name, Position, Salary, DepName);

        }

        public static void ShowAllEmpbyDep(IHumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Insert the name of depatment:");
            string DepName = Console.ReadLine();
            bool check = humanResourceManager.CheckDepartments(DepName);
            if (!check)
            {
                Console.WriteLine("This department name does not exist!!!");
                return;
            }
            humanResourceManager.EmpbyDep(DepName);
        }

        public static void EditEmp(ref IHumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Insert the Number of the employee:");
            string No = Console.ReadLine();
            if (!humanResourceManager.CheckNo(No))
            {
                Console.WriteLine("Invalid Number!!!");
                return;
            }
        nameins:
            Console.WriteLine("Insert the new full name of an employee:");
            string Name = Console.ReadLine();
            int count = 0;
            if (String.IsNullOrWhiteSpace(Name))
            {
                Console.WriteLine("Invalid name(Example:Abbas Abbasov)");
                goto nameins;
            }
            foreach (string item in Name.Split(" "))
            {
                count++;
                if (!char.IsUpper(item[0]))
                {
                    Console.WriteLine("Invalid name(Example:Abbas Abbasov)");
                    goto nameins;
                }
            }
            if (count < 2)
            {
                Console.WriteLine("Invalid name(Example:Abbas Abbasov)");
                goto nameins;
            }

            Console.WriteLine("Insert new Employee's Position:");
            string Position = Console.ReadLine();
            while (Position.Length < 2)
            {
                Console.WriteLine("Position name cant be less than 2 characters");
                Position = Console.ReadLine();
            }
        insSalary:
            Console.WriteLine("Insert Employee's new Salary:");
            string strSalary = Console.ReadLine();
            if (!double.TryParse(strSalary, out double Salary))
            {
                Console.WriteLine("Invalid insert!!!");
                goto insSalary;
            }
            while (Salary < 250)
            {
                Console.WriteLine("Salary cant be less than 250");
                Salary = double.Parse(Console.ReadLine());
            }
        insDepName:
            Console.WriteLine("Insert Employee's new Department name:");
            string DepName = Console.ReadLine();
            if (!humanResourceManager.CheckDepartments(DepName))
            {
                Console.WriteLine("This department name does not exist!!!");
                goto insDepName;
            }

            humanResourceManager.EditEmploye(DepName, No, Name, Salary, Position);
        }
        public static void RemoveEmp(ref IHumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Insert the Department name:");
            string depName = Console.ReadLine();
            if (!humanResourceManager.CheckDepartments(depName))
            {
                Console.WriteLine("This department name does not exist!!!");
                return;
            }
            Console.WriteLine("Insert the Number of the employee:");
            string No = Console.ReadLine();
            if (!humanResourceManager.CheckNo(No))
            {
                Console.WriteLine("Invalid Number!!!");
                return;
            }
            humanResourceManager.RemoveEmployee(No, depName);
        }
        public static void Main(string[] args)
        {
            IHumanResourceManager humanResourceManager = new HumanResourceManager();
            do
            {
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
                    Console.WriteLine("invalid input!!!");
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
