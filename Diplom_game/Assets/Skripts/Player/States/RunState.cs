using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.Player
{
    public class RunState : MoveState
    {
        public RunState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

        private float _timerBeforeJump = 0f;
        private int _animTrigger = 0;

        public override void Enter()
        {
            base.Enter();

            _animTrigger = 0;

            if (character.onGround)
            {
                character.TriggerAnimation(_runParam);
                character.SetAnimationBool(_isRunningParam, true);
            }
        }

        public override void Exit() 
        { 
            base.Exit();
            character.SetAnimationBool(_isRunningParam, false);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_animTrigger == 0 && character.onGround)
            {
                _animTrigger = 1;
            }

            if (_animTrigger == 1) 
            {
                _animTrigger = 2;
                character.TriggerAnimation(_runParam);
                character.SetAnimationBool(_isRunningParam, true);
            }

            if (Input.GetButtonDown(Jump) && character.onGround)
            {
                stateMachine.ChangeState(character.jumpState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            character.CheckOnGround();
            if (character.rb.velocity.x <= 0.01f && !Input.GetButton(Horizontal))
            {
                stateMachine.ChangeState(character.idleState);
            }
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }
    }
}


