using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public class Handle
{
    public Handle(IntPtr addr)
    {
        Addr = addr;
    }

    public IntPtr Addr { get; init; }

    public static explicit operator IntPtr(Handle obj) => obj.Addr;
    public static implicit operator Handle(IntPtr handle) => new Handle(handle);

    public override string ToString()
    {
        string hex = Addr.ToInt64().ToString("X");
        return "0x" + (string.IsNullOrEmpty(hex) ? "0" : hex);
    }
}