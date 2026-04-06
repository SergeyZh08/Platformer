using System.Collections;
using UnityEngine;

public class TargetDetector : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float  _detectionRadius;
    [SerializeField] private bool _drawRadius;
    private readonly Collider[] _result = new Collider[1];
    private Coroutine _currentCoroutine;

    private void OnEnable()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(FindTarget());
    }

    private void OnDisable() 
    {
        _currentCoroutine = null;
    }


    private IEnumerator FindTarget()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            int count = Physics.OverlapSphereNonAlloc(transform.position, _detectionRadius, _result, _layerMask);
            _enemy.Target = count > 0 ? _result[0].transform : null;

            yield return wait;
        }
    }

    private void OnDrawGizmos()
    {
        if (_drawRadius)
        {
            Gizmos.color = new Color(1f, 0f, 0f, 0.1f);
            Gizmos.DrawSphere(transform.position, _detectionRadius);
        }
    }
}
