using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class MoveState : State
    {
        public MoveState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

        protected Vector2 horizontalInput;
        protected Vector2 _horizontalInputBeforeJump = Vector2.zero;

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
            horizontalInput.x = Input.GetAxisRaw(Horizontal);
            horizontalInput.Normalize();
            if (Input.GetButtonDown(Jump))
            {
                character.willJump = true;
                character.StartCoroutine(character.timeToJump(character.timeToCheckJumpBefore));
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            character.Move(horizontalInput);

            if (character.rb.velocity.y < -character.maxFallSpeed)
            {
                character.rb.velocity = new Vector2(character.rb.velocity.x, -character.maxFallSpeed);
            }
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (horizontalInput.x == 0 && character.onGround && character.rb.velocity == Vector2.zero)
            {
                stateMachine.ChangeState(character.idleState);
            }

            if (!character.onGround && character.onWall && horizontalInput.x != 0 && character.rb.velocity.y <= 0)
            {
                stateMachine.ChangeState(character.slideState);
            }
        }
    }
}

