using JNI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.New.Handles;
public unsafe class GHandle : EnvHandle, IDisposable
{
    public GHandle(nint localAddr, nint globalAddr)
    {
        this.localAddr = localAddr;
        this.globalAddr = globalAddr;
    }

    nint localAddr;
    nint globalAddr;

    public override Env Env => Env.GetThreadEnv();
    public override Env_* Native => Env.ThreadNativeEnv();
    public override nint Addr { get => globalAddr; set => globalAddr = value; }


    public void Dispose()
    {
        var e = Env;
        e.DeleteGlobalRef(globalAddr);
        e.DeleteLocalRef(localAddr);
    }
}