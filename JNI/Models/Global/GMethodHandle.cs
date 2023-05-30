namespace JNI.Models.Global;
public class GMethodHandle : GHandle
{
    public GMethodHandle(nint gAddr, nint lAddr) : base(gAddr, lAddr) { }
}