using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _player;
    [SerializeField] private float _jumpForce = 3;
    [SerializeField] private float _groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _speed = 10f;

    private bool _isJump = false;
    private bool _isGrounded = false;

    public bool _IsGrounded
    {
        get
        {
            return _isGrounded;
        }
    }

    void Update()
    {
        CalculateJump();
    }

    private void CalculateJump()
    {
        _isGrounded = Physics2D.Raycast(_player.position, Vector2.down, _groundCheckDistance, _groundMask);

        if (Input.GetKeyDown(KeyCode.W))
        {
            _isJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isGrounded)
        {
            if (_isJump)
            {
                _player.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _isJump = false;
            }
        }
        else
        {
            Movement();
        }
    }
    private void Movement()
    {
        if (Input.GetKey(KeyCode.A))
            gameObject.transform.Translate(Vector3.left * _speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            gameObject.transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
}

