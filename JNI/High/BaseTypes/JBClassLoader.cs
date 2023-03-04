using CSJNI.High.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.BaseTypes;
public class JBClassLoader : JClass
{
    public JBClassLoader(Env env) : base(env, "java/lang/ClassLoader")
    {

    }


}

public class JBClassLoaderObj : JClassObject<bool>
{
    public JBClassLoaderObj(JClass jClass, JObject obj) : base(jClass, obj)
    {

    }

    public JBClassLoaderObj(Env env, JObject obj) : base(env.BaseTypes.ClassLoader, obj)
    {

    }
}