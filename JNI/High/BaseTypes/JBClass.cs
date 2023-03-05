using CSJNI.High.Hierarchy;
using CSJNI.Low;
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
        forNameMeth = new JStaticMethod(env, "forName", this, this, new Arg(env.Types.String));
        forNameMethEx = new JStaticMethod(env, "forName", this, this, new Arg(env.Types.String), new Arg(env.Types.Bool), new Arg(env.Types.ClassLoader));
    }

    private JStaticMethod forNameMeth;
    private JStaticMethod forNameMethEx;

    public JBClassObj ForName(string name)
    {
        using JString str = Env.NewStringUTF(name);
        return new JBClassObj(this, forNameMeth.CallObj(new Params(str)));
    }

    public JBClassObj ForName(string name, bool initialize, JBClassLoaderObj classLoader)
    {
        using JString str = Env.NewStringUTF(name);
        return new JBClassObj(this, forNameMethEx.CallObj(new Params(str, initialize, classLoader.Obj)));
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