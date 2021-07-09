using System; 

namespace Classes
{
    public class InterestEarningAccount : BankAccount
    {
        public InterestEarningAccount (String name, decimal initialBalance) : base (name, initialBalance)
        {
            //this constructor inherists from the base class construstor in the Bank Acount file
        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500m)
            {
                var interest = Balance * 0.05m;
                MakeDeposit(interest, DateTime.Now, "Apply monthly interest");
            }
            base.PerformMonthEndTransactions(); 
        }
    }
}
