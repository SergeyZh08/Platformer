using System;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable
{
    public event Action<Bullet> OnExpired;
    public event Action<Vector3> OnHit;
    [SerializeField] private float _lifeTime;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private TrailRenderer _trail;
    private float _timer;
    private int _damage;

    public void Init(int damage, float speed)
    {
        _rb.isKinematic = false;
        _timer = 0f;

        _rb.angularVelocity = Vector3.zero;
        _rb.linearVelocity = Vector3.zero;
        _damage = damage;

        if (_trail != null)
        {
            _trail.Clear();
        }

        _rb.linearVelocity = speed * transform.forward;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _lifeTime)
        {
            OnExpired?.Invoke(this);
            return;
        }
    }

    public void OnGetFromPool()
    {
        _timer = 0;
    }

    public void OnReleaseToPool()
    {
        _rb.angularVelocity = Vector3.zero;
        _rb.linearVelocity = Vector3.zero;
        _rb.isKinematic = true;

        if (_trail != null)
        {
            _trail.Clear();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damagable = collision.collider.GetComponentInParent<IDamagable>();

        TryTakeDamage(damagable);
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable = other.GetComponentInParent<IDamagable>();

        TryTakeDamage(damagable);
    }

    private void TryTakeDamage(IDamagable damagable)
    {
        damagable?.TakeDamage(_damage);

        OnHit?.Invoke(transform.position);
        OnExpired?.Invoke(this);
    }
}