using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.Player
{
    public class RunState : MoveState
    {
        public RunState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

        private float _timerBeforeJump = 0f;

        public override void Enter()
        {
            base.Enter();
            Debug.Log("STATE RUN ENTER");
            character.TriggerAnimation(_runParam);
            character.SetAnimationBool(_isRunningParam, true);
        }

        public override void Exit() 
        { 
            base.Exit();
            Debug.Log("STATE RUN EXIT");
            character.SetAnimationBool(_isRunningParam, false);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

//            if (Input.GetButtonDown(Jump))
  //          {
 //               _timerBeforeJump += Time.deltaTime;
 //           }

            if (Input.GetButtonDown(Jump) && character.onGround)
            {
                stateMachine.ChangeState(character.jumpState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            character.CheckOnGround();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }
    }
}


