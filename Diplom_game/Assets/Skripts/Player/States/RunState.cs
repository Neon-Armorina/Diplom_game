using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.Player
{
    public class RunState : MoveState
    {
        public RunState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("STATE RUN ENTER");
        }

        public override void Exit() 
        { 
            base.Exit();
            Debug.Log("STATE RUN EXIT");
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Input.GetButtonDown(Jump))
            {
                stateMachine.ChangeState(character.jumpState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }
    }
}


