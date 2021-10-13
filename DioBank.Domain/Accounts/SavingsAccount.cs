using DioBank.Domain.Enums;

namespace DioBank.Domain.Accounts {
    public class SavingsAccount : Account {
        public SavingsAccount(string holder, int number, TypePerson typePerson)
                                : base(holder, number, typePerson) {
        }

        public override bool Withdrawal(double amount) {
            if (amount <= 0) return false;

            Balance -= amount;
            return true;
        }
        public override void Transfer(double amount, Account destinationAccount) {
            this.Withdrawal(amount);
            destinationAccount.Deposit(amount);

        }


    }
}
