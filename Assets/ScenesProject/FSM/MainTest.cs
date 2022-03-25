
using System.Collections.Generic;
using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;

namespace Test
{
    public class MainTest : MonoBehaviourExtBind
    {
        [SerializeField] private Transform home;
        [SerializeField] private Transform work;
        [SerializeField] private Transform store;
        [SerializeField] private HomeToWork _homeWorkController;
    
        [SerializeField] private List<string> stateNames;
    
        private int indexState;
        public static MainTest Inst;
        [OnAwake]
        private void StartStateMachine()
        {
            Inst = this;
        
            HomeState homeState = new HomeState();
            homeState.A = store;
            homeState.B = home;
            homeState.homeToWorkController = _homeWorkController;
        
            WorkState workState = new WorkState();
            workState.A = home;
            workState.B = work;
            workState.homeToWorkController = _homeWorkController;
        
            StoreState storeState = new StoreState();
            storeState.A = work;
            storeState.B = store;
            storeState.homeToWorkController = _homeWorkController;
        
            Settings.Fsm = new FSM();
            Settings.Fsm.Add(homeState);
            Settings.Fsm.Add(workState);
            Settings.Fsm.Add(storeState);

            indexState = 0;
            Settings.Fsm.Start(stateNames[indexState]);
            Debug.Log("On WORK!!!");
        }

        [OnDelay(2f)]
        private void SwitchNextState()
        {
            ChangeState();
        }

        [OnUpdate]
        private void UpdateFSM()
        {
            Settings.Fsm.Update(Time.deltaTime);
        }

        public void ChangeState()
        {
            ++indexState;
            if (indexState.Equals(stateNames.Count))
            {
                indexState = 0;
            }
            Debug.Log(stateNames[indexState]);
            Settings.Fsm.Invoke(stateNames[indexState]);
        }
    }
}
