using CSJNI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSJNI.High.Hierarchy;
public unsafe class JObject : Handle
{
    public JObject(IntPtr addr) : base(addr)
    {
        
    }

    public T ToStruct<T>() where T : struct => Addr.ToStruct<T>();
    public bool IsNull(Env env) => Addr == IntPtr.Zero || env.IsObjectNull(this) || *(long*)Addr == 22209665096L;

    public static explicit operator IntPtr(JObject obj) => obj.Addr;
}