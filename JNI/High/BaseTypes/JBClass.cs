using CSJNI.High.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.BaseTypes;
public class JBClass : JClass
{
    public JBClass(Env env) : base(env, "java/lang/Class")
    {
        forNameMeth = new JStaticMethod(env, "forName", this, this, new Arg(env.BaseTypes.String));
    }

    private JStaticMethod forNameMeth;
    public JBClassObj ForName(string name)
    {
        return new JBClassObj(this, forNameMeth.Call(__arglist(JBStringS.FromString(name, true))));
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