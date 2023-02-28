using CSJNI.High;
using CSJNI.High.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.BaseTypes;
public unsafe class JBClassT<T> : JClass<JStructType<T>> where T : struct
{
    public JBClassT(Env env) : base(env, "java/lang/Class")
    {
        forNameMeth = new JStaticMethod(env, "forName", this, this, new Arg(env.BaseTypes.String));
    }

    private JStaticMethod forNameMeth;
    public JClass ForName(string name)
    {
        return new JStruct<JEmptyStruct>(forNameMeth.Call(__arglist(JBStringS.FromString(name, true))));
    }

    public 
}

public unsafe struct JBClassS
{ 

}