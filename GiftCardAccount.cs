using System;

namespace Classes
{
    //A gift card account:
    //Can be refilled with a specified amount once each month, on the last day of the month.

    public class GiftCardAccount : BankAccount
    {
        private decimal _monthlyDeposit = 0m;

        public GiftCardAccount(String name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance)
        => _monthlyDeposit = monthlyDeposit;


        public override void PerformMonthEndTransactions()
        {
            if (_monthlyDeposit != 0)
            {
                MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
            }
            base.PerformMonthEndTransactions();
        }
    }
}