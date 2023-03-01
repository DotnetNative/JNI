using CSJNI.High.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.BaseTypes;
public class JBFloat : JClass
{
    public JBFloat(Env env) : base(env, "java/lang/Float", "F")
    {

    }
}

public class JBFloatObj : JClassObject<float>
{
    public JBFloatObj(JClass jClass, JObject obj) : base(jClass, obj)
    {
    }
}