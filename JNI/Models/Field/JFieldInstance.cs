namespace JNI;
public abstract class JFieldInstance(EnvHandle handle, string name, TypeInfo type) : FieldData(handle, name, type);