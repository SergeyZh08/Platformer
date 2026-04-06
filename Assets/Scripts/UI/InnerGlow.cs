using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InnerGlow : MonoBehaviour
{
    [SerializeField] private Image _source;
    [SerializeField] private float _animationTime;
    private Coroutine _currentCoroutine;
    
    public void StartGlow()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(Glowing());
    }

    private IEnumerator Glowing()
    {
        _source.enabled = true;
        _source.color = new Color(_source.color.r, _source.color.g, _source.color.b, 1f);

        for (float t = 1; t > 0f; t -= Time.deltaTime / _animationTime)
        {
            _source.color = new Color(_source.color.r, _source.color.g, _source.color.b, t);
            yield return null;
        }

        _source.enabled = false;
        _currentCoroutine = null;
    }
}
