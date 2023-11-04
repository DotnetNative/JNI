using JNI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.Models.Handles;
public unsafe class LHandle : EnvHandle, IDisposable
{
    public LHandle(nint addr)
    {
        localAddr = addr;
    }

    nint localAddr;

    public override nint Addr { get => localAddr; set => localAddr = value; }

    Env env = Env.ThreadEnv;
    public override Env Env => env;

    public static LHandle Create(nint addr) => new(addr);

    public void Dispose()
    {
        Env.DeleteLocalRef(localAddr);
    }
}