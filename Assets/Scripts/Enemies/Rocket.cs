using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _lifeTime;
    private Transform _target;

    public void Init(Transform target)
    {
        _target = target;

        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        Vector3 toTarget = _target.position - transform.position;

        Quaternion rotationQuaternion = Quaternion.LookRotation(toTarget, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotationQuaternion, Time.deltaTime * _rotationSpeed);

        transform.position += _speed * Time.deltaTime * transform.forward;
    }
}