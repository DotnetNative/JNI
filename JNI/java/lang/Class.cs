using JNI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace java.lang;
internal class Class : IClass
{
    public static GJType type;
    public static GJStringMethod getName;
        
    public static void Init(Env e)
    {
        type = e.GetGType("java.lang.Class");
        getName = type.GetStringGMethod("getName");
    }

    public Class(EnvHandle handle) : base(handle) { }

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