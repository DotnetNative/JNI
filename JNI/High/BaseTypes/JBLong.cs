using CSJNI.High.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.BaseTypes;
public class JBLong : JClass
{
    public JBLong(Env env) : base(env, "java/lang/Long", "J")
    {

    }
}

public class JBLongObj : JClassObject<bool>
{
    public JBLongObj(JClass jClass, JObject obj) : base(jClass, obj)
    {
    }
}