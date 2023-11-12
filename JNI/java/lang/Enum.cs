using JNI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace java.lang;
public class Enum : IClass
{
    public static GJType type;
    static GJIntField ordinal;
    static GJStringField name;

    public static void Init(Env e)
    {
        type = e.GetGType("java.lang.Enum");
        ordinal = type.GetIntGField("ordinal");
        name = type.GetStringGField("name");
    }

    public Enum(EnvHandle handle) : base(handle) { }

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