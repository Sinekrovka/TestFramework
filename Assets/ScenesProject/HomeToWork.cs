using AxGrid.Base;
using AxGrid.Model;
using AxGrid.Path;
using UnityEngine;

namespace Test
{
    public class HomeToWork : MonoBehaviourExt2D
    {
        private Transform A;
        private Transform B;
        
        [SerializeField] private Transform _player;
        [SerializeField] private float time;
    
        private float X;
        private float Y;

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
        
        public void MovementCorutine()
        {
            Path = new CPath();
            Path.Action(GoingToX)
                .EasingLinear(time, A.position.x, B.position.x, _X => MovementX(_X))
                .EasingLinear(time, A.position.y, B.position.y, _Y => MovementY(_Y))
                .Wait(1f).Action(ChangeWalking);
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
            Path = new CPath();
            Debug.Log("Change State");
            MainTest.Inst.ChangeState();
        }
    }

}
