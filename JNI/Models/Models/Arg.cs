using JNI.Models;
using JNI.Models.Models.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.Models.Models;
public sealed class Arg
{
    public Arg(string sig) => Sig = sig;

    public Arg(JType type) : this(SigGen.Arg(type)) { }

    public Arg(TypeInfo info) : this(SigGen.Arg(info)) { }

    public readonly string Sig;
}