using System;

namespace Classes
{
    //A line of credit:
    //Can have a negative balance, but not be greater in absolute value than the credit limit.
    //Will incur an interest charge each month where the end of month balance isn't 0.
    //Will incur a fee on each withdrawal that goes over the credit limit.

    public class CreditAccount : BankAccount
    {
        public CreditAccount (String name, decimal initialBalance, decimal creditLimit) : base (name, initialBalance, -creditLimit)
        {
        
        }

        public override void PerformMonthEndTransactions()
        {
            //Negate the balance to get a positive interest charge
            if (Balance < 0)
            {
                var interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
            }
        

        
            base.PerformMonthEndTransactions();
        }

        //to charge a fee when the withdrawal limit is exceeded:
        #nullable enable
        protected override Transaction? CheckWithdrawalLimit(bool isOverDrawn) =>
        isOverDrawn
        ? new Transaction (-20, DateTime.Now, "Apply Overdraft fee")
        :default;
        
    }
}