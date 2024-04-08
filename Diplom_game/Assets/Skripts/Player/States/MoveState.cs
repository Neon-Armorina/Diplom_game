using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class MoveState : State
    {
        public MoveState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

        protected Vector2 horizontalInput;

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
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            character.Move(horizontalInput.normalized);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (horizontalInput.x == 0 && character.onGround && character.rb.velocity == Vector2.zero)
            {
                stateMachine.ChangeState(character.idleState);
            }
        }
    }
}

