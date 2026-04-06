using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private Renderer[] _renderers;
    [SerializeField] private float _blinkTime;
    private Coroutine _currentAnimation;

    public void StartBlink()
    {
        if (_currentAnimation != null)
        {
            StopCoroutine(_currentAnimation);
        }

        _currentAnimation = StartCoroutine(BlinkAnimation());
    }

    private IEnumerator BlinkAnimation()
    {
        for (float t = 0; t < _blinkTime; t += Time.deltaTime)
        {
            for (int i = 0; i < _renderers.Length; i++)
            {
                for (int j = 0; j < _renderers[i].materials.Length; j++)
                {
                    _renderers[i].materials[j].SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30) * 0.5f + 0.5f, 0, 0));
                }
            }

            yield return null;
        }

        for (int i = 0; i < _renderers.Length; i++)
        {
            for (int j = 0; j < _renderers[i].materials.Length; j++)
            {
                _renderers[i].materials[j].SetColor("_EmissionColor", Color.clear);
            }
        }

        _currentAnimation = null;
    }
}
