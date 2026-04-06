using UnityEngine;

public class Hen : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speedMultipy;
    [SerializeField] private float _timeToAcceleration;
    private Transform _target;

    private void Start()
    {
        _target = FindAnyObjectByType<PlayerMovement>().transform;
    }
    
    private void FixedUpdate()
    {
        if (_target && _timeToAcceleration > 0)
        {
            Vector3 toTarget = (_target.transform.position - transform.position).normalized;

            _rb.AddForce(_rb.mass * (toTarget * _speedMultipy - _rb.linearVelocity) / _timeToAcceleration);
        }
    }
}
