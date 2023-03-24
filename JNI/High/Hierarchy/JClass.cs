using CSJNI;
using CSJNI.High;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public unsafe class JClass : JType
{
    public JClass(Env env, string name, string sig) : base(env, env.Master->FindClass(name.UtfPtr()), name, sig){ }

    public JClass(Env env, string nameAndSig) : this(env, nameAndSig, nameAndSig) { }
}