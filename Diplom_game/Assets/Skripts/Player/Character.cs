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

        [Header("Move info")]
            public float moveSpeed;
            [NonSerialized] public bool faceright = true;
            public GameObject spawnPoint;
            public float stepTimer;

        [Header("Jump info")]
            public float jumpForce;
            public float jumpMultiplier;

            [Tooltip("Displays how long player can hold jump to jump higher")]
            public float jumpTimer;

            [Tooltip("Shows how far in advance the player can press the jump")]
            public float timeToCheckJumpBefore;

            [Tooltip("�hows the time during which the player can jump after exiting the platform")]
            public float timeToCheckJumpAfter;


        [Header("Fall info")]
            public float fallMultiplier;
            public float maxFallSpeed;

        [Header("Lerge info")]
            [SerializeField] private Vector2 _offset1;
            [SerializeField] private Vector2 _offset2;
            private Vector2 climbBegunPosition;
            private Vector2 climbOverPosition;
            private bool canGrabLedge = true;
            private bool canClimb;

        [Header("Wall info")]
            public float slideSpeed;
            public Vector2 wallJumpForce;
            [NonSerialized] public bool onGround;
            [NonSerialized] public bool abstractGround;
            [NonSerialized] public bool onWall;
            [NonSerialized] public bool LedgeDetected;
            [NonSerialized] public bool jumpFromWall = false;
            [NonSerialized] public bool willJump = false;

        [Header("Combat Info")]
            [SerializeField] private Transform _punchPoint;
            [SerializeField] private float _punchRadius;
            [SerializeField] public static float _punchforce = 2;
            [SerializeField] private LayerMask _whatIsEnemy;

        [Header("Required Components")]
            public Animator anim;
            public Rigidbody2D rb;
            [SerializeField] private Collider _hitBox;
            [SerializeField] private LayerMask _whatIsGround;
            [SerializeField] private Transform _groundFinder;
            [SerializeField] private Transform _wallFinder;
            [NonSerialized] public SoundManager soundManager;


        [Header("States info")]
            [NonSerialized] public StateMachine movementSM;
            [NonSerialized] public IdleState idleState;
            [NonSerialized] public RunState runState;
            [NonSerialized] public JumpingState jumpState;
            [NonSerialized] public ClimbingState climbState;
            [NonSerialized] public SlidingState slideState;
            [NonSerialized] public FallState fallState;
            [NonSerialized] public AttackState attackState;

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
                transform.Translate(moveSpeed * vector2 * Time.deltaTime);
            }
        }

        public void Flip(float Flipint)
        {
            transform.localScale = new Vector2(Flipint, 1);
            faceright = !faceright;
            Debug.Log("flip");
        }

        public void ReserMoveVelocity()
        {
            rb.velocity = Vector2.zero;
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

        public void PunchVoid()
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_punchPoint.position, _punchRadius, _whatIsEnemy);

            foreach(Collider2D hit in hitEnemies) 
            {
                hit.GetComponent<EnemyCombat>().TakePunch();
            }
        }

        public void PlaySound(AudioClip audio)
        {
            soundManager.PlaySFX(audio);
        }

        public void PlayStepSound()
        {
            soundManager.PlaySFX(soundManager.PlayerStepSound);
        }

        public void StopSound()
        {
            soundManager.StopSFX();
        }

        #endregion

        #region Monobehaviour Callbacks

        private void Awake()
        {
            soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
        }

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
            attackState = new AttackState(this, movementSM);

            movementSM.Initialize(idleState);

            transform.position = spawnPoint.transform.position;

        }

        private void Update()
        {
            onGround = Physics2D.OverlapBox(_groundFinder.position, new Vector2(0.0005f, 0.001f), 0, _whatIsGround);
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


