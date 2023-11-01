using JNI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.New.Handles;
public unsafe class GEnvHandle : EnvHandle, IDisposable
{
    public GEnvHandle(Env env, nint localAddr, nint globalAddr)
    {
        this.env = env;
        this.localAddr = localAddr;
        this.globalAddr = globalAddr;
    }

    Env env;
    nint localAddr;
    nint globalAddr;

    public override Env Env => env;
    public override Env_* Native => env.Native;
    public override nint Addr { get => globalAddr; set => globalAddr = value; }

    public void Dispose()
    {
        env.DeleteGlobalRef(globalAddr);
        env.DeleteLocalRef(localAddr);
    }
}