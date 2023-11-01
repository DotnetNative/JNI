using JNI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.New.Handles;
public abstract unsafe class EnvHandle : Handle
{
    public abstract Env Env { get; }
    public abstract Env_* Native { get; }
    public override nint Addr { get; set; }
}