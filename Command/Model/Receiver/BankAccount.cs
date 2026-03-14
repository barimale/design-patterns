using System;
using System.Collections.Generic;
using System.Text;

namespace Command.Model.Receiver
{
    public class BankAccount
    {
        public int Balance { get; private set; }

        public void Deposit(int amount)
        {
            Balance += amount;
            Console.WriteLine($"Wpłacono {amount}. Stan konta: {Balance}");
        }

        public void Withdraw(int amount)
        {
            Balance -= amount;
            Console.WriteLine($"Wypłacono {amount}. Stan konta: {Balance}");
        }
    }

}
