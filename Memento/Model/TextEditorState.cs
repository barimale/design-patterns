namespace Memento.Model
{
    public class TextEditorState
    {
        public string Text { get; set; } = "";

        public TextEditorState(string text)
        {
            Text = text;
        }

        public static TextEditorState Empty => new TextEditorState(string.Empty);
    }
}
