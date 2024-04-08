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
        }

        public override void LogicUpdate()
        {
            base .LogicUpdate();

            character.rb.velocity -= _vecGravity * character.fallMultiplier * Time.deltaTime;

            if (character.onGround)
            {
                character.TriggerAnimation(_landParam);
                stateMachine.ChangeState(character.idleState);
            }
        }
        public override void HandleInput()
        {
            base.HandleInput();
        }
    }
}

