using System.Collections;
using System.Collections.Generic;
using AxGrid.FSM;
using Test;
using UnityEngine;

namespace Test
{
    [State("Store")]
    public class OnStore : FSMState
    {
        public HomeToWork _homeToWork;

        [Enter]
        private void InTheStore()
        {
            _homeToWork.SetIncrement(-1);
            _homeToWork.WaitOnState(1.5f);
        }
        
    }

}
