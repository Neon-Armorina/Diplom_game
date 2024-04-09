using System;
using System.Collections;
using System.ComponentModel;
using Unity.Mathematics;
using UnityEngine;

namespace FSM.Player
{
    public class Character : MonoBehaviour
    {
        #region Variables
        
        [Header("Jump and fall parameters")]
        public float jumpForce;
        [Tooltip("Shows how far in advance the player can press the jump")]
        public float timeToCheckJumpBefore;
        [Tooltip("Ûhows the time during which the player can jump after exiting the platform")]
        public float timeToCheckJumpAfter;
        public float fallMultiplier;
        public float maxFallSpeed;
        public float jumpMultiplier;
        [Tooltip("Displays how long player can hold jump to jump higher")]
        public float jumpTimer;
        public float moveSpeed;
        public float slideSpeed;
        public Vector2 wallJumpForce;

        private bool _faceright = true;

        [Header("Required Components")]
        public Animator anim;
        public Rigidbody2D rb;
        [SerializeField] private Collider _hitBox;
        [SerializeField] private LayerMask _whatIsGround;
        [SerializeField] private Transform _groundFinder;
        [SerializeField] private Transform _wallFinder;

        [NonSerialized] public bool onGround;
        [NonSerialized] public bool abstractGround;
        [NonSerialized] public bool onWall;
        [NonSerialized] public bool jumpFromWall = false;
        [NonSerialized] public bool willJump = false;
        [NonSerialized] public StateMachine movementSM;
        [NonSerialized] public IdleState idleState;
        [NonSerialized] public RunState runState;
        [NonSerialized] public JumpingState jumpState;
        [NonSerialized] public ClimbingState climbState;
        [NonSerialized] public SlidingState slideState;
        [NonSerialized] public FallState fallState;

        public IEnumerator timeToJump(float time)
        {
            yield return new WaitForSeconds(time);
            willJump = false;
        }

        public IEnumerator timeNoGround(float time)
        {
            yield return new WaitForSeconds(time);
            abstractGround = false;
        }

        #endregion

        #region Methods

        public void Move(Vector2 vector2)
        {
            if (vector2.x != 0)
            {
                transform.Translate(moveSpeed * vector2 * Time.deltaTime, Space.World);
                Flip(vector2);
            }
        }

        public void ReserMoveVelocity()
        {
            rb.velocity = Vector2.zero;
        }

        public void Flip(Vector2 vector2)
        {
            if ((vector2.x > 0 && !_faceright) || (vector2.x < 0 && _faceright))
            {
                transform.localScale *= new Vector2(-1, 1);
                _faceright = !_faceright;
            }
        }

        public void SetAnimationBool(int param, bool value)
        {
            anim.SetBool(param, value);
        }

        public void TriggerAnimation(int param)
        {
            if (param != Animator.StringToHash("Idle"))
            {
                foreach (AnimatorControllerParameter p in anim.parameters)
                    if (p.type == AnimatorControllerParameterType.Trigger)
                        anim.ResetTrigger(p.name);
            }   
            anim.SetTrigger(param);
        }

        #endregion

        #region Monobehaviour Callbacks

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            movementSM = new StateMachine();

            idleState = new IdleState(this, movementSM);
            runState = new RunState(this, movementSM);
            fallState = new FallState(this, movementSM);
            jumpState = new JumpingState(this, movementSM);
            climbState = new ClimbingState(this, movementSM);
            slideState = new SlidingState(this, movementSM);

            movementSM.Initialize(idleState);

        }

        private void Update()
        {
            onGround = Physics2D.OverlapBox(_groundFinder.position, new Vector2(0.01f, 0.01f), 0, _whatIsGround);
            onWall = Physics2D.OverlapBox(_wallFinder.position, new Vector2(0.03f, 0.1f), 0, _whatIsGround);

            movementSM.CurrentState.HandleInput();
            movementSM.CurrentState.LogicUpdate();
        }

        private void FixedUpdate()
        {
            movementSM.CurrentState.PhysicsUpdate();
        }

        #endregion
    }
}


