using BankProject.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankProject
{
	public class Account
	{
		public Guid AccountNumber { get; set; }
		public string OwnerName { get; set; }
		private double _balance;
		public double Balance
		{
			get
			{
				return _balance;
			}
			set
			{
				_balance = value;
			}
		}
		public List<Transaction> Transactions = new List<Transaction>();
        public Account(string OwnerName,double InitialBalance)
        {
			AccountNumber = Guid.NewGuid();
			this.OwnerName = OwnerName;
			this.Balance = InitialBalance;
            Console.WriteLine("Succesfully created");
        }

        public void MakeWithDraw(double amount)
		{
            if (amount <= 0)
                throw new InvalidMoneyException($"You cannot deposit {amount}$ in your account");

            Transaction transaction = new();
			transaction.Amount = amount;
			
			transaction.CreateAt = DateTime.Now;
			if (amount > Balance)
			{
				transaction.Description = "You don`t have enough money in your balance";
				Transactions.Add(transaction);
				throw new InsufficientFundsException();
			}
			transaction.Description = $"You withdraw {amount}$. Your current balance {Balance}$";
			Balance -= amount;
			
			Transactions.Add(transaction);
        }
		public void MakeDeposit(double amount)
		{
			if (amount <= 0) 
				throw new InvalidMoneyException($"You cannot deposit {amount}$ in your account");

			Balance += amount;

			Transaction transaction = new Transaction();
			transaction.Amount = amount;
			transaction.Description = $"You deposit {amount}$. Your current balance {Balance}$";
			transaction.CreateAt = DateTime.Now;
			Transactions.Add(transaction);
		}
		public void ShowBalance()
			=> Console.WriteLine($"Your Balance {Balance}$");

		public void ShowTransactions()
		{
			foreach (Transaction transaction in Transactions)
			{
                Console.WriteLine($"Amount:{transaction.Amount} Date:{transaction.CreateAt}  Desc:{transaction.Description}");
            }
		}

	}
}
