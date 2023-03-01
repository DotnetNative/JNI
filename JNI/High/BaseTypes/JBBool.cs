using CSJNI.High.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.BaseTypes;
public class JBBool : JClass
{
    public JBBool(Env env) : base(env, "java/lang/Boolean", "Z")
    {
        
    }
}

public class JBBoolObj : JClassObject<bool>
{
    public JBBoolObj(JClass jClass, JObject obj) : base(jClass, obj)
    {
    }
}