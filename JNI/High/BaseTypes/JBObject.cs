using CSJNI.High.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.BaseTypes;
public class JBObject : JClass
{
    public JBObject(Env env) : base(env, "java/lang/Object")
    {
        
    }
}

public class JBObjectObj : JClassObject<byte>
{
    public JBObjectObj(JClass jClass, JObject obj) : base(jClass, obj)
    {

    }
}