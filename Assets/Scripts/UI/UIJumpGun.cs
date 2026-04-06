using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIJumpGun : MonoBehaviour
{
    [SerializeField] private JumpGun _jumpGun;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _targetColor;
    [SerializeField] private Image _image;
    private Coroutine _currentCoroutine;

    private void Start()
    {
        _jumpGun.OnCooldownStarted += OnRecharge;
        StartInit();
    }

    private void OnDestroy()
    {
        _jumpGun.OnCooldownStarted -= OnRecharge;

        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }
    }

    private void StartInit()
    {
        float startProgress = _jumpGun.CooldownProgress;

        _image.color = Color.Lerp(_startColor, _targetColor, startProgress);

        if (!_jumpGun.IsReady)
        {
            float time = _jumpGun.TimeToRecharge * (1f - startProgress);
            _currentCoroutine = StartCoroutine(RechargeRoutine(time, startProgress));
        }
    }

    private void OnRecharge(float timeToRecharge)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(RechargeRoutine(timeToRecharge, 0f));
    }

    private IEnumerator RechargeRoutine(float timeToRecharge, float startProgress)
    {
        float timer = 0;

        while (timer < timeToRecharge)
        {
            float progress = timer / timeToRecharge;
            float t = Mathf.Lerp(startProgress, 1f, progress);

            _image.color = Color.Lerp(_startColor, _targetColor, t);
            timer += Time.deltaTime;
            yield return null;
        }

        _image.color = _targetColor;
        _currentCoroutine = null;
    }
}
