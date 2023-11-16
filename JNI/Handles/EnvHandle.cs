using JNI.Core;

namespace JNI;
/// <summary>
/// Implements <see cref="Handle"/>. Contains <see cref="JNI.Env"/> and <see cref="Env_"/> instance
/// </summary>
public abstract unsafe class EnvHandle : Handle
{
    public abstract Env Env { get; }
    public Env_* Native => Env.Native;
    public override nint Addr { get; set; }
}