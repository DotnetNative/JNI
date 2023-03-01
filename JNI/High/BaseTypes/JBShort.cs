using CSJNI.High.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.BaseTypes;
public class JBShort : JClass
{
    public JBShort(Env env) : base(env, "java/lang/Short", "S")
    {

    }
}

public class JBShortObj : JClassObject<short>
{
    public JBShortObj(JClass jClass, JObject obj) : base(jClass, obj)
    {
    }
}