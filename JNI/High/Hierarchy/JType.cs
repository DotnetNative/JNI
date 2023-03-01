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
        Name = name;
        Sig = sig;
    }

    public JType(Env env, string name, string sig) : base(env, env.Master->FindClass(name.AnsiPtr()))
    {
        Name = name;
        Sig = sig;
    }

    public JType(Env env, string nameAndSig) : this(env, nameAndSig, nameAndSig) { }

    public string Name { get; init; }
    public string Sig { get; init; }
}