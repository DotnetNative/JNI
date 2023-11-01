using JNI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JNI.New.Handles;
public unsafe abstract class Handle
{
    public abstract nint Addr { get; set; }

    public static implicit operator nint(Handle val) => val.Addr;
    public static implicit operator void*(Handle val) => (void*)val.Addr;
}