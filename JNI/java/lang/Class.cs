using JNI;

namespace java.lang;
internal class Class(EnvHandle handle) : IClass(handle)
{
    public static GJType type;
    public static GJStringMethod getName;

    public static void Init(Env e)
    {
        type = e.GetGType("java.lang.Class");
        getName = type.GetStringGMethod("getName");
    }

    public java.lang.String Name => getName.Call(this);
    public string NameNative
    {
        get
        {
            using var name = Name;
            return name.ToString();
        }
    }
}