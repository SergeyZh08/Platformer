using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private float _animationTime;
    private Coroutine _currentCoroutine;

    public void SetHealth(int health)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(HealthAnimation(health));
    }

    private IEnumerator HealthAnimation(int health)
    {
        float startSliderValue = _healthSlider.value;
        float elapsed = 0f;

        while (elapsed < _animationTime)
        {
            elapsed += Time.deltaTime;

            float progress = elapsed / _animationTime;

            _healthSlider.value = Mathf.Lerp(startSliderValue, health, progress);

            yield return null;
        }

        _healthSlider.value = health;
        _currentCoroutine = null;
    }
}
