using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.Player
{
    public class RunState : MoveState
    {
        public RunState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

        public override void Enter()
        {
            base.Enter();

            character.jumpFromWall = false;
            character.TriggerAnimation(_runParam);
        }

        public override void Exit() 
        { 
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (character.rb.velocity.x <= 0.01f && !Input.GetButton(Horizontal))
                stateMachine.ChangeState(character.idleState);


            if (character.rb.velocity.y < -0.1f && !character.onGround)
            {
                character.abstractGround = true;
                character.StartCoroutine(character.timeNoGround(character.timeToCheckJumpAfter));
                stateMachine.ChangeState(character.fallState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
        
        public override void HandleInput()
        {
            base.HandleInput();
        }
    }
}


