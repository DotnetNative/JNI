using System.Diagnostics;

namespace JNI.Internal;
internal static class ModuleHelper
{
    static ModuleHelper()
    {
        foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
            if (module.ModuleName == "java.dll")
                JavaModule = module.BaseAddress;
            else if (module.ModuleName == "jvm.dll")
                JVMModule = module.BaseAddress;
    }

    public static nint JavaModule, JVMModule;
}