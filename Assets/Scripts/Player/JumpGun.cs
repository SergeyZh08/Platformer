using System;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    public event Action OnShoot;
    public event Action<float> OnCooldownStarted;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _timeToRecharge;
    [SerializeField] private float _force;
    [SerializeField] private bool _rechargedAtStart;
    private float _timer;
    public bool IsReady => _timer >= _timeToRecharge;
    public float TimeToRecharge => _timeToRecharge;
    public float CooldownProgress => Mathf.Clamp01(_timer / _timeToRecharge);

    private void Awake()
    {
        _timer = _rechargedAtStart ? _timeToRecharge : 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftControl) && IsReady)
        {
            _rb.AddForce(-transform.forward * _force, ForceMode.VelocityChange);
            OnCooldownStarted?.Invoke(_timeToRecharge);
            OnShoot?.Invoke();
            _timer = 0;
        }
    }
}
