using CSJNI.High.Hierarchy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.BaseTypes;
public unsafe class JBClass : JClass
{
    public JBClass(Env env) : base(env, "java/lang/Class")
    {
        forNameMeth = new JStaticMethod(env, "forName", this, this, new Arg(env.BaseTypes.String));
    }

    private JStaticMethod forNameMeth;
    public JBClassObj ForName(string name)
    {
        JBStringS arg = JBStringS.FromString(name, true);
        return new JBClassObj(this, forNameMeth.Call(arg));       
    }
}

public class JBClassObj : JClassObject<JBClassS>
{
    public JBClassObj(JClass jClass, JObject obj) : base(jClass, obj)
    {
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct JBClassS
{

}