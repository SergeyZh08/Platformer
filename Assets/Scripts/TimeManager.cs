using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public event Action<bool> OnSlowMo;
    [SerializeField] private float _time;
    private float _fixedTime;
    private float _startFixedTime;
    private bool _isSlowMo;

    private void Start()
    {
        _startFixedTime = Time.fixedDeltaTime;
        _fixedTime = Time.fixedDeltaTime * _time;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (!_isSlowMo)
            {
                EnableSlowMo();
            }

        }
        else
        {
            if (_isSlowMo)
            {
                DisableSlowMo();
            }
        }
    }

    private void EnableSlowMo()
    {
        Time.timeScale = _time;
        Time.fixedDeltaTime = _fixedTime;
        _isSlowMo = true;
        OnSlowMo?.Invoke(_isSlowMo);
    }

    private void DisableSlowMo()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = _startFixedTime;
        _isSlowMo = false;
        OnSlowMo?.Invoke(_isSlowMo);
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = _startFixedTime;
        Time.timeScale = 1f;
    }
}
