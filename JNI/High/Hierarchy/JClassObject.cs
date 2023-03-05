using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public class JClassObject<T> : IDisposable where T : struct
{
    public JClassObject(JClass jClass, JObject obj)
    {
        Class = jClass;
        Obj = obj;

        IntPtr addr = (IntPtr)obj;
        if (addr == IntPtr.Zero)
            IsNull = true;
        else
            Value = addr.ToStruct<T>();
    }

    public JClass Class;
    public JObject Obj;
    public T Value { get; private set; }
    public readonly bool IsNull;

    public static explicit operator IntPtr(JClassObject<T> obj) => obj.Obj.Addr;

    public void Dispose()
    {
        Class.Env.DeleteLocalRef(Obj);
    }
}