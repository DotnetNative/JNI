using CSJNI.High.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.BaseTypes;
public class JBString : JClass
{
    public JBString(Env env) : base(env, "java/lang/String")
    {
        valueOf = GetStaticMethod("valueOf", this, env.Types.Object);
    }

    private JStaticMethod valueOf;
    public JBStringObj GetString(string str)
    {
        using JString jstr = new JString(Env, str, false);
        return new JBStringObj(this, valueOf.CallObj(new Params(jstr)));
    }
}

public class JBStringObj : JClassObject<byte>
{
    public JBStringObj(JClass jClass, JObject obj) : base(jClass, obj)
    {

    }
}