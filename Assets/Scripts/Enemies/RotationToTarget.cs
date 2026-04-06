using UnityEngine;

public class RotationToTarget : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Vector3 _toLeft;
    [SerializeField] private Vector3 _toRight;

    private void Update()
    {
        if (_enemy.Target)
        {
            Vector3 direction = _enemy.Target.position.x < transform.position.x ? _toLeft : _toRight;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(direction), Time.deltaTime * 10);
        }
    }
}
