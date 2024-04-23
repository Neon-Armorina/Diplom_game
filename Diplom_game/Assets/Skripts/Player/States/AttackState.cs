using UnityEngine;

namespace FSM.Player
{
    public class AttackState : MoveState
    {
        public AttackState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

        private float normalMoveSpeed;
        private float moveSpeedDecreaser = 3;

        public override void Enter()
        {
            base.Enter();
            character.ReserMoveVelocity();
            character.TriggerAnimation(_punchParam);

            normalMoveSpeed = character.moveSpeed;
            character.moveSpeed = normalMoveSpeed / moveSpeedDecreaser;
        }

        public override void Exit() 
        {
            character.moveSpeed = normalMoveSpeed;
            base.Exit();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!character.anim.GetCurrentAnimatorStateInfo(0).IsName("Player_punch"))
                stateMachine.ChangeState(character.idleState);

            Debug.Log("elfkkkk");
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();

        }

    }


}


