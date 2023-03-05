using CSJNI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSJNI.High.Hierarchy;
public unsafe class JObject : HandleEnv
{
    public JObject(Env env, IntPtr addr) : base(env, addr)
    {
        
    }

    public T ToStruct<T>() where T : struct => Addr.ToStruct<T>();
    public bool IsNull => Addr == IntPtr.Zero || Env.IsObjectNull(this) || *(long*)Addr == 22209665096L;

    public static explicit operator IntPtr(JObject obj) => obj.Addr;
}