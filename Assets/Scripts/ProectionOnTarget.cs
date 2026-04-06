using UnityEngine;

public class ProectionOnTarget : MonoBehaviour
{
    [SerializeField] private Transform _proectionPoint;

    private void Update()
    {
        if (Physics.Raycast(_proectionPoint.position, Vector3.down, out RaycastHit hit))
        {
            transform.position = hit.point;
        }
    }
}
