using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GodOfInjection
{
    public class GodsBehaviour : MonoBehaviour
    {
        private void Awake()
        {
            GodOfInjection.InjectFields(this);

            OnAwake();
        }

        protected virtual void OnAwake()
        {
            
        }
    }
}