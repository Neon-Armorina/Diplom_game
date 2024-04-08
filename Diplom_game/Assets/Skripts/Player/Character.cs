using System;
using System.Collections;
using UnityEngine;

namespace FSM.Player
{
    public class Character : MonoBehaviour
    {
        #region Variables

        public Animator anim;
        public float jumpForce;
        public float timeToCheckJumpBefore;
        public float timeToCheckJumpAfter;
        public float fallMultiplier;
        public float jumpMultiplier;
        public float jumpTimer;
        public float moveSpeed;
        public float climbSpeed;
        public float slideSpeed;
        public Rigidbody2D rb;

        private bool _faceright = true;

        [SerializeField] private Collider _hitBox;
        [SerializeField] private ContactFilter2D _whatIsGround;
        [SerializeField] private Transform _groundFinder;
        [SerializeField] private Transform _wallFinder;

        [NonSerialized] public bool onGround;
        [NonSerialized] public bool abstractGround;
        [NonSerialized] public bool onWall;
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

        public void Flip(Vector2 vector2)
        {
            if ((vector2.x > 0 && !_faceright) || (vector2.x < 0 && _faceright))
            {
                transform.localScale *= new Vector2(-1, 1);
                _faceright = !_faceright;
            }
        }

        public void ApplyImpulse(float force)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force), ForceMode2D.Impulse);
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
            onGround = Physics2D.OverlapBox(_groundFinder.position, new Vector2(0.01f, 0.01f), 0, _whatIsGround.layerMask);
            onWall = Physics2D.OverlapBox(_wallFinder.position, new Vector2(0.03f, 0.1f), 0, _whatIsGround.layerMask);

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


