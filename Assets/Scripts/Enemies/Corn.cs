using UnityEngine;

public class Corn : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    public void Init(float force)
    {
        _rb.AddForce(transform.forward * force, ForceMode.VelocityChange);
    }
}
