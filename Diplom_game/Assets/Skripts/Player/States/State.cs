using UnityEngine;
using UnityEngine.TextCore.Text;

namespace FSM.Player
{
    public abstract class State 
    {
        public readonly string Vertical = "Vertical";
        public readonly string Horizontal = "Horizontal";
        public readonly string Jump = "Jump";

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

