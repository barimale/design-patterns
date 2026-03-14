namespace Memento.Model
{
    public class TextEditor
    {
        public string Text { get; private set; } = "";

        public void Type(string newText)
        {
            Text += newText;
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
