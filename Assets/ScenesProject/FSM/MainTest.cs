
using System.Collections.Generic;
using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using AxGrid.Tools.Binders;
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
        
            GoingHomeState homeStateGoing = new GoingHomeState();
            homeStateGoing.A = store;
            homeStateGoing.B = home;
            homeStateGoing.homeToWorkController = _homeWorkController;
            
            OnHome _homeState = new OnHome();
            _homeState._homeToWork = _homeWorkController;
        
            GoingWorkState workStateGoing = new GoingWorkState();
            workStateGoing.A = home;
            workStateGoing.B = work;
            workStateGoing.homeToWorkController = _homeWorkController;
            
            OnWork _workState = new OnWork();
            _workState._homeToWork = _homeWorkController;
        
            GoingStoreState storeStateGoing = new GoingStoreState();
            storeStateGoing.A = work;
            storeStateGoing.B = store;
            storeStateGoing.homeToWorkController = _homeWorkController;
            
            OnStore _storeState = new OnStore();
            _storeState._homeToWork = _homeWorkController;
        
            Settings.Fsm = new FSM();
            Settings.Fsm.Add(homeStateGoing);
            Settings.Fsm.Add(_homeState);
            Settings.Fsm.Add(workStateGoing);
            Settings.Fsm.Add(_workState);
            Settings.Fsm.Add(storeStateGoing);
            Settings.Fsm.Add(_storeState);

            indexState = 0;
            Settings.Fsm.Start(stateNames[indexState]);
            Debug.Log("On WORK!!!");
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
            Settings.Fsm.Change(stateNames[indexState]);
        }

        [Bind("Work")]
        private void GoWork()
        {
            ChangeIndex("Work");
            Settings.Fsm.Change("GoingWork");
        }
        
        [Bind("Store")]
        private void GoStore()
        {
            ChangeIndex("Store");
            Settings.Fsm.Change("Going Store");
        }
        
        private void ChangeIndex(string s)
        {
            for (int i = 0; i < stateNames.Count; ++i)
            {
                if (stateNames[i].Equals(s))
                {
                    indexState = i;
                }
            }
        }
    }
}
