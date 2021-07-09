using System;
using System.Collections.Generic;

namespace Classes
{
    public class BankAccount
    {
        private static int accountNumberSeed = 1234567890;
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;

                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }


        //creating a constructor that calls the other main constructor. Something called constructor chaining
        private readonly decimal minimalBalance; //the value cannot be changed after the object is constructed
        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

        public BankAccount(string name, decimal initialBalance, decimal minimalBalance)
        {
            this.Owner = name;
            this.minimalBalance = minimalBalance;
            if (initialBalance > 0)
            {
                MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
            }


            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

        }

        private List<Transaction> allTransactions = new List<Transaction>();

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount deposit must be greater than 0");
            }

            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be greater than 0");
            }

            var overdraftTransaction = CheckWithdrawalLimit(Balance - amount < minimalBalance);
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);

            if (overdraftTransaction != null)
            {
                allTransactions.Add(overdraftTransaction);
            }


        }
        
        #nullable enable
        protected virtual Transaction? CheckWithdrawalLimit(bool isOverDrawn)
        {
            if (isOverDrawn)
            {
                throw new InvalidOperationException("Not sufficient funds to carry out the transaction");
            }
            else
            {
                return default;
            }
        }

        public String GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");

            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Note}");

            }

            return report.ToString();
        }

        public virtual void PerformMonthEndTransactions()
        {
            //this method is here because other classes can reimplement it using the keyword  Overide
            //heading over to the InterestEarningAccount, we will see the implementation
        }



    }
}