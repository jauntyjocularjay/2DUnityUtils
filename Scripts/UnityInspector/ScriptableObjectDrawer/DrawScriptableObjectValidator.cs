using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;



[InitializeOnLoad]
public static class DrawScriptableObjectValidator
{
    static DrawScriptableObjectValidator()
    {
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

        foreach(Assembly assembly in assemblies)
        {
            Type[] types = assembly.GetTypes();

            foreach(Type type in types)
            {
                FieldInfo[] fields = type.GetFields(
                    System.Reflection.BindingFlags.Public |
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance
                );

                foreach(FieldInfo field in fields)
                {
                    DrawScriptableObjectAttribute attr = field.GetCustomAttribute<DrawScriptableObjectAttribute>();

                    if(attr != null)
                    {
                        Type fieldType = field.FieldType;
                        if(!typeof(ScriptableObject).IsAssignableFrom(fieldType))
                        {
                            UnityEngine.Debug.LogError($"Field '{field.Name}' has [DrawScriptableObject] but is type '{fieldType.Name}'. It must be a ScriptableObject.");
                            throw new InvalidObjectException("[DrawScriptableObject] attribute applied to a non-ScriptableObject.");
                        }
                    }

                }
            }

        }
    }

    class InvalidObjectException: Exception
    {
        public InvalidObjectException(string message): base(message){}
    }
}
