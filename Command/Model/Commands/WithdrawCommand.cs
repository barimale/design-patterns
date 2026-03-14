using Command.Model.Receiver;

namespace Command.Model.Commands
{
    public class WithdrawCommand : ICommand
    {
        private readonly BankAccount _account;
        private readonly int _amount;

        public WithdrawCommand(BankAccount account, int amount)
        {
            _account = account;
            _amount = amount;
        }

        public void Execute() => _account.Withdraw(_amount);
        public void Undo() => _account.Deposit(_amount);
    }

}
