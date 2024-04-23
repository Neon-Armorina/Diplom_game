using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.Player
{
    public class FallState : MoveState
    {
        public FallState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

        private Vector2 _vecGravity = Vector2.zero;
        private Vector2 _normalVelocity = Vector2.zero;

        public override void Enter()
        {
            base.Enter();

            _vecGravity = new Vector2(0, -Physics2D.gravity.y);
            character.ReserMoveVelocity();
            character.TriggerAnimation(_fallParam);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base .LogicUpdate();

            if (character.abstractGround && Input.GetButtonDown(Jump) && character.onWall)
            {
                character.jumpFromWall = true;
                stateMachine.ChangeState(character.jumpState);
            }
            else if (character.abstractGround && Input.GetButtonDown(Jump))
                stateMachine.ChangeState(character.jumpState);

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

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            if (character.rb.velocity.y < -character.maxFallSpeed)
                character.rb.velocity -= _vecGravity * character.fallMultiplier * Time.deltaTime;
        }
    }
}

