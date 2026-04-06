using System;
using UnityEngine;

public class HitEffect : MonoBehaviour, IPoolable
{
    [SerializeField] private ParticleSystem _effect;
    public event Action<HitEffect> OnExpired;

    public void Play()
    {
        gameObject.SetActive(true);
        _effect.Play();
    }

    private void Update()
    {
        if (!_effect.isPlaying)
        {
            OnExpired?.Invoke(this);
        }
    }

    public void OnGetFromPool()
    {
        
    }

    public void OnReleaseToPool()
    {
        _effect.Stop();
    }
}
