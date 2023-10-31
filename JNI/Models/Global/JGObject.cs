using JNI.Models.Local;

namespace JNI.Models.Global;
public unsafe class JGObject : GHandle
{
    public JGObject(nint gAddr, nint lAddr) : base(gAddr, lAddr) { }

    public bool IsNull => LocalAddr == nint.Zero || Addr == nint.Zero;
    public bool InstanceOf(Env env, ClassHandle clazz) => env.Native->IsInstanceOf(Addr, !clazz);
    public ClassHandle GetClass(Env env) => new(env, env.Native->GetObjectClass(Addr));
    public GClassHandle GetGlobalClass(Env env)
    {
        var cls = env.Native->GetObjectClass(Addr);
        return new GClassHandle(env.NewGlobalRef(cls), cls);
    }
    public WeakJObject AsWeak(Env env) => new(env, Addr);
    public bool Equals(Env env, JGObject obj) => env.Native->IsSameObject(Addr, !obj);

    public static JGObject Null => new(nint.Zero, nint.Zero);
    public static explicit operator nint(JGObject obj) => obj.Addr;
}
