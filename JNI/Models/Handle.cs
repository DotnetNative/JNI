namespace JNI.Models;
public class Handle
{
    public Handle(IntPtr addr)
    {
        Addr = addr;
    }

    public IntPtr Addr { get; protected private set; }
    public IntPtr SecondaryAddr { get; protected private set; } = IntPtr.Zero;

    public static explicit operator IntPtr(Handle obj) => obj.Addr;
    public static implicit operator Handle(IntPtr handle) => new Handle(handle);

    public override string ToString()
        => TransformString(Addr.ToInt64().ToString("X")) + (SecondaryAddr != IntPtr.Zero ? TransformString(SecondaryAddr.ToInt64().ToString("X")) : "");

    private static string TransformString(string hex) => "0x" + (string.IsNullOrEmpty(hex) ? "0" : hex);
}