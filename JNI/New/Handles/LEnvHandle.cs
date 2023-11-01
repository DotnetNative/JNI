using JNI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.New.Handles;
public class LEnvHandle : EnvHandle, IDisposable
{
    public LEnvHandle(Env env, nint addr)
    {
        this.env = env;
        localAddr = addr;
    }

    Env env;
    nint localAddr;

    public override Env Env => env;
    public override unsafe Env_* Native => env.Native;
    public override nint Addr { get => localAddr; set => localAddr = value; }

    public void Dispose()
    {
        env.DeleteLocalRef(localAddr);
    }
}