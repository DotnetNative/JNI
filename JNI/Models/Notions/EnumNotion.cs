namespace JNI;
public class EnumNotion(Handle handle) : JObject(handle)
{
    [AllowNull] public static JType type;
    [AllowNull] public static JIntField ordinal;
    [AllowNull] public static JStringField name;

    public static void Init(Env e)
    {
        type = e.GetType("java.lang.Enum");
        ordinal = type.GetIntField("ordinal");
        name = type.GetStringField("name");
    }

    public int Ordinal => this[ordinal];
    public string Name
    {
        get
        {
            using var obj = this[name];
            return obj.ToString();
        }
    }
}