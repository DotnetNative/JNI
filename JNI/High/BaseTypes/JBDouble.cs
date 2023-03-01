using CSJNI.High.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.BaseTypes;
public class JBDouble : JClass
{
    public JBDouble(Env env) : base(env, "java/lang/Double", "D")
    {

    }
}

public class JBDoubleObj : JClassObject<float>
{
    public JBDoubleObj(JClass jClass, JObject obj) : base(jClass, obj)
    {
    }
}