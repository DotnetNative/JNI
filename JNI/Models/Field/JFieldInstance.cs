namespace JNI;
public abstract class JFieldInstance : FieldData
{
    public JFieldInstance(EnvHandle handle, string name, TypeInfo type) : base(handle, name, type) { }
}