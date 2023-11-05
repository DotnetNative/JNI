using JNI.Core;
using JNI.Internal;

namespace JNI;
public unsafe struct JCI
{
    public JCI(JVersion version)
    {
        Version = version;
        jvms = GetJVMs();
    }

    public JVersion Version { get; init; }

    public JVM GetJVM(int index = 0) => new JVM(jvms[index]);

    private JVM_*[] jvms;
    private static JVM_*[] GetJVMs()
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