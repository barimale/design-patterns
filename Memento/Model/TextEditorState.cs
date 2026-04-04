namespace Memento.Model
{
    public class TextEditorState
    {
        public string Text { get; set; } = "";

        public TextEditorState(string text)
        {
            Text = text;
        }

        public static TextEditorState Empty()
        {
            return new TextEditorState(string.Empty);
        }
    }
}
