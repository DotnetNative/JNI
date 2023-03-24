using CSJNI.High;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public unsafe class JType : ClassHandle
{
    public JType(Env env, IntPtr handle, string name, string sig) : base(env, handle)
    {
        BaseCtor(name, sig);
    }

    public JType(Env env, string name, string sig) : base(env, env.Master->FindClass(name.Replace('.', '/').UtfPtr()))
    {
        BaseCtor(name, sig);
    }

    private void BaseCtor(string name, string sig)
    {
        Name = name.Replace('.', '/');
        Sig = sig.Replace('.', '/');
    }

    public JType(Env env, string nameAndSig) : this(env, nameAndSig.Replace('.', '/'), nameAndSig) { }

    public string Name { get; private set; }
    public string Sig { get; private set; }
    public int Dim { get; set; } = 0;
}