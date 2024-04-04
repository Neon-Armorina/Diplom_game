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
        private bool _isJumping = false;
        private float jumpCounter;
        
        private void JumpVoid()
        {
            character.rb.velocity = new Vector2 (character.rb.velocity.x, character.jumpForce);
        }

        public override void Enter()
        {
            base.Enter();
            _vecGravity = new Vector2(0, -Physics2D.gravity.y);

            jumpCounter = 0;
            character.onGround = false;
            _isJumping = true;

            Debug.Log("STATE JUMP ENTER");
            JumpVoid();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            Debug.Log(_isJumping);
            if (character.rb.velocity.y <= 0)
            {
                character.rb.velocity -= _vecGravity * character.fallMultiplier * Time.deltaTime;
                character.CheckOnGround();
            }

            if (character.onGround)
            {
                stateMachine.ChangeState(character.idleState);
            }

        }

        public override void PhysicsUpdate() 
        {
            base.PhysicsUpdate();

            float t = jumpCounter / character.jumpTimer;
            float currentJumpM = character.jumpMultiplier;

            if (Input.GetButtonUp(Jump) || !Input.GetButton(Jump))
            {
                _isJumping = false;
                jumpCounter = 0;
                if (character.rb.velocity.y > 0)
                {
                    character.rb.velocity = new Vector2(character.rb.velocity.x, character.rb.velocity.y * 0.6f);
                }
            }

            if (character.rb.velocity.y > 0 && _isJumping)
            {
                jumpCounter += Time.deltaTime;
                if (jumpCounter > character.jumpTimer) _isJumping = false;

                if (t > 0.5f)
                {
                    currentJumpM = character.jumpMultiplier * (1 - t);
                }

                character.rb.velocity += _vecGravity * Time.deltaTime * currentJumpM;
            }

        }

        public override void Exit()
        {
            base.Exit();
            character.onGround = true;
            _isJumping = false;
        }
    }
}
