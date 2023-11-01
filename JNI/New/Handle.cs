using JNI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.New;
public unsafe abstract class Handle
{
    public abstract nint Addr { get; set; }

    public static explicit operator void*(Handle val) => (void*)val.Addr;
    public static explicit operator nint(Handle val) => val.Addr;
}