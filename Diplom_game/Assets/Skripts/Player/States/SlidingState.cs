using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.Player
{
    public class SlidingState : OnWallState
    {
        public SlidingState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }


    }
}
