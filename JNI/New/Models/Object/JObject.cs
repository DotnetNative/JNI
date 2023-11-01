using JNI.Models.Global;
using JNI.Models.Local;
using JNI.Models.Weak;
using JNI.New.Handles;
using JNI.New.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.New.Models.Object;
public unsafe class JObject : HandleContainer
{
    public JObject(EnvHandle handle) : base(handle)
    {
    }

    public bool IsNull => Addr == nint.Zero;
    public bool InstanceOf(ClassHandle clazz) => Native->IsInstanceOf(Addr, clazz);
    public ClassHandle GetClass() => new ClassHandle(new Env, Native->GetObjectClass(Addr));

    public static JObject Null = new JObject(new LEnvHandle(null, 0));

    public static bool operator ==(JObject a, JObject b) => a.Native->IsSameObject(a, b);
    public static bool operator !=(JObject a, JObject b) => !a.Native->IsSameObject(a, b);

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
            return true;

        if (ReferenceEquals(obj, null))
            return false;

        return false;
    }

    public override int GetHashCode() => (int)Addr;
}