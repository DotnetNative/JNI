using JNI.Internal;
using JNI.Models.Handles;
using JNI.Models.Models.Object;
using System.Text;

namespace JNI.Models.Models.String;
public unsafe abstract class JString : HandleContainer
{
    public JString(JObject obj, bool isUnicode = true) : base(obj.Handle)
    {
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
        else Env.Native->ReleaseStringChars(Addr, (char*)bytesPtr);

        return (unicode ? Encoding.Unicode : Encoding.UTF8).GetString(bytes);
    }
}

public unsafe class LJString : JString
{
    public LJString(LJObject obj, bool isUnicode = true) : base(obj, isUnicode) { }
}

public unsafe class GJString : JString
{
    public GJString(GJObject obj, bool isUnicode = true) : base(obj, isUnicode) { }
}