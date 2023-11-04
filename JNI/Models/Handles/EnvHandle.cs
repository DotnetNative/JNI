using JNI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.Models.Handles;
public abstract unsafe class EnvHandle : Handle
{
    public abstract Env Env { get; }
    public Env_* Native => Env.ThreadNativeEnv;
    public override nint Addr { get; set; }
}