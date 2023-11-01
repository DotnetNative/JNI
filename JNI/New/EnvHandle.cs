using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.New;
public abstract class EnvHandle : Handle
{
    public abstract Env Env { get; set; }
    public override nint Addr { get; set; }
}