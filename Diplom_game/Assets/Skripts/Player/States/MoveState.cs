using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class MoveState : State
    {
        public MoveState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

        protected Vector2 horizontalInput;
        protected Vector2 LastInput;
        protected Vector2 _horizontalInputBeforeJump = Vector2.zero;
        protected bool _isJumping = false;

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit() 
        {
           base.Exit();
        }

        public override void HandleInput()
        {
            base.HandleInput();
            LastInput = horizontalInput;
            horizontalInput.x = Input.GetAxisRaw(Horizontal);
            horizontalInput.y = 0;
            horizontalInput.Normalize();

            if (horizontalInput.x != 0 && horizontalInput != LastInput)
                character.Flip(horizontalInput.x);

            if (Input.GetButtonDown(Jump))
            {
                character.willJump = true;
                _horizontalInputBeforeJump = horizontalInput.normalized;
                character.StartCoroutine(character.timeToJump(character.timeToCheckJumpBefore));
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

            character.Move(horizontalInput);

            if (character.rb.velocity.y < -character.maxFallSpeed)
                character.rb.velocity = new Vector2(character.rb.velocity.x, -character.maxFallSpeed);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (character.onWall && character.rb.velocity.y < 0 && horizontalInput.x != 0 && !_isJumping)
                stateMachine.ChangeState(character.slideState);

            if (Input.GetButtonDown(Attack) && character.onGround)
            {
                character.TriggerAnimation(_punchParam);
                stateMachine.ChangeState(character.attackState);
            }
                

            if ((Input.GetButtonDown(Jump) || character.willJump == true) && character.onGround)
            {
                character.willJump = false;
                stateMachine.ChangeState(character.jumpState);
            }
        }

        
    }
}

