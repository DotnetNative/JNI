using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High.Hierarchy;
public unsafe class JString : JObject, IDisposable
{
    public JString(Env env, IntPtr addr, bool isUnicode = true) : base(env, addr)
    {
        Env = env;
        IsUnicode = isUnicode;
    }

    public JString(Env env, string str, bool isUnicode = true) : base (env, IntPtr.Zero)
    {
        Env = env;
        IsUnicode = isUnicode;
        Addr = (IntPtr)(isUnicode ? Env.NewStringObj(str) : Env.NewStringUTFObj(str));
    }

    public Env Env;
    public bool IsUnicode;
    public int Length => Env.GetStringLength(this);

    public override string ToString()
    {
        byte* bytesPtr = (byte*)Env.Master->GetStringChars(Addr, false.Ptr());
        bool unicode = true;
        if (new IntPtr(bytesPtr) < (2 << 0xF))
        {
            bytesPtr = Env.Master->GetStringUTFChars(Addr, false.Ptr());
            unicode = false;
        }

        byte[] bytes = new byte[Length].ToArr(bytesPtr);

        return (unicode ? Encoding.Unicode : Encoding.UTF8).GetString(bytes);
    }

    public void Dispose()
    {
        Env.DeleteLocalRef(this);
    }
}