using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.New;
public class LEnvHandle : EnvHandle, IDisposable
{
    public LEnvHandle(Env env, nint addr)
    {
        this.env = env;
        localAddr = addr;
    }

    Env env;
    nint localAddr;

    public override Env Env { get => env; set => env = value; }
    public override nint Addr { get => localAddr; set => localAddr = value; }

    public void Dispose()
    {
        env.DeleteLocalRef(localAddr);
    }
}