using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.Player
{
    public class OnWallState : MoveState
    {
        public OnWallState(Character character, StateMachine stateMachine) : base(character,stateMachine) { }


    }
}
