using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GodOfInjection
{
    public class GodsHelper : MonoBehaviour
    {
        private void Awake()
        {
            Assembly();

            SceneManager.LoadScene("TestScene");
        }

        private void Assembly()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            for (int i = 0; i < assemblies.Length; i++)
            {
                Type[] types = assemblies[i].GetTypes().Where(t => t.IsDefined(typeof(BindAttribute))
                    && ((BindAttribute)t.GetCustomAttribute(typeof(BindAttribute))).Singleton).ToArray();

                for (int j = 0; j < types.Length; j++)
                    GodOfInjection.GetOrCreateInstance(types[j]);
            }
        }
    }
}