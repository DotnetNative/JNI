using CSJNI.High.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.BaseTypes;
public class JBVoid : JClass
{
    public JBVoid(Env env) : base(env, "java/lang/Void", "V")
    {

    }
}

public class JBVoidObj : JClassObject<byte>
{
    public JBVoidObj(JClass jClass, JObject obj) : base(jClass, obj)
    {
    }
}