using CSJNI.High.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.BaseTypes;
public class JBInt : JClass
{
    public JBInt(Env env) : base(env, "java/lang/Integer", "I")
    {

    }
}

public class JBIntObj : JClassObject<int>
{
    public JBIntObj(JClass jClass, JObject obj) : base(jClass, obj)
    {
    }
}