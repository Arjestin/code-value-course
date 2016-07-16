using System;
using AccountsLib;

namespace AccountsRun
{
    internal class Program
    {
        private static string ReadInput(string prompt)
        {
            string input = null;
            while (input == null)
            {
                if (prompt != null)
                {
                    Console.Write(prompt);
                }
                input = Console.ReadLine();
                Console.WriteLine();
            }
            return input;
        }

        private static void Main()
        {
            var myAccount = AccountFactory.CreateAccount(1000000);
            Console.WriteLine();
            double sum;
            string input;
            Account account = null;
            while (account == null)
            {
                input = string.Empty;
                while (double.TryParse(input, out sum) == false)
                {
                    input = ReadInput("Enter the initial balance: ");
                }
                account = AccountFactory.CreateAccount(sum);
            }
            var option = 0;
            while (option != 5)
            {
                option = 0;
                Console.WriteLine("What would you like to do with your account?");
                Console.WriteLine("1 - Balance");
                Console.WriteLine("2 - Deposit");
                Console.WriteLine("3 - Withdraw");
                Console.WriteLine("4 - Transfer");
                Console.WriteLine("5 - Exit");
                while (option < 1 || option > 5)
                {
                    input = ReadInput(null);
                    int.TryParse(input, out option);
                }
                switch (option)
                {
                    case 1:
                        Console.WriteLine($"Balance = {account.Balance}.");
                        break;
                    case 2:
                        input = string.Empty;
                        while (double.TryParse(input, out sum) == false)
                        {
                            input = ReadInput("Enter the deposit sum: ");
                        }
                        account.Deposit(sum);
                        break;
                    case 3:
                        input = string.Empty;
                        while (double.TryParse(input, out sum) == false)
                        {
                            input = ReadInput("Enter the withdraw sum: ");
                        }
                        account.Withdraw(sum);
                        break;
                    case 4:
                        input = string.Empty;
                        while (double.TryParse(input, out sum) == false)
                        {
                            input = ReadInput("Enter the transfer sum: ");
                        }
                        account.Transfer(myAccount, sum);
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Error: Wrong option!"); // Just in case :)
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
