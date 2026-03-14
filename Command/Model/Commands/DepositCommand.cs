using Command.Model.Receiver;

namespace Command.Model.Commands
{
    public class DepositCommand : ICommand
    {
        private readonly BankAccount _account;
        private readonly int _amount;

        public DepositCommand(BankAccount account, int amount)
        {
            _account = account;
            _amount = amount;
        }

        public void Execute() => _account.Deposit(_amount);
        public void Undo() => _account.Withdraw(_amount);
    }

}
