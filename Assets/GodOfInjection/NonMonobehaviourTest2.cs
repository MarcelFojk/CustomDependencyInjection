using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GodOfInjection
{
    [Bind(true)]
    public class NonMonobehaviourTest2
    {
        public void TestOfSingleInstanceInjection()
        {
            Debug.Log("Successfully injected NonMonobehaviourTest2 to NonMonobehaviourTest (single instance)");
        }
    }
}