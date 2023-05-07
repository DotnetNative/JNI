using JNI.Internal;
using JNI.Models.Global;

namespace JNI.Models.Local;
public unsafe class JObject : HandleEnv
{
    public JObject(Env env, IntPtr addr) : base(env, addr)
    {

    }

    public T ToStruct<T>() where T : struct => Addr.ToStruct<T>();
    public bool IsNull => Addr == IntPtr.Zero;
    public bool InstanceOf(ClassHandle clazz) => Env.IsInstanceOf(this, clazz);
    public JGObject AsGlobal => new JGObject(Env, Addr);

    public static JObject Null => new JObject(null, IntPtr.Zero);

    public static explicit operator IntPtr(JObject obj) => obj.Addr;
}