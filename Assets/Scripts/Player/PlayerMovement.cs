using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _body;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _damping;
    [SerializeField] private float _airControl;
    [SerializeField] private Vector3 _squatSize;
    [SerializeField] private float _squatTimeMultyplier;
    [SerializeField] private float _bufferJump;
    private float _bufferJumpTimer;
    private bool _isGround;
    public bool IsGround => _isGround;
    private bool _canJump;


    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _bufferJumpTimer = 0;
            _canJump = true;
        }

        if (_canJump)
        {
            _bufferJumpTimer += Time.deltaTime;

            if (_bufferJumpTimer >= _bufferJump)
            {
                _canJump = false;
            }
        }

        if (_isGround && _canJump)
        {
            Jump();
            _canJump = false;
        }

        bool isSquatting = !_isGround || Input.GetKey(KeyCode.LeftShift);

        SitDown(isSquatting ? _squatSize : Vector3.one);
    }
    private void FixedUpdate()
    {
        float xMove = Input.GetAxisRaw("Horizontal");

        float flyMultiplier = _isGround ? 1 : _airControl;

        float targetVelocity = xMove * _maxSpeed;
        float diffSpeed = targetVelocity - _rb.linearVelocity.x;

        Vector3 moveForce = new Vector3(diffSpeed * _acceleration * flyMultiplier * Time.fixedDeltaTime, 0, 0);

        _rb.AddForce(moveForce, ForceMode.VelocityChange);

        if (_isGround)
        {
            Vector3 dampingVector = new Vector3(-_rb.linearVelocity.x * _damping * Time.fixedDeltaTime, 0, 0);
            _rb.AddForce(dampingVector, ForceMode.VelocityChange);
        }

        if (Mathf.Abs(xMove) > 0.01f)
        {
            _rb.linearVelocity = new Vector3(Mathf.Clamp(_rb.linearVelocity.x, -_maxSpeed, _maxSpeed), _rb.linearVelocity.y, 0);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGround = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            if (Vector3.Dot(Vector3.up, collision.contacts[i].normal) < 0.7f)
            {
                _isGround = false;
                return;
            }
        }
        _isGround = true;
    }

    private void SitDown(Vector3 target)
    {
        _body.localScale = Vector3.Lerp(_body.localScale, target, Time.deltaTime * _squatTimeMultyplier);
    }

    public void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);
    }
}
