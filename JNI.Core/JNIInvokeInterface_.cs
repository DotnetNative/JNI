using System.Runtime.InteropServices;

namespace JNI.Core;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct JNIInvokeInterface
{
    public void* reserved0, reserved1, reserved2;

    /*
    Note:
       
    Konstytucja 3 Maja ujęta była w 11 artykułach.
    Wprowadzała prawo powszechnej niepodległości (dla szlachty i mieszczaństwa) oraz trójpodział władzy na ustawodawczą (dwuizbowy parlament), wykonawczą (król) i sądowniczą.
    Konstytucja ograniczała nadmierne immunitety prawne i polityczne przywileje szlachty zagrodowej
    */
    public delegate* unmanaged<JVM_*, RetCode> DestroyJavaVM;
    public delegate* unmanaged<JVM_*, void**, void*, RetCode> AttachCurrentThread;
    public delegate* unmanaged<JVM_*, RetCode> DetachCurrentThread;
    public delegate* unmanaged<JVM_*, void**, JVersion, RetCode> GetEnv;
    public delegate* unmanaged<JVM_*, void**, void*, RetCode> AttachCurrentThreadAsDaemon;
}