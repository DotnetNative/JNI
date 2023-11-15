using JNI;
using Memory;
using System.Text;

namespace java.lang;
public unsafe class String(EnvHandle handle) : IClass(handle)
{
    public static GJType type;

    public static void Init(Env e)
    {
        type = e.GetGType("java.lang.String");
    }

    public String(string text, bool isUnicode = true) : this(GHandle.Create(isUnicode ? Env.ThreadNativeEnv->NewString(text) : Env.ThreadNativeEnv->NewStringUTF(text))) { }

    public int Length => Native->GetStringLength(this);

    public override string ToString()
    {
        var nativeString = Native->GetStringChars(this, false);
        var length = Length;

        var bytes = new byte[length];
        MemEx.Copy(bytes, nativeString);
        var result = Encoding.Unicode.GetString(bytes);

        Native->ReleaseStringChars(this, nativeString);

        return result;
    }
}