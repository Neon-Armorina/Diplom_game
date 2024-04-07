using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.Player
{
    public class FallState : MoveState
    {
        public FallState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

        private Vector2 _vecGravity = Vector2.zero;

        public override void Enter()
        {
            base.Enter();
            _vecGravity = new Vector2(0, -Physics2D.gravity.y);
            character.TriggerAnimation(_fallParam);
        }

        public override void Exit()
        {
            base.Exit();
            character.TriggerAnimation(_landParam);
        }

        public override void LogicUpdate()
        {
            base .LogicUpdate();
//            if (character.rb.velocity.y >= 0.1f)
//            {
//                character.rb.velocity -= _vecgravity * character.fallmultiplier * time.deltatime;
//            }
            character.rb.velocity -= _vecGravity * character.fallMultiplier * Time.deltaTime;
            character.CheckOnGround();

            if (character.onGround)
            {
                stateMachine.ChangeState(character.idleState);
            }
        }
    }
}

