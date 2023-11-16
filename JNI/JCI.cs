using JNI.Core;
using JNI.Internal;

namespace JNI;
public unsafe struct JCI
{
    public JCI()
    {
        jvms = GetJVMs();
    }

    /// <summary>
    /// Returns count of all created JVM's
    /// </summary>
    public int CountJVMs => jvms.Length;

    /// <summary>
    /// Returns JVM by index from all created JVM's
    /// </summary>
    public JVM GetJVM(int index = 0) => new(jvms[index]);

    /// <summary>
    /// Returns first created JVM in current process
    /// </summary>
    public JVM JVM => new(jvms[0]); 

    JVM_*[] jvms;
    static JVM_*[] GetJVMs()
    {
        int count;
        Interop.JNI_GetCreatedJavaVMs(null, 0, &count);
        JVM_*[] jvmArr = new JVM_*[count];
        fixed (JVM_** jvmPrr = jvmArr)
        {
            Interop.JNI_GetCreatedJavaVMs(jvmPrr, count, &count);
            return jvmArr;
        }
    }
}