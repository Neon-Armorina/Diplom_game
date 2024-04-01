using UnityEngine;

namespace FSM.Player
{
    public class MoveState : State
    {
        public MoveState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

        protected float speed;

        protected Vector2 horizontalInput;

        public override void Enter()
        {
            base.Enter();
            horizontalInput.x = 0;
        }

        public override void Exit() 
        {
           base.Exit(); 
        character.ResetMoveParams();
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
            if (horizontalInput.x == 0 && character.onGround)
            {
                stateMachine.ChangeState(character.idleState);
            }
        }
    }
}

