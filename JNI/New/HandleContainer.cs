
namespace JNI.New;
public class HandleContainer : Handle
{
    public Handle Handle;
    public bool IsGlobal => Handle is GEnvHandle;

    public override nint Addr { get => Handle.Addr; set => Handle.Addr = value; }
}