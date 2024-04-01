using UnityEngine;

namespace FSM.Player
{
    public class StateMachine
    {
        public State CurrentState { get; private set; }

        public void Initialize(State StartingState)
        {
            CurrentState = StartingState;
            StartingState.Enter();
        }

        public void ChangeState(State NewState)
        {
            CurrentState.Exit();

            CurrentState = NewState;
            NewState.Enter();
        }
    }
}