namespace Memento.Model
{
    public class TextEditor
    {
        public TextEditorState Text { get; private set; } = TextEditorState.Empty();

        public void Type(string newText)
        {
            Text.Text += newText;
        }

        public Memento Save()
        {
            return new Memento(Text);
        }

        public void Restore(Memento memento)
        {
            Text = memento.State;
        }
    }
}
