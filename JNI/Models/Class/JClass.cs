namespace JNI;
public unsafe class JClass(Handle handle) : HandleContainer(handle)
{
    public JCtor GetCtor(params Arg[] args) => new(GetVoidMethod("<init>", args));
    public JCtor GetCtor(params TypeInfo[] args) => GetCtor(args.ToArgs());

    #region Field
    public FieldDescriptor GetFieldHandle(string name, TypeInfo type)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Field(type);
        using var sigCo = new CoMem(sig);
        return env_->GetFieldID(Address, nameCo, sigCo);
    }

    public FieldDescriptor GetStaticFieldHandle(string name, TypeInfo type)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Field(type);
        using var sigCo = new CoMem(sig);
        return env_->GetStaticFieldID(Address, nameCo, sigCo);
    }

    public JStringField GetStringField(string name) => new(GetFieldHandle(name, Types.String), name);
    public JObjectField GetObjectField(string name, TypeInfo type) => new(GetFieldHandle(name, type), name, type);
    public JBoolField GetBoolField(string name) => new(GetFieldHandle(name, Types.Bool), name);
    public JByteField GetByteField(string name) => new(GetFieldHandle(name, Types.Byte), name);
    public JCharField GetCharField(string name) => new(GetFieldHandle(name, Types.Char), name);
    public JShortField GetShortField(string name) => new(GetFieldHandle(name, Types.Short), name);
    public JIntField GetIntField(string name) => new(GetFieldHandle(name, Types.Int), name);
    public JLongField GetLongField(string name) => new(GetFieldHandle(name, Types.Long), name);
    public JFloatField GetFloatField(string name) => new(GetFieldHandle(name, Types.Float), name);
    public JDoubleField GetDoubleField(string name) => new(GetFieldHandle(name, Types.Double), name);
    public JEnumField GetEnumField(string name, JEnum jenum) => new(GetFieldHandle(name, jenum), name, jenum);

    public JStaticStringField GetStaticStringField(string name) => new(GetStaticFieldHandle(name, Types.String), name, this);
    public JStaticObjectField GetStaticObjectField(string name, TypeInfo type) => new(GetStaticFieldHandle(name, type), name, type, this);
    public JStaticBoolField GetStaticBoolField(string name) => new(GetStaticFieldHandle(name, Types.Bool), name, this);
    public JStaticByteField GetStaticByteField(string name) => new(GetStaticFieldHandle(name, Types.Byte), name, this);
    public JStaticCharField GetStaticCharField(string name) => new(GetStaticFieldHandle(name, Types.Char), name, this);
    public JStaticShortField GetStaticShortField(string name) => new(GetStaticFieldHandle(name, Types.Short), name, this);
    public JStaticIntField GetStaticIntField(string name) => new(GetStaticFieldHandle(name, Types.Int), name, this);
    public JStaticLongField GetStaticLongField(string name) => new(GetStaticFieldHandle(name, Types.Long), name, this);
    public JStaticFloatField GetStaticFloatField(string name) => new(GetStaticFieldHandle(name, Types.Float), name, this);
    public JStaticDoubleField GetStaticDoubleField(string name) => new(GetStaticFieldHandle(name, Types.Double), name, this);
    public JStaticEnumField GetStaticEnumField(string name, JEnum jenum) => new(GetStaticFieldHandle(name, jenum), name, jenum, this);
    #endregion

    #region Method
    public MethodDescriptor GetMethodHandle(string name, TypeInfo type, params Arg[] args)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Method(type, args);
        using var sigCo = new CoMem(sig);

        return env_->GetMethodID(Address, nameCo, sigCo);
    }

    public MethodDescriptor GetStaticMethodHandle(string name, TypeInfo type, params Arg[] args)
    {
        using var nameCo = new CoMem(name);
        string sig = SigGen.Method(type, args);
        using var sigCo = new CoMem(sig);

        return env_->GetStaticMethodID(Address, nameCo, sigCo);
    }

    public JStringMethod GetStringMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Types.String, args), name, this, args);
    public JObjectMethod GetObjectMethod(string name, TypeInfo type, params Arg[] args) => new(GetMethodHandle(name, type, args), name, type, this, args);
    public JVoidMethod GetVoidMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Types.Void, args), name, this, args);
    public JBoolMethod GetBoolMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Types.Bool, args), name, this, args);
    public JByteMethod GetByteMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Types.Byte, args), name, this, args);
    public JCharMethod GetCharMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Types.Char, args), name, this, args);
    public JShortMethod GetShortMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Types.Short, args), name, this, args);
    public JIntMethod GetIntMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Types.Int, args), name, this, args);
    public JLongMethod GetLongMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Types.Long, args), name, this, args);
    public JFloatMethod GetFloatMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Types.Float, args), name, this, args);
    public JDoubleMethod GetDoubleMethod(string name, params Arg[] args) => new(GetMethodHandle(name, Types.Double, args), name, this, args);
    public JEnumMethod GetEnumMethod(string name, JEnum jenum, params Arg[] args) => new(GetMethodHandle(name, jenum, args), name, jenum, this, args);

    public JStaticStringMethod GetStaticStringMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Types.String, args), name, this, args);
    public JStaticObjectMethod GetStaticObjectMethod(string name, TypeInfo type, params Arg[] args) => new(GetStaticMethodHandle(name, type, args), name, type, this, args);
    public JStaticVoidMethod GetStaticVoidMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Types.Void, args), name, this, args);
    public JStaticBoolMethod GetStaticBoolMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Types.Bool, args), name, this, args);
    public JStaticByteMethod GetStaticByteMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Types.Byte, args), name, this, args);
    public JStaticCharMethod GetStaticCharMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Types.Char, args), name, this, args);
    public JStaticShortMethod GetStaticShortMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Types.Short, args), name, this, args);
    public JStaticIntMethod GetStaticIntMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Types.Int, args), name, this, args);
    public JStaticLongMethod GetStaticLongMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Types.Long, args), name, this, args);
    public JStaticFloatMethod GetStaticFloatMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Types.Float, args), name, this, args);
    public JStaticDoubleMethod GetStaticDoubleMethod(string name, params Arg[] args) => new(GetStaticMethodHandle(name, Types.Double, args), name, this, args);
    public JStaticEnumMethod GetStaticEnumMethod(string name, JEnum jenum, params Arg[] args) => new(GetStaticMethodHandle(name, jenum, args), name, jenum, this, args);
    #endregion

    public JClass Superclass => new(HandleImpl.Create(env_->GetSuperclass(Address)));

    public bool IsAssignableFrom(JClass clazz) => env_->IsAssignableFrom(Address, clazz);

    public RetCode RegisterNatives(params NativeMethod_[] methods)
    {
        fixed (NativeMethod_* ptr = methods)
            return env_->RegisterNatives(Address, ptr, methods.Length);
    }

    public RetCode UnregisterNatives() => env_->UnregisterNatives(Address);

    public string ClassName => new ClassNotion(this).NameNative;
}