using JNI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.New.Handles;
public unsafe class LHandle : EnvHandle, IDisposable
{
    public LHandle(nint addr)
    {
        localAddr = addr;
    }

    nint localAddr;

    public override Env Env => Env.GetThreadEnv();
    public override Env_* Native => Env.ThreadNativeEnv();
    public override nint Addr { get => localAddr; set => localAddr = value; }


    public void Dispose()
    {
        Env.DeleteLocalRef(localAddr);
    }
}