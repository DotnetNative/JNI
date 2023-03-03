using CSJNI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public class JObject : Handle
{
    public JObject(IntPtr addr) : base(addr)
    {
        
    }

    public T ToStruct<T>() where T : struct => Addr.ToStruct<T>();

    public static explicit operator IntPtr(JObject obj) => obj.Addr;
}