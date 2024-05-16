namespace JNI;
public class MessageBoxException : Exception
{
    [DllImport("user32", CharSet = CharSet.Auto)]public static extern
        int MessageBox(nint hWnd, string text, string caption, uint type);

    public MessageBoxException(string message) : base(message)
    {
        MessageBox(0, message, "", 0);
    }
}