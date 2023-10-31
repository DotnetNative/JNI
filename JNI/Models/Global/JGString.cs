using JNI.Internal;
using System.Text;

namespace JNI.Models.Global;

public unsafe sealed class JGString : JGObject
{
    public JGString(nint gAddr, nint lAddr, bool isUnicode = true) : base(gAddr, lAddr)
    {
        IsUnicode = isUnicode;
    }

    public JGString(JGObject obj, bool isUnicode = true) : base(obj.Addr, obj.LocalAddr)
    {
        IsUnicode = isUnicode;
    }

    public bool IsUnicode;
    public int GetLength(Env env) => env.GetStringLength(AsWeak(env));

    public string ToString(Env env)
    {
        var bytesPtr = (byte*)env.Native->GetStringChars(Addr, Env.FalsePtr);
        var unicode = true;
        if ((nint)bytesPtr < 2 << 0xF)
        {
            bytesPtr = env.Native->GetStringUTFChars(Addr, Env.FalsePtr);
            unicode = false;
        }

        var bytes = new byte[GetLength(env)].ToArr(bytesPtr);

        if (!unicode)
            env.Native->ReleaseStringUTFChars(Addr, bytesPtr);
        else env.Native->ReleaseStringChars(Addr, (ushort*)bytesPtr);

        return (unicode ? Encoding.Unicode : Encoding.UTF8).GetString(bytes);
    }
}