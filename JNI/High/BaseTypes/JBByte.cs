using CSJNI.High.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.BaseTypes;
public class JBByte : JClass
{
    public JBByte(Env env) : base(env, "java/lang/Byte", "B")
    {

    }
}

public class JBByteObj : JClassObject<byte>
{
    public JBByteObj(JClass jClass, JObject obj) : base(jClass, obj)
    {
    }
}