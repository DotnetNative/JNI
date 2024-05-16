namespace JNI;
public class ClassNotion(Handle handle) : JObject(handle)
{
    [AllowNull] public static JType type;
    [AllowNull] public static JStringMethod getName;

    public static void Init(Env e)
    {
        type = e.GetType("java.lang.Class");
        getName = type.GetStringMethod("getName");
    }

    public JString Name => getName.CallVirtUTF8(this);
    public string NameNative
    {
        get
        {
            using var name = Name;
            return name.ToString();
        }
    }
}