using GodOfInjection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GodOfInjection
{
    [Bind(true)]
    public class NonMonobehaviourTest
    {
        private readonly NonMonobehaviourTest2 _nonMonobehaviourTest2;
        private readonly NonMonobehaviourTest3 _nonMonobehaviourTest3;

        public NonMonobehaviourTest(NonMonobehaviourTest2 nonMonobehaviourTest2, NonMonobehaviourTest3 nonMonobehaviourTest3)
        {
            _nonMonobehaviourTest2 = nonMonobehaviourTest2;
            _nonMonobehaviourTest3 = nonMonobehaviourTest3;
        }

        public void TestOfMonobehaviourInjection()
        {
            Debug.Log("Successfully injected NonMonobehaviourTest to MonobehaviourTest (single instance)");
        }

        public void TestOfSingleInstanceInjection()
        {
            _nonMonobehaviourTest2.TestOfSingleInstanceInjection();
        }

        public void TestOfMultipleInstancesInjection()
        {
            _nonMonobehaviourTest3.TestOfMultipleInstancesInjection();
        }
    }
}