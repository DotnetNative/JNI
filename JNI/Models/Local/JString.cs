using JNI.Internal;
using System.Text;

namespace JNI.Models.Local;
public unsafe class JString : JObject
{
    public JString(Env env, nint addr, bool isUnicode = true) : base(env, addr)
    {
        Env = env;
        IsUnicode = isUnicode;
    }

    public bool IsUnicode;
    public int Length => Env.Native->GetStringLength(Addr);

    public override string ToString()
    {
        var bytesPtr = (byte*)Env.Native->GetStringChars(Addr, Env.FalsePtr);
        var unicode = true;
        if ((nint)bytesPtr < 2 << 0xF)
        {
            bytesPtr = Env.Native->GetStringUTFChars(Addr, Env.FalsePtr);
            unicode = false;
        }

        var bytes = new byte[Length].ToArr(bytesPtr);

        if (!unicode)
            Env.Native->ReleaseStringUTFChars(Addr, bytesPtr);
        else Env.Native->ReleaseStringChars(Addr, (ushort*)bytesPtr);

        return (unicode ? Encoding.Unicode : Encoding.UTF8).GetString(bytes);
    }
}