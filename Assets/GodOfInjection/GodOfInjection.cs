using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;

namespace GodOfInjection
{
    public static class GodOfInjection
    {
        private static Dictionary<Type, object> _singletonCotainer = new();

        public static object GetOrCreateInstance(Type type, List<Type> typesFlowControl = null)
        {
            var attribute = (BindAttribute)Attribute.GetCustomAttribute(type, typeof(BindAttribute));
            if (attribute.Singleton)
                if (_singletonCotainer.TryGetValue(type, out object instance))
                    return instance;

            // Tracks types for circular dependency
            typesFlowControl ??= new List<Type>();
            typesFlowControl.Add(type);

            List<object> instances = new();

            ConstructorInfo contructorInfo = type.GetConstructors()[0];
            ParameterInfo[] parameters = contructorInfo.GetParameters();
            foreach (ParameterInfo param in parameters)
            {
                if (type != param.ParameterType && !typesFlowControl.Contains(param.ParameterType))
                {
                    typesFlowControl.Add(param.ParameterType);
                    instances.Add(GetOrCreateInstance(param.ParameterType, typesFlowControl));
                }
                else
                {
                    throw (new Exception($"GodOfInjection: Class {type} can't be dependent of {param.ParameterType} beacause of the circular dependency"));
                }
            }

            // Creates an instance of a script with it's dependencies
            object newInstance = contructorInfo.Invoke(instances.ToArray());

            if (attribute.Singleton)
                _singletonCotainer[type] = newInstance;

            return newInstance;
        }

        public static void InjectFields(object instance)
        {       
            var type = instance.GetType();
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            for (int i = 0; i < fields.Length; i++)
            {   
                if (fields[i].HasAttribute(typeof(InjectAttribute)))
                    fields[i].SetValue(instance, GetOrCreateInstance(fields[i].FieldType));
            }
        }
    }
}