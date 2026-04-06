using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _aim;
    [SerializeField] private Transform _body;
    [SerializeField] private float _bodyRotation;
    private Plane _plane;

    private void Start()
    {
        _plane = new Plane(-Vector3.forward, Vector3.zero);
    }

    private void LateUpdate()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if(_plane.Raycast(ray, out float distance))
        {
            Vector3 aimTarget = ray.GetPoint(distance);

            Vector3 toTarget = aimTarget - transform.position;
            transform.rotation = Quaternion.LookRotation(toTarget);
            
            _aim.position = aimTarget;

            float yRot = toTarget.x < 0 ? _bodyRotation : -_bodyRotation;

            _body.rotation = Quaternion.Slerp(_body.rotation, Quaternion.Euler(0, yRot, 0), Time.deltaTime * 10);
        }
    }
}
