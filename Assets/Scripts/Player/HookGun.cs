using Unity.VisualScripting;
using UnityEngine;

public enum HookState
{
    Active,
    Inactive,
    Fly
}

public class HookGun : MonoBehaviour
{
    [SerializeField] private Hook _hook;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _playerRb;
    [SerializeField] private float _maxRopeDistance;
    [SerializeField] private float _damper;
    [SerializeField] private float _spring;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private RopeRenderer _ropeRenderer;
    private float _length;
    private SpringJoint _springJoint;
    private HookState _currentState;

    private void Start()
    {
        _hook.OnJoin += JoinToHook;
        _hook.Deactivate();
        _currentState = HookState.Inactive;

        _length = 1;
    }

    private void OnDestroy()
    {
        _hook.OnJoin -= JoinToHook;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            if (_springJoint != null)
            {
                Destroy(_springJoint);
                _springJoint = null;
            }

            DestroyJoint();
            Shoot();
        }

        if (_currentState == HookState.Fly)
        {
            float flyDistance = Vector3.Distance(transform.position, _hook.transform.position);
            _ropeRenderer.Draw(transform.position, _hook.transform.position, _length);

            if (flyDistance > _maxRopeDistance)
            {
                _currentState = HookState.Inactive;
                DestroyJoint();
            }
        }

        if (_currentState == HookState.Active)
        {
            _ropeRenderer.Draw(transform.position, _hook.transform.position, _length);
            if (Input.GetKeyDown(KeyCode.Space) && !_playerMovement.IsGround)
            {
                _playerMovement.Jump();
                _currentState = HookState.Inactive;
                DestroyJoint();
            }
        }
    }

    private void Shoot()
    {
        _length = 1;
        _hook.Shoot(transform, _speed);
        _hook.Activate();
        _currentState = HookState.Fly;
    }

    private void JoinToHook()
    {
        if (_springJoint != null)
        {
            return;
        }

        _springJoint = _playerRb.AddComponent<SpringJoint>();
        _length = Vector3.Distance(transform.position, _hook.transform.position);

        _springJoint.autoConfigureConnectedAnchor = false;
        _springJoint.connectedBody = _hook.Rigidbody;
        _springJoint.maxDistance = _length;
        _springJoint.damper = _damper;
        _springJoint.spring = _spring;

        _currentState = HookState.Active;
    }

    private void DestroyJoint()
    {
        _hook.Deactivate();
        _ropeRenderer.Hide();
    }
}
