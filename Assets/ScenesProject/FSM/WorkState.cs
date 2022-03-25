using System.Collections;
using System.Collections.Generic;
using AxGrid.FSM;
using UnityEngine;

namespace Test
{
    [State("Work")]
    public class WorkState : FSMState
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
        }
    
        [Loop(0.5f, 0.5f)]
        private void CountMoney()
        {
           
        }
        
    
        [Exit]
        private void WeHome()
        {
            
        }
    }

}
