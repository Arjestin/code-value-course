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

        //Should throw an exception or return bool. Printing a console message isn't good.
        //How would you know whether it failed or not? How will you test it using UnitTests?
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

        //The same as above
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

        //Same as above
        public void Transfer(Account account, double sum)
        {
            if (sum < 0)
            {
                Console.WriteLine("Error: The transfer sum cannot be less than zero!");
            }
            else
            {
                //Nice.
                Withdraw(sum);
                account.Deposit(sum);
            }
        }
    }
}
