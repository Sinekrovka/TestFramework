using AxGrid.Base;
using AxGrid.Model;
using AxGrid.Path;
using UnityEngine;
using UnityEngine.UI;

namespace Test
{
    public class HomeToWork : MonoBehaviourExt2D
    {
        private Transform A;
        private Transform B;

        [SerializeField] private int money;
        [SerializeField] private Text textMoney;
        
        [SerializeField] private Transform _player;
        [SerializeField] private float time;
    
        private float X;
        private float Y;

        private int countCurrentMoney;
        private int countIncrementMoney;

        [OnAwake]
        private void SetCountsXY()
        {
            X = _player.position.x;
            Y = _player.position.y;
            
        }
    
        public void SetA(Transform other)
        {
            A = other;
        }
    
        public void SetB(Transform other)
        {
            B = other;
        }

        public void SetIncrement(int inc)
        {
            countIncrementMoney = inc;
        }

        [OnUpdate]
        private void MoneyController()
        {
            countCurrentMoney += countIncrementMoney * money;
            textMoney.text = "Money: " + countCurrentMoney;

        }
        
        
        public void MovementCorutine()
        {
            Path = new CPath();
            Path.Action(GoingToX)
                .EasingLinear(time, A.position.x, B.position.x, _X => MovementX(_X))
                .EasingLinear(time, A.position.y, B.position.y, _Y => MovementY(_Y))
                .Action(ChangeWalking);
        }
    
        private void GoingToX()
        {
            print("!!!");
        }
        private float MovementX(float z)
        {
            float zz = z;
            X = zz;
            Movement();
            return zz;
        }
    
        private float MovementY(float z)
        {
            float zz = z;
            Y = zz;
            Movement();
            return zz;
        }
    
        private void Movement()
        {
            _player.position = new Vector3(X, Y);
        }
    
        private void ChangeWalking()
        {
            MainTest.Inst.ChangeState();
        }

        public void WaitOnState(float time)
        {
            Path = new CPath();
            Path.Action(GoingToX).Wait(time).Action(ChangeWalking);
        }
    }

}
