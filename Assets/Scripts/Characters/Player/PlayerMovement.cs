using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private readonly string Ground = "Ground";
    private readonly string Jump = "Jump";
    private readonly string Horizontal = "Horizontal";

    [SerializeField] private float _speedPlayer;
    [SerializeField] private AnimationCurve jumpCurve;

    private float _maxJumpHeight = 15f;
    private float _jumpDuration = 0.5f;
    private float _jumpTime;
    private bool _isJumping = false;

    private bool _isGround;
    private Rigidbody2D _playerRigidBody;

    private void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetAxis(nameof(Jump)) > 0 && _isGround)
        {
            StartJump();
        }

        if (_isJumping)
        {
            ContinueJump();
        }
    }

    private void FixedUpdate()
    {
        HorizontalMovmentPlayer();
    }

    private void HorizontalMovmentPlayer()
    {
        float movementHorizontal = Input.GetAxis(nameof(Horizontal));

        Vector2 movement = new Vector2(movementHorizontal, 0);
        _playerRigidBody.AddForce(movement * _speedPlayer);
    }

    private void StartJump()
    {
        _isJumping = true;
        _isGround = false;
        _jumpTime = 0f;
    }

    private void ContinueJump()
    {
        _jumpTime += Time.deltaTime;

        float t = _jumpTime / _jumpDuration;

        if (t >= 1f)
        {
            _isJumping = false; 
            return;
        }

        float jumpForce = jumpCurve.Evaluate(t) * _maxJumpHeight;
        _playerRigidBody.velocity = new Vector2(_playerRigidBody.velocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGroundedUpdate(collision, true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGroundedUpdate(collision, false);
    }

    private void IsGroundedUpdate(Collision2D collision, bool value)
    {
        if (collision.gameObject.tag == (nameof(Ground)))
        {
            _isGround = value;
        }
    }
}
