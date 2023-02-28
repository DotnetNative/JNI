using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.Low;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct JNIInvokeInterface
{
    public JNIInvokeInterface()
    {

    }

    private void* reserved0 = null;
    private void* reserved1 = null;
    private void* reserved2 = null;

    public delegate* unmanaged<JVM_*, int> DestroyJavaVM = null;
    public delegate* unmanaged<JVM_*, void**, void*, int> AttachCurrentThread = null;
    public delegate* unmanaged<JVM_*, int> DetachCurrentThread = null;
    public delegate* unmanaged<JVM_*, void**, int, int> GetEnv = null;
    public delegate* unmanaged<JVM_*, void**, void*, int> AttachCurrentThreadAsDaemon = null;
}