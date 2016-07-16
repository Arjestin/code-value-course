using System;

namespace AccountsLib
{
    public class Account
    {
        internal int Id { get; }
        public double Balance { get; private set; }

        internal Account(int id)
        {
            Id = id;
        }

        public void Deposit(double sum)
        {
            if (sum < 0)
            {
                Console.WriteLine("Error: The deposit sum cannot be less than zero!");
            }
            else
            {
                Balance += sum;
                Console.WriteLine($"Account {Id}: Balance = {Balance}.");
            }
        }

        public void Withdraw(double sum)
        {
            if (sum < 0)
            {
                Console.WriteLine("Error: The withdraw sum cannot be less than zero!");
            }
            else
            {
                var newBalance = Balance - sum;
                if (newBalance < 0)
                {
                    Console.WriteLine("Error: The account cannot go into overdraft!");
                }
                else
                {
                    Balance = newBalance;
                    Console.WriteLine($"Account {Id}: Balance = {Balance}.");
                }
            }
        }

        public void Transfer(Account account, double sum)
        {
            if (sum < 0)
            {
                Console.WriteLine("Error: The transfer sum cannot be less than zero!");
            }
            else
            {
                Withdraw(sum);
                account.Deposit(sum);
            }
        }
    }
}
