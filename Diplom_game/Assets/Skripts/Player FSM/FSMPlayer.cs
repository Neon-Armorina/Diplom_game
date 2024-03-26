using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FSM.Scripts
{
    public class FSMPlayer : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Fsm _fsm;


        private void Start()
        {
            _fsm = new Fsm();
            _fsm.AddState(new FSMStateIdle(_fsm));
            _fsm.AddState(new FSMStateMove(_fsm, transform, _speed));

            _fsm.SetState<FSMStateIdle>();
        }


        private void Update()
        {
            _fsm.Update();
        }
    }
}


