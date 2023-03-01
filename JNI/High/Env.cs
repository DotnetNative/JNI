using CSJNI;
using CSJNI.High.BaseTypes;
using CSJNI.High.Enums;
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
        BaseTypes = new BaseTypeCollection(this);
        BaseTypes.InitBaseTypes();
    }

    public Env_* Master { get; init; }

    public BaseTypeCollection BaseTypes;

    public ClassHandle GetClass(string name) => new ClassHandle(this, Master->FindClass(name.AnsiPtr()));
    public JNIVersion Version => (JNIVersion)Master->GetVersion();
}

public class BaseTypeCollection
{
    public BaseTypeCollection(Env env)
    {
        this.env = env;
    }
    private Env env;

    public JBBool Bool;
    public JBByte Byte;
    public JBShort Short;
    public JBInt Int;
    public JBLong Long;
    public JBFloat Float;
    public JBDouble Double;

    public JBString String;

    public JBClass Class;

    internal void InitBaseTypes()
    {
        Bool = new JBBool(env);
        Byte = new JBByte(env);
        Short = new JBShort(env);
        Int = new JBInt(env);
        Long = new JBLong(env);
        Float = new JBFloat(env);
        Double = new JBDouble(env);

        String = new JBString(env);

        Class = new JBClass(env);
    }
}