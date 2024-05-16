using System.Text;

namespace JNI;
public unsafe class JString : JObject
{
    [AllowNull] public static JType type;

    public static void Init(Env e)
    {
        type = e.GetType("JString");
    }

    public JString(Handle handle, bool isUnicode = true) : base(handle) => IsUnicode = isUnicode;
    public JString(string text, bool isUnicode = true) : this(HandleImpl.Create(isUnicode ? env_->NewString(text) : env_->NewStringUTF(text)), isUnicode) { }

    public int Length => IsUnicode ? env_->GetStringLength(this) : env_->GetStringUTFLength(this);
    public readonly bool IsUnicode;

    public override string ToString()
    {
        if (IsUnicode)
        {
            var nativeString = env_->GetStringChars(this, false);
            var length = Length * 2;

            var bytes = MemEx.Read(nativeString, length);
            var result = Encoding.Unicode.GetString(bytes);

            env_->ReleaseStringChars(this, nativeString);
            return result;
        }
        else
        {
            var nativeString = env_->GetStringUTFChars(this, false);
            var length = Length;

            var bytes = MemEx.Read(nativeString, length);
            var result = Encoding.UTF8.GetString(bytes);

            env_->ReleaseStringUTFChars(this, nativeString);
            return result;
        }
    }
}