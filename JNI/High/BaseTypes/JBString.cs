using CSJNI.High.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.BaseTypes;
public class JBString : JClass
{
    public JBString(Env env) : base(env, "java/lang/String") { }
}

public class JBStringObj : JClassObject<JBStringS>
{
    public JBStringObj(JClass jClass, JObject obj) : base(jClass, obj)
    {

    }
}

[StructLayout(LayoutKind.Sequential)]
public struct JBStringS
{
    private const byte LATIN1 = 0;
    private const byte UTF16 = 1;

    public byte[] Bytes;
    public byte Coder;

    public override string ToString()
    {
        if (Coder == LATIN1)
            return Encoding.Latin1.GetString(Bytes, 0, Bytes.Length);
        else if (Coder == UTF16)
            return Encoding.Unicode.GetString(Bytes, 0, Bytes.Length);
        return "Wrong encoder. Current is " + Coder;
    }

    public static JBStringS FromString(string str, bool isUnicode)
    {
        return new JBStringS()
        {
            Bytes = (isUnicode ? Encoding.Unicode : Encoding.UTF8).GetBytes(str),
            Coder = isUnicode ? UTF16 : LATIN1,
        };
    }
}