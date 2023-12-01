using UnityEngine;

namespace Wai
{
    [RequireComponent(typeof(Controller))]
    public class Jump : MonoBehaviour
    {

        public AudioClip jump;
        public AudioSource sfx;

        [SerializeField] public float _jumpHeight = 3f;
        [SerializeField] private int _maxAirJumps = 0;
        [SerializeField] public float _downwardMovementMultiplier = 3f;
        [SerializeField] public float _upwardMovementMultiplier = 1.7f;
        [SerializeField] private float _coyoteTime = 0.01f;
        [SerializeField] private float _jumpBufferTime = 0.2f;

        private Controller _controller;
        private Rigidbody2D _body;
        private Ground _ground;
        private Vector2 _velocity;

        private int _jumpPhase;
        private float _defaultGravityScale, _jumpSpeed, _coyoteCounter, _jumpBufferCounter;

        private bool _desiredJump, _onGround, _isJumping;


        // Start is called before the first frame update
        void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
            _ground = GetComponent<Ground>();
            _controller = GetComponent<Controller>();

            _defaultGravityScale = 20f;
        }

        // Update is called once per frame
        void Update()
        {
            _desiredJump |= _controller.input.RetrieveJumpInput();
        }

        private void FixedUpdate()
        {

            

            
                


            _onGround = _ground.OnGround;
            _velocity = _body.velocity;

            if (_onGround && _body.velocity.y == 0)
            {
                _jumpPhase = 0;
                _coyoteCounter = _coyoteTime;
                _isJumping = false;
            }
            else
            {
                _coyoteCounter -= Time.deltaTime;
            }

            if (_desiredJump)
            {
                _desiredJump = false;
                _jumpBufferCounter = _jumpBufferTime;
            }
            else if(!_desiredJump && _jumpBufferCounter > 0)
            {
                _jumpBufferCounter -= Time.deltaTime;
            }

            if(_jumpBufferCounter > 0)
            {
                JumpAction();
            }

            if (_controller.input.RetrieveJumpHoldInput() && _body.velocity.y > 0)
            {
                _body.gravityScale = _upwardMovementMultiplier;
                
            }
            else if (!_controller.input.RetrieveJumpHoldInput() || _body.velocity.y < 0)
            {
                _body.gravityScale = _downwardMovementMultiplier;
            }
            else if(_body.velocity.y == 0)
            {
                _body.gravityScale = _defaultGravityScale;
            }

            _body.velocity = _velocity;
        }
        private void JumpAction()
        {

            sfx.clip = jump;
            sfx.Play();

            if (_coyoteCounter > 0f || (_jumpPhase < _maxAirJumps && _isJumping))
            {
                if(_isJumping)
                {
                    _jumpPhase += 1;
                }

                _jumpBufferCounter = 0;
                _coyoteCounter = 0;
                _jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * _jumpHeight);
                _isJumping = true;
                
                if (_velocity.y > 0f)
                {
                    _jumpSpeed = Mathf.Max(_jumpSpeed - _velocity.y, 0f);
                }
                else if (_velocity.y < 0f)
                {
                    _jumpSpeed += Mathf.Abs(_body.velocity.y);
                }
                _velocity.y += _jumpSpeed;
            }
        }
    }
}

