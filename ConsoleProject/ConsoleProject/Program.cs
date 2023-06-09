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
            Department department = new Department();
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
            humanResourceManager.AddDepartment(name, workerlimit, SalaryLimit,department);
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
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                }
            } while (true);
        }
    }
}
