using JNI;

namespace java.lang;
public class Class(EnvHandle handle) : IClass(handle)
{
    public static GJType type;
    public static JStringMethod getName;

    public static void Init(Env e)
    {
        type = e.GetGType("java.lang.Class");
        getName = type.GetStringMethod("getName");
    }

    public java.lang.String Name => getName.CallVirtUTF8(this);
    public string NameNative
    {
        get
        {
            using var name = Name;
            return name.ToString();
        }
    }
}