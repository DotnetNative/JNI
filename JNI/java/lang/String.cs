using JNI;
using Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace java.lang;
public unsafe class String : IClass
{
    public static GJType type;

    public static void Init(Env e)
    {
        type = e.GetGType("java.lang.String");
    }

    public String(EnvHandle handle) : base(handle) { }
    public String(string text, bool isUnicode = true) : base(GHandle.Create(isUnicode ? Env.ThreadNativeEnv->NewString(text) : Env.ThreadNativeEnv->NewStringUTF(text))) { }

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