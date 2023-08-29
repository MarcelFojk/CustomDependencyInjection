using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace GodOfInjection
{
    [Bind(false)]
    public class NonMonobehaviourTest3
    {
        private static int _instancesCounter;

        public NonMonobehaviourTest3()
        {   
            _instancesCounter++;
        }

        public void TestOfMultipleInstancesInjection()
        {   
            Debug.Log($"Successfully injected NonMonobehaviourTest3 to NonMonobehaviourTest (multiple instances {_instancesCounter})");
        }

        public void TestOfMultipleInstancesInjectionToMonobehaviour()
        {
            Debug.Log($"Successfully injected NonMonobehaviourTest3 to MonobehaviourTest (multiple instances {_instancesCounter})");
        }
    }
}