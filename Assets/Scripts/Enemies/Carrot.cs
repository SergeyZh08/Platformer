using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    private Vector3 _toTarget;

    public void Init(Transform target)
    {
        _toTarget = (target.position - transform.position).normalized;
        _toTarget.z = 0;

        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        transform.position += _speed * Time.deltaTime * _toTarget;
    }
}
