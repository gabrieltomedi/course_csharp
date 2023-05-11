
namespace Inheritance3.Entities
{
    internal class Account
    {
        public int Number { get; private set; }
        public string Holder { get; private set; }
        public double Balance { get; protected set; }

        public Account()
        {

        }

        public Account(int number, string holder, double balance)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
        }

        //using vitual so it can be override in the subclass
        public virtual void Withdraw(double amount)
        {
            Balance -= amount + 5.0;  
        }

        public void Deposite(double amount)
        {
            Balance += amount;
        }

    }
}
