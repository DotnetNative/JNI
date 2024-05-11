using JNI;
using Memory;
using System.Text;

namespace java.lang;
public unsafe class String : IClass
{
    public static GJType type;

    public static void Init(Env e)
    {
        type = e.GetGType("java.lang.String");
    }

    public String(EnvHandle handle, bool isUnicode = true) : base(handle) => IsUnicode = isUnicode;
    public String(string text, bool isUnicode = true) : this(GHandle.Create(isUnicode ? Env.ThreadNativeEnv->NewString(text) : Env.ThreadNativeEnv->NewStringUTF(text)), isUnicode) { }

    public int Length => IsUnicode ? Native->GetStringLength(this) : Native->GetStringUTFLength(this);
    public readonly bool IsUnicode;

    public override string ToString()
    {
        if (IsUnicode)
        {
            var nativeString = Native->GetStringChars(this, false);
            var length = Length * 2;
            File.AppendAllText(@"C:\a.txt", $".-{length} ");

            var bytes = MemEx.Read(nativeString, length);
            var result = Encoding.Unicode.GetString(bytes);

            Native->ReleaseStringChars(this, nativeString);
            return result;
        }
        else
        {
            var nativeString = Native->GetStringUTFChars(this, false);
            var length = Length;
            File.AppendAllText(@"C:\a.txt", $".-{length} ");

            var bytes = MemEx.Read(nativeString, length);
            var result = Encoding.UTF8.GetString(bytes);

            Native->ReleaseStringUTFChars(this, nativeString);
            return result;
        }
    }
}