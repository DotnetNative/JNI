using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CSJNI.High;
using CSJNI.Low;
using CSJNI.High.Enums;

namespace CSJNI;
public unsafe struct JNI
{
    public JNI(JNIVersion version)
    {
        Version = version;
        jvms = GetJVMs();
    }

    public JNIVersion Version;

    private JVM_*[] jvms;

    public JVM GetJVM(int index = 0) => new JVM(jvms[index]);

    private static JVM_*[] GetJVMs()
    {
        int count;
        Interop.JNI_GetCreatedJavaVMs(null, 0, &count);
        JVM_*[] jvmArr = new JVM_*[count];
        fixed (JVM_** jvms = jvmArr)
        {
            Interop.JNI_GetCreatedJavaVMs(jvms, count, &count);
            return jvmArr;
        }
    }
}