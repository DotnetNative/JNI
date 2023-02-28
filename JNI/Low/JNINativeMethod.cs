using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.Low;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct JNINativeMethod
{
    public char* Name;
    public char* Signature;
    public void* FnPtr;
}