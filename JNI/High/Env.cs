using CSJNI;
using CSJNI.BaseTypes;
using CSJNI.High.Hierarchy;
using CSJNI.Low;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSJNI.High;
public unsafe class Env
{
    public Env(Env_* env)
    {
        Master = env;
        BaseTypes = new BaseTypes(this);
    }

    public Env_* Master { get; init; }

    public JClass<T> GetStruct<T>(string name) where T : struct => new JClass<T>(this, name, name);
    public ClassHandle GetClass(string name) => new ClassHandle(this, Master->FindClass(name.Ptr()));
    public BaseTypes BaseTypes;
}

public class BaseTypes
{
    public BaseTypes(Env env)
    {
        this.env = env;
        InitBaseTypes();
    }
    private Env env;

    public JClass<bool> Bool;
    public JClass<byte> Byte;
    public JClass<short> Short;
    public JClass<int> Int;
    public JClass<long> Long;
    public JClass<float> Float;
    public JClass<double> Double;

    public JBString String;

    public JBClassT Class;

    private void InitBaseTypes()
    {
        Bool = new JClass<bool>(env, "java/lang/Boolean", "Z");
        Byte = new JClass<byte>(env, "java/lang/Byte", "B");
        Short = new JClass<short>(env, "java/lang/Short", "S");
        Int = new JClass<int>(env, "java/lang/Integer", "I");
        Long = new JClass<long>(env, "java/lang/Long", "J");
        Float = new JClass<float>(env, "java/lang/Float", "F");
        Double = new JClass<double>(env, "java/lang/Double", "D");

        String = new JBString(env);

        Class = new JBClassT(env);
    }
}