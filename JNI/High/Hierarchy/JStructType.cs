using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public class JStructType<T> : JType where T : struct
{
    public JStructType(Env env, IntPtr handle, string name, string sig) : base(env, handle, name, sig)
    {
        Name = name;
        Sig = sig;
    }

    public JStructType(Env env, string name, string sig) : base(env, name, sig)
    {
        Name = name;
        Sig = sig;
    }

    public JStructType(Env env, string nameAndSig) : this(env, nameAndSig, nameAndSig) { }

    public T ToStruct(JObject obj) => ((IntPtr)obj).ToStruct<T>();
}