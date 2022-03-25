using System.Collections;
using System.Collections.Generic;
using AxGrid.FSM;
using UnityEngine;

namespace Test
{
    [State("Work")]
    public class OnWork : FSMState
    {
        public HomeToWork _homeToWork;
    
        [Enter]
        private void InTheWork()
        {
            _homeToWork.SetIncrement(1);
            _homeToWork.WaitOnState(3f);
        }
    }

}
