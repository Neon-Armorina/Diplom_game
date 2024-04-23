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
        public readonly string Attack = "Attack";

        protected int _idleParam = Animator.StringToHash("Idle");
        protected int _runParam = Animator.StringToHash("Run");
        protected int _jumpParam = Animator.StringToHash("Jump");
        protected int _landParam = Animator.StringToHash("Land");
        protected int _fallParam = Animator.StringToHash("Fall");
        protected int _slideParam = Animator.StringToHash("Slide");
        protected int _punchParam = Animator.StringToHash("Punch");

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

        }

        public virtual void PhysicsUpdate() 
        {

        }
    }
}

