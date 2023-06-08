namespace ConsoleProject
{
    class Program
    {
        public static void Main(string[] args)
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
                    break; 
                case 2:
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
        }
    }
}
