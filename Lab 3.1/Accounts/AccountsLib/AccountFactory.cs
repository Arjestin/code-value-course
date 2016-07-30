using System;

namespace AccountsLib
{
    public static class AccountFactory
    {
        private static int _id;

        public static Account CreateAccount(double sum)
        {
            //Shouldn't this be handled at deposite?
            if (sum < 0)
            {
                Console.WriteLine("Error: The initial balance cannot be less than zero!");
                return null;
            }
            ++_id;
            var account = new Account(_id);
            account.Deposit(sum);
            return account;
        }
    }
}
