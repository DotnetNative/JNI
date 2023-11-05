using JNI.Core;

namespace JNI;
public abstract unsafe class EnvHandle : Handle
{
    public abstract Env Env { get; }
    public Env_* Native => Env.Native;
    public override nint Addr { get; set; }
}