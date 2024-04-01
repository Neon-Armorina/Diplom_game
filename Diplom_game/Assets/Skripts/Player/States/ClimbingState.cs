using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.Player
{
    public class ClimbingState : OnWallState
    {
        public ClimbingState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }


    }
}
