using System.Collections;
using System.Collections.Generic;
using AxGrid.FSM;
using UnityEngine;

namespace Test
{
    [State("Home")]
    public class OnHome : FSMState
    {
        public HomeToWork _homeToWork;
        [Enter]
        private void Home()
        {
            Debug.Log("Z z z...  [PROCRASTINATION AND SLEEP]");
            _homeToWork.WaitOnState(5f);
        }
    }

}
