using UnityEngine;

namespace FSM.Scripts
{
    public class FSMStateIdle : FSMState
    {
        public FSMStateIdle(Fsm fsm) : base(fsm) { }

        public override void Enter()
        {
            Debug.Log("idle [Enter]");
        }

        public override void Exit()
        {
            Debug.Log("Idle [Exit]");
        }

        public override void Update()
        {
            Debug.Log("Idle [Update]");

            if (Input.GetAxis(Horizontal) != 0)
            {
                Fsm.SetState<FSMStateMove>();
            }
        }
    }
}

