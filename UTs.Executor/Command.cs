using Command.Model.Commands;
using Command.Model.Invoker;
using Command.Model.Receiver;
using Composite;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class Command : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public Command(ITestOutputHelper output)
            : base(output)
        {
            _originalOut = Console.Out;
            _redirectWriter = new TestOutputTextWriter(output);
            Console.SetOut(_redirectWriter);
        }

        [Fact]
        public void Execute()
        {
            // given
            var account = new BankAccount();
            var manager = new CommandManager();

            // when
            manager.Execute(new DepositCommand(account, 100));
            manager.Execute(new WithdrawCommand(account, 40));

            Output.WriteLine($"Stan konta przed undo: {account.Balance}");

            manager.Undo(); // cofa wypłatę 40
            manager.Undo(); // cofa wpłatę 100

            Output.WriteLine($"Stan konta po undo: {account.Balance}");

            // then
            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
