using UnityEngine;

public class HitEffectSpawner : MonoBehaviour
{
    private Pool<HitEffect> _pool;

    public void Init(Pool<HitEffect> pool)
    {
        _pool = pool;
    }

    public void Release(HitEffect effect)
    {
        _pool.Release(effect);
    }

    public void OnHitPlay(Vector3 position)
    {
        HitEffect effect = _pool.Get();
        effect.transform.position = position;
        effect.Play();
    }
}
