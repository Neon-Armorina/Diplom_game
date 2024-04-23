using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

namespace FSM.Player
{
    public class JumpingState : MoveState
    {
        public JumpingState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }
        
        private Vector2 _vecGravity = Vector2.zero;
        public float jumpCounter;

        private void JumpVoid()
        {
            character.rb.velocity = new Vector2(character.rb.velocity.x, character.jumpForce);
        }

        private void WallJumpVoid()
        {
            character.rb.velocity = new Vector2(-_horizontalInputBeforeJump.x * character.wallJumpForce.x, character.wallJumpForce.y);
        }

        public override void Enter()
        {
            base.Enter();
            _vecGravity = new Vector2(0, -Physics2D.gravity.y);

            jumpCounter = 0;
            character.onGround = false;
            _isJumping = true;
            character.ReserMoveVelocity();
            character.TriggerAnimation(_jumpParam);


            if (character.jumpFromWall)
            {
                character.jumpFromWall = false;
                WallJumpVoid();
            }
            else
            {
                JumpVoid();
            }
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (character.rb.velocity.y <= 0)
            {
                stateMachine.ChangeState(character.fallState);
            }

            if (character.onGround && character.rb.velocity.y == 0)
            {
                stateMachine.ChangeState(character.idleState);
            }

        }

        public override void PhysicsUpdate() 
        {
            base.PhysicsUpdate();

            float t = jumpCounter / character.jumpTimer;
            float currentJumpM = character.jumpMultiplier;

            if ((Input.GetButtonUp(Jump) || !Input.GetButton(Jump)) && jumpCounter >= 0.1f)
            {
                _isJumping = false;
                jumpCounter = 0;
                if (character.rb.velocity.y > 0.01f)
                    character.rb.velocity = new Vector2(character.rb.velocity.x, character.rb.velocity.y * 0.6f);
            }

            if (character.rb.velocity.y > 0 && _isJumping)
            {
                jumpCounter += Time.deltaTime;
                if (jumpCounter > character.jumpTimer) 
                    _isJumping = false;

                if (t > 0.5f) 
                    currentJumpM = character.jumpMultiplier * (1 - t);

                if (character.rb.velocity.y > -character.maxFallSpeed)
                    character.rb.velocity += _vecGravity * Time.deltaTime * currentJumpM;
            }

        }

        public override void Exit()
        {
            base.Exit();
            _isJumping = false;
        }
    }
}
