using JNI.Models.Global;
using JNI.Models.Weak;

namespace JNI.Models.Local;
public unsafe class JObject : LHandle
{
    public JObject(Env env, nint addr) : base(env, addr) { }

    public bool IsNull => Addr == nint.Zero;
    public bool InstanceOf(ClassHandle clazz) => Env.Native->IsInstanceOf(Addr, !clazz);
    public ClassHandle GetClass() => new ClassHandle(Env, Env.Native->GetObjectClass(Addr));
    public WeakJObject AsWeak() => new WeakJObject(Env, Addr);
    public bool Equals( JGObject obj) => Env.Native->IsSameObject(Addr, !obj);

    public static JObject Null = new JObject(null, nint.Zero);
    public static explicit operator nint(JObject obj) => obj.Addr;
    public static bool operator ==(JObject a, JObject b) => a.Env.Native->IsSameObject(!a, !b);
    public static bool operator !=(JObject a, JObject b) => !a.Env.Native->IsSameObject(!a, !b);
    public static nint operator !(JObject obj) => obj.Addr;
}