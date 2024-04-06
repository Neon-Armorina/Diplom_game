using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.Player
{
    public class IdleState : State
    {
        public IdleState(Character character,StateMachine stateMachine) : base(character, stateMachine) { }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("STATE IDLE ENTER");
            character.TriggerAnimation(_idleParam);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Input.GetAxisRaw(Horizontal) != 0 )
            {
                stateMachine.ChangeState(character.runState);

            }
            else if (Input.GetButtonDown(Jump))
            {
                stateMachine.ChangeState(character.jumpState);
            }
        }
    }
}


