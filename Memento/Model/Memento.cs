namespace Memento.Model
{
    public class Memento
    {
        public TextEditorState State { get; }

        public Memento(TextEditorState state)
        {
            State = state;
        }
    }
}
