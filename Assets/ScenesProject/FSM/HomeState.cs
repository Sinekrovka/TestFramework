using System.Collections;
using System.Collections.Generic;
using AxGrid.FSM;
using UnityEngine;

namespace Test
{
   [State("Home")]
   public class HomeState : FSMState
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
   
       [Exit]
       private void WeHome()
       {
           
       }
   } 

}
