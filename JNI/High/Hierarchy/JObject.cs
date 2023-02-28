using CSJNI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public class JObject : Handle
{
    public JObject(IntPtr addr, ClassHandle clazz) : base(addr)
    {
        this.clazz = clazz;
    }

    public ClassHandle clazz;

    public T ToStruct<T>() where T : struct => Addr.ToStruct<T>();
}