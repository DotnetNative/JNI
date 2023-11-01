using JNI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.New.Handles;
public abstract unsafe class HandleContainer : Handle
{
    public HandleContainer(EnvHandle handle) => Handle = handle;

    public EnvHandle Handle { get; init; }
    public bool IsGlobal => Handle is GEnvHandle || Handle is GHandle;
    public bool IsDynamicEnv => Handle is GHandle || Handle is LHandle;

    public override nint Addr { get => Handle.Addr; set => Handle.Addr = value; }
    public Env Env => Handle.Env;
    public Env_* Native => Handle.Native;
}