using Memento.Model;
using UTs.Executor.BaseUT;
using Xunit.Abstractions;

namespace UTs.Executor
{
    public class Memento : PrintToConsoleUTBase
    {
        private readonly TextWriter _originalOut;
        private readonly TestOutputTextWriter _redirectWriter;

        public Memento(ITestOutputHelper output)
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
            var editor = new TextEditor();
            var history = new History();

            // when
            editor.Type("Hello ");
            history.Backup(editor.Save());

            editor.Type("World!");
            history.Backup(editor.Save());

            Output.WriteLine(editor.Text.Text); // Hello World!

            editor.Restore(history.Undo());
            Output.WriteLine(editor.Text.Text); // Hello 

            editor.Restore(history.Undo());
            Output.WriteLine(editor.Text.Text); // (pusty)

            // then
            Output.WriteLine("Execution completed. Check test output for details.");
        }
    }
}
