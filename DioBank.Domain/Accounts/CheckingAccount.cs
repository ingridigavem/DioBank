using DioBank.Domain.Enums;
namespace DioBank.Domain.Accounts {
    public class CheckingAccount : Account {
        public double Fee { get; set; }

        public CheckingAccount(string holder, int number, TypePerson typePerson, double fee)
                                : base(holder, number, typePerson) {
            this.Fee = fee;
        }

        public override bool Withdrawal(double amount) {

            if (amount <= 0) return false;

            double withDrawalFee = (amount * (this.Fee / 100.0)) / 2.0;
            Balance -= (amount + withDrawalFee);
            return true;
        }

        public override void Transfer(double amount, Account destinationAccount) {
            if (amount > 0) {
                double transferFee = amount * (this.Fee / 100.0);
                Balance -= (amount + transferFee);
                destinationAccount.Deposit(amount);
            }
        }
    }
}
