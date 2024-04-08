using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace FSM.Player
{
    public class IdleState : State
    {
        public IdleState(Character character,StateMachine stateMachine) : base(character, stateMachine) { }

        public override void Enter()
        {
            base.Enter();

            character.TriggerAnimation(_idleParam);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Input.GetAxisRaw(Horizontal) != 0 )
            {
                stateMachine.ChangeState(character.runState);

            }
            else if ((Input.GetButtonDown(Jump) || character.willJump == true) && character.onGround)
            {
                character.onGround = false;
                character.willJump = false;
                stateMachine.ChangeState(character.jumpState);
            }
        }
    }
}


