using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealedClass2
{

    // Base class
    class BankAccount
    {
        public string AccountNumber { get; }
        public double Balance { get; protected set; }

        public BankAccount(string accountNumber, double initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public virtual void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Balance: {Balance:C}");
        }
    }

    // Sealed derived class
    sealed class SavingsAccount : BankAccount
    {
        private double InterestRate { get; }

        public SavingsAccount(string accountNumber, double initialBalance, double interestRate)
            : base(accountNumber, initialBalance)
        {
            InterestRate = interestRate;
        }

        public void CalculateInterest()
        {
            double interestAmount = Balance * InterestRate / 100;
            Balance += interestAmount;
            Console.WriteLine($"Interest calculated: {interestAmount:C}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount savingsAccount = new SavingsAccount("S12345", 1000.00, 5.0);
            savingsAccount.DisplayAccountInfo();

            savingsAccount.CalculateInterest();
            savingsAccount.DisplayAccountInfo();
        }
    }

}
