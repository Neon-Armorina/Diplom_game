using Unity.Burst;
using UnityEngine;
using UnityEngine.UIElements;

namespace FSM.Player
{
    public class Character : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Animator _anim;
        [SerializeField] private Collider _hitBox;
        [SerializeField] public float jumpForce;
        [SerializeField] public float fallMultiplier;
        [SerializeField] public float jumpMultiplier;
        [SerializeField] public float jumpTimer;
        [SerializeField] public float moveSpeed;
        [SerializeField] public float climbSpeed;
        [SerializeField] public float slideSpeed;
        [SerializeField] private ContactFilter2D _whatIsGround;
        [SerializeField] private ContactFilter2D _whatIsWall;
        [SerializeField] private Collider2D _groundFinder;
        [SerializeField] private Collider2D _wallFinder;

        public Rigidbody2D rb;
        public bool onGround;

        public StateMachine movementSM;

        public IdleState idleState;
        public RunState runState;
        public JumpingState jumpState;
        public ClimbingState climbState;
        public SlidingState slideState;

        #endregion

        #region Methods

        public void Move(Vector2 vector2)
        {
            transform.Translate(moveSpeed * vector2 * Time.deltaTime, Space.World);
        }

        public void ResetMoveParams()
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        public void ApplyImpulse(float force)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }

        public void SetAnimationBool(int param, bool value)
        {
            _anim.SetBool(param, value);
        }

        public void TriggerAnimation(int param)
        {
            _anim.SetTrigger(param);
        }

        public void CheckOnGround()
        {
            Collider2D[] overlapCollliders = new Collider2D[4];
            if (Physics2D.OverlapCollider(_groundFinder, _whatIsGround, overlapCollliders) > 0)
            {
                onGround = true;
            }

            return;
        }
        public void CheckOnWall()
        {
            Collider2D[] overlapCollliders = new Collider2D[4];
            if (Physics2D.OverlapCollider(_wallFinder, _whatIsWall, overlapCollliders) > 0)
            {
                Debug.Log("—“≈Õ¿");
                return;
            }
        }

        #endregion

        #region Monobehaviour Callbacks

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            movementSM = new StateMachine();

            idleState = new IdleState(this, movementSM);
            runState = new RunState(this, movementSM);
            jumpState = new JumpingState(this, movementSM);
            climbState = new ClimbingState(this, movementSM);
            slideState = new SlidingState(this, movementSM);

            movementSM.Initialize(idleState);

        }

        private void Update()
        {
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


