using UnityEngine;

namespace FSM.Scripts
{
    public abstract class FSMState
    {
        protected readonly string Horizontal = "Horizontal";
        protected readonly Fsm Fsm;

        public FSMState(Fsm fsm)
        {
            Fsm = fsm;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}

