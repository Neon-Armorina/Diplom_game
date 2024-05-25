using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.Player
{
    public class SlidingState : OnWallState
    {
        public SlidingState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }

        private Vector2 _normalVelocity = Vector2.zero;
        private float _freezedX = 0f;

        public override void Enter()
        {
            base.Enter();

            Debug.Log("SLIDE");
            character.PlaySound(character.soundManager.PlayerSlideSound);
            _freezedX = character.rb.position.x;
            _horizontalInputBeforeJump = horizontalInput;
            character.ReserMoveVelocity();
            _normalVelocity = character.rb.velocity;
            character.TriggerAnimation(_slideParam);
        }

        public override void Exit() 
        { 
            base.Exit();

            character.StopSound();
            character.TriggerAnimation(_landParam);
            character.rb.velocity = new Vector2(character.rb.velocity.x, _normalVelocity.y);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            character.rb.position = new Vector2(_freezedX, character.rb.position.y);

            if (character.onGround)
            {
                character.TriggerAnimation(_landParam);
                stateMachine.ChangeState(character.idleState);
            }

            if (Input.GetButtonDown(Jump) || character.willJump)
            {
                character.willJump = false;
                character.jumpFromWall = true;
                stateMachine.ChangeState(character.jumpState);
            }

            if (!character.onWall || horizontalInput.x != _horizontalInputBeforeJump.x)
            {
                character.jumpFromWall = true;
                character.abstractGround = true;
                character.StartCoroutine(character.timeNoGround(character.timeToCheckJumpAfter +0.1f));
                stateMachine.ChangeState(character.fallState);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            
            character.rb.velocity = new Vector2(character.rb.velocity.x, Mathf.Clamp(character.rb.velocity.y, -character.slideSpeed, float.MaxValue));
        }

    }
}
