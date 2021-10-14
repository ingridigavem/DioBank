using DioBank.Domain.Enums;
namespace DioBank.Domain.Accounts {
    public class CheckingAccount : Account {
        private double Fee { get; set; }
        private double CreditLimit { get; set; }

        public CheckingAccount(string holder, int number, TypePerson typePerson, double fee, double creditLimit)
                                : base(holder, number, typePerson) {
            this.Fee = fee;
            this.CreditLimit = creditLimit;
        }

        public override bool Withdrawal(double amount) {

            if (amount <= 0) return false;

            if (amount > this.Balance + this.CreditLimit) return false;

            double withDrawalFee = (amount * (this.Fee / 100.0)) / 2.0;
            Balance -= (amount + withDrawalFee);
            return true;
        }

        public override void Transfer(double amount, Account destinationAccount) {
            if (amount > this.Balance + this.CreditLimit) return;

            if (amount > 0) {
                double transferFee = amount * (this.Fee / 100.0);
                Balance -= (amount + transferFee);
                destinationAccount.Deposit(amount);
            }
        }

        public override string ToString() {
            return base.ToString() + $"\n Fee: {this.Fee}\n Credit Limit: {this.CreditLimit}";
        }
    }
}
