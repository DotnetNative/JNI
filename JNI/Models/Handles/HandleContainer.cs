using JNI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.Models.Handles;
public abstract unsafe class HandleContainer : Handle, IDisposable
{
    public HandleContainer(EnvHandle handle) => Handle = handle;

    public EnvHandle Handle { get; init; }
    public bool IsGlobal => Handle is GHandle;

    public override nint Addr { get => Handle.Addr; set => Handle.Addr = value; }
    public Env Env => Handle.Env;
    public Env_* Native => Handle.Native;

    public void Dispose()
    {
        if (IsGlobal)
            (Handle as GHandle)!.Dispose();
        else (Handle as LHandle)!.Dispose();
    }
}