using JNI.Internal;
using JNI.Models.Local;
using System.Text;

namespace JNI.Models.Global;
public class JGString : JString
{
    public JGString(Env env, nint addr, bool isUnicode = true) : base(env, addr, isUnicode) => PutGlobal();
    public JGString(Env env, string str, bool isUnicode = true) : base(env, str, isUnicode) => PutGlobal();

    public JGObject AsObject { get => new JGObject(Env, Addr); }
    public JGObject ToObject(Env env) => new JGObject(env, Addr);
}