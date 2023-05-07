using System.Diagnostics;

namespace JNI.Internal;
internal sealed class ModuleHelper
{
    static ModuleHelper()
    {
        foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
            if (module.ModuleName == "java.dll")
                JavaModule = module.BaseAddress;
            else if (module.ModuleName == "jvm.dll")
                JVMModule = module.BaseAddress;
    }

    public static IntPtr JavaModule, JVMModule;
}