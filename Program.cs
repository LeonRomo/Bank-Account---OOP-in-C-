using System;


namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Leon", 1000);
            //Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance");
            account.MakeWithdrawal(500, DateTime.Now, "Rent");
            account.MakeDeposit(750, DateTime.Now, "Salary");
            account.MakeWithdrawal(750, DateTime.Now, "Debt");
            //Console.WriteLine(account.GetAccountHistory());
            //Console.WriteLine($"Current Balance: {account.Balance}");

            var giftCard = new GiftCardAccount("gift card", 100, 50);
            giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
            giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
            giftCard.PerformMonthEndTransactions();
            // can make additional deposits:
            giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
            Console.WriteLine(giftCard.GetAccountHistory());

            var savings = new InterestEarningAccount("savings account", 10000);
            savings.MakeDeposit(750, DateTime.Now, "save some money");
            savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
            savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
            savings.PerformMonthEndTransactions();
            Console.WriteLine(savings.GetAccountHistory());

            var lineOfCredit = new CreditAccount("Credit of Account", 0, 2000);
            //how much is too much to borrow
            lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
            lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back a litte");
            lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency");
            lineOfCredit.MakeWithdrawal(150m, DateTime.Now, "Partial restoration of repairs");
            lineOfCredit.PerformMonthEndTransactions();
            lineOfCredit.GetAccountHistory();
            Console.WriteLine(lineOfCredit.GetAccountHistory());










            // //Test that initial balances must be positive
            // BankAccount invalidAccount;
            // try
            // {
            //     invalidAccount = new BankAccount ("invalid", -55);
            // } 
            // catch (ArgumentOutOfRangeException e)
            // {
            //     Console.WriteLine("Exception caught creating an account with a negative balance");
            //     Console.WriteLine(e.ToString());
            //     return;   
            // }

            // //Test for a negative balance
            // try
            // {
            //     account.MakeWithdrawal(750, DateTime.Now, "Attempt to Withdraw");

            // }

            // catch(InvalidOperationException e)
            // {
            //     Console.WriteLine("Exception caught trying to overdraw");
            //     Console.WriteLine(e.ToString());
            // }





        }
    }
}
