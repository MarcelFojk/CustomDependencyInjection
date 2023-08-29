using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GodOfInjection
{
    public class MonobehaviourTest : GodsBehaviour
    {
        [Inject] private NonMonobehaviourTest _monobehaviourTest;
        [Inject] private NonMonobehaviourTest3 _monobehaviourTest3;

        protected override void OnAwake()
        {
            base.OnAwake();

            _monobehaviourTest.TestOfMonobehaviourInjection();
            _monobehaviourTest.TestOfSingleInstanceInjection();
            _monobehaviourTest.TestOfMultipleInstancesInjection();
            _monobehaviourTest3.TestOfMultipleInstancesInjectionToMonobehaviour();
        }
    }
}