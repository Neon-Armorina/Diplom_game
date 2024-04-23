using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace FSM.Player
{
    public class IdleState : MoveState
    {
        public IdleState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

        public override void Enter()
        {
            base.Enter();
            character.ReserMoveVelocity();
            character.anim.ResetTrigger(_runParam);
            character.TriggerAnimation(_idleParam);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            character.TriggerAnimation(_idleParam);
            if (Input.GetAxisRaw(Horizontal) != 0 )
                stateMachine.ChangeState(character.runState);

            if (!character.onGround)
                stateMachine.ChangeState(character.fallState);

            if (Input.GetButtonDown(Jump) || character.willJump)
                stateMachine.ChangeState(character.jumpState);
        }
    }
}


