using JetBrains.Annotations;
using System.Collections;
using UnityEngine.Audio;

using UnityEngine;

namespace Wai
{
    [RequireComponent(typeof(Controller))]
    public class Move : MonoBehaviour
    {



        public LogicScript logic;

        public ParticleSystem dust;
        Animator anim;

        [SerializeField] public float _maxSpeed = 4f;
        [SerializeField] private float _maxAcceleration = 35f;
        [SerializeField] private float _maxAirAcceleration = 20f;
        [SerializeField] private float sizeChange;
        
        [SerializeField] private bool _active = true;

        private Controller _controller;
        private Vector2 _direction, _desiredVelocity, _velocity;
        private Rigidbody2D _body;
        private Ground _ground;
        private Jump _jump;
        private Collider2D _collider;
        private Vector2 _respawnPoint;
        



        private float _maxSpeedChange, _acceleration;
        private bool _onGround;

        private bool isFacingRight = true;

        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
            _ground = GetComponent<Ground>();
            _controller = GetComponent<Controller>();
            _jump = GetComponent<Jump>();
            anim = GetComponent<Animator>();
            _collider = GetComponent<Collider2D>();

            setRespawnPoint(transform.position);
        }

        private void Update()
        {
            _direction.x = _controller.input.RetrieveMoveInput();
            _desiredVelocity = new Vector2(_direction.x, 0f) * Mathf.Max(_maxSpeed - _ground.Friction, 0f);

            Flip();

            if(_controller.input.RetrieveMoveInput() == 0)
            {
                anim.SetBool("isRunning", false);

            }
            else
            {
                anim.SetBool("isRunning", true);
                if(_onGround)
                {
                    CreateDUst();
                }
            }

            if(!_active)
            {
                return;
            }

            

        }

        public void setRespawnPoint(Vector2 position)
        {
            _respawnPoint = position;
        }

        private IEnumerator Respawn()
        {
            yield return new WaitForSeconds(0.3f);
            transform.position = _respawnPoint;
            _active = true;
            _collider.enabled = true;
            MiniJump();
        }

        private void FixedUpdate()
        {
            _onGround = _ground.OnGround;
            _velocity = _body.velocity;

            _acceleration = _onGround ? _maxAcceleration : _maxAirAcceleration;
            _maxSpeedChange = _acceleration * Time.deltaTime;
            _velocity.x = Mathf.MoveTowards(_velocity.x, _desiredVelocity.x, _maxSpeedChange);

            _body.velocity = _velocity;


        }

        

        private void Flip()
        {
            if (isFacingRight && _controller.input.RetrieveMoveInput() < 0f || !isFacingRight && _controller.input.RetrieveMoveInput() > 0f)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;


            }
        }

        private void MiniJump()
        {
            _body.velocity = new Vector2(_body.velocity.x, 10);
        }

        public void Die()
        {
            _active = false;
            _collider.enabled = false;
            MiniJump();
            StartCoroutine(Respawn());
        }

        void CreateDUst()
        {
            dust.Play();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Small"))
            {
                

                transform.localScale /= sizeChange;

                _maxSpeed *= 2.5f;

                _jump._jumpHeight *= 2f;
                _jump._upwardMovementMultiplier *= 1.3f;
                _body.gravityScale /= 1.5f;
            }

            if (collision.CompareTag("Big"))
            {
                transform.localScale *= sizeChange;

                _maxSpeed /= 2f;

                _jump._jumpHeight /= 1.5f;
                _jump._upwardMovementMultiplier /= 1.5f;
                _jump._downwardMovementMultiplier /= 0.7f;
                _body.gravityScale *= 1.5f;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Small"))
            {

                transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

                transform.localScale *= sizeChange;

                _maxSpeed /= 2.5f;

                _jump._jumpHeight /= 2f;
                _jump._upwardMovementMultiplier /= 1.3f;
                _body.gravityScale *= 1.5f;
            }

            if (collision.CompareTag("Big"))
            {
                transform.localScale /= sizeChange;

                _maxSpeed *= 2f;

                _jump._jumpHeight *= 1.5f;
                _jump._upwardMovementMultiplier *= 1.5f;
                _jump._downwardMovementMultiplier *= 0.7f;
                _body.gravityScale /= 1.5f;
            }
        }

        
    }

    

    
}
