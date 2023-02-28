using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI;
public class ModuleHelper
{
    static ModuleHelper()
    {
        InitModules();
    }

    public static Dictionary<string, IntPtr> Modules = new Dictionary<string, IntPtr>();
    public static IntPtr JavaModule, JVMModule;
    public static void InitModules()
    {
        foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
            Modules[module.ModuleName] = module.BaseAddress;

        JavaModule = Modules["java.dll"];
        JVMModule = Modules["jvm.dll"];
    }
}