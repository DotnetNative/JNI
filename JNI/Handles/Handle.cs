namespace JNI;
public unsafe abstract class Handle
{
    public abstract nint Addr { get; set; }

    public static implicit operator nint(Handle val) => val.Addr;
    public static implicit operator void*(Handle val) => (void*)val.Addr;
}