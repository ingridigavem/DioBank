using System.Globalization;
using DioBank.Domain.Enums;
namespace DioBank.Domain.Accounts {
    public abstract class Account {
        protected string Holder { get; set; }
        protected double Balance { get; set; }
        protected TypePerson TypePerson { get; set; }
        public int Number { get; protected set; }

        protected Account(string holder, int number, TypePerson typePerson) {
            this.Holder = holder;
            this.Number = number;
            this.TypePerson = typePerson;
            this.Balance = 0;
        }

        public bool Deposit(double amount) {
            if (amount <= 0) return false;

            this.Balance += amount;
            return true;
        }

        public override string ToString() {
            return $" Holder: {Holder}\n Number: {Number}\n Type Person: {TypePerson}\n Balance: {Balance.ToString("F2", CultureInfo.InvariantCulture)}";
        }
        public abstract bool Withdrawal(double amount);
        public abstract void Transfer(double amount, Account destinationAccount);
    }
};

