using System.Collections;
using System.Collections.Generic;
using AxGrid.FSM;
using UnityEngine;

namespace Test
{
    [State("GoingStore")]
    public class GoingStoreState : FSMState
    {
        public Transform A;
        public Transform B;
        public HomeToWork homeToWorkController;
    
        [Enter]
        private void GoingHome()
        {
            homeToWorkController.SetA(A);
            homeToWorkController.SetB(B);
            homeToWorkController.MovementCorutine();
            homeToWorkController.SetIncrement(0);
        }
        
        [Exit]
        private void OnHome()
        {
            Debug.Log("GOING Home!");
        }
     
    }

}
