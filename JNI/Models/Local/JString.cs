using JNI.Internal;
using System.Text;

namespace JNI.Models.Local;
public unsafe class JString : JObject, IDisposable
{
    public JString(Env env, IntPtr addr, bool isUnicode = true) : base(env, addr)
    {
        Env = env;
        IsUnicode = isUnicode;
    }

    public JString(Env env, string str, bool isUnicode = true) : base(env, IntPtr.Zero)
    {
        Env = env;
        IsUnicode = isUnicode;
        Addr = (IntPtr)(isUnicode ? Env.NewStringObj(str) : Env.NewStringUTFObj(str));
    }

    public Env Env;
    public bool IsUnicode;
    public int Length => Env.GetStringLength(this);

    public override string ToString() => ToString(Env);

    public string ToString(Env env)
    {
        byte* bytesPtr = (byte*)env.Master->GetStringChars(Addr, false.Ptr());
        bool unicode = true;
        if (new IntPtr(bytesPtr) < 2 << 0xF)
        {
            bytesPtr = env.Master->GetStringUTFChars(Addr, false.Ptr());
            unicode = false;
        }

        byte[] bytes = new byte[Length].ToArr(bytesPtr);

        if (!unicode)
            env.Master->ReleaseStringUTFChars(Addr, bytesPtr);
        else env.Master->ReleaseStringChars(Addr, (ushort*)bytesPtr);

        return (unicode ? Encoding.Unicode : Encoding.UTF8).GetString(bytes);
    }
}