using JNI;

namespace java.lang;
public class Enum(EnvHandle handle) : IClass(handle)
{
    public static GJType type;
    protected static JIntField ordinal;
    protected static JStringField name;

    public static void Init(Env e)
    {
        type = e.GetGType("java.lang.Enum");
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

public class Enum<T> : Enum where T : struct, System.Enum
{
    public Enum(EnvHandle handle, T value) : base(handle) => Value = value;

    public T Value;
}