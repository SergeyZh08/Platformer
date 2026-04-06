using System;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public event Action OnJoin;
    [SerializeField] private Rigidbody _rb;
    public Rigidbody Rigidbody => _rb;

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void Shoot(Transform gun, float speed)
    {
        transform.position = gun.position;
        transform.rotation = gun.rotation;
        _rb.isKinematic = false;
        _rb.linearVelocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _rb.isKinematic = true;
        OnJoin?.Invoke();
    }
}
