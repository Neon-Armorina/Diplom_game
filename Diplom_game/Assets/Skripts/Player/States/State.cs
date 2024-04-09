using Unity;
using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public abstract class State 
    {
        public readonly string Vertical = "Vertical";
        public readonly string Horizontal = "Horizontal";
        public readonly string Jump = "Jump";

        protected int _idleParam = Animator.StringToHash("Idle");
        protected int _runParam = Animator.StringToHash("Run");
        protected int _jumpParam = Animator.StringToHash("Jump");
        protected int _landParam = Animator.StringToHash("Land");
        protected int _fallParam = Animator.StringToHash("Fall");
        protected int _slideParam = Animator.StringToHash("Slide");

        protected Character character;
        protected StateMachine stateMachine;

        protected State(Character character, StateMachine stateMachine) 
        {
            this.character = character;
            this.stateMachine = stateMachine;
        }

        public virtual void Enter()
        {

        }

        public virtual void Exit() 
        {
            
        }

        public virtual void HandleInput()
        {

        }

        public virtual void LogicUpdate()
        {
            //Debug.LogFormat(character.onGround + "   " + character.onWall + "   " + stateMachine.CurrentState);
        }

        public virtual void PhysicsUpdate() 
        {

        }
    }
}

