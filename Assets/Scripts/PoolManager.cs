using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private HitEffect _hitPrefab;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private HitEffectSpawner _spawner;

    Pool<Bullet> _bulletPool;
    Pool<HitEffect> _hitPool;

    private void Awake()
    {
        _hitPool = new Pool<HitEffect>(
            _hitPrefab, 
            10, 
            5, 
            transform, 
            (hiteffect) => hiteffect.OnExpired += _spawner.Release, 
            (hiteffect) => hiteffect.OnExpired -= _spawner.Release
        );

        _bulletPool = new Pool<Bullet>(
            _bulletPrefab,
            10,
            10,
            transform,
            (bullet) =>
            {
                bullet.OnExpired += OnRelease;
                bullet.OnHit += _spawner.OnHitPlay;
            },
            (bullet) =>
            {
                bullet.OnExpired -= OnRelease;
                bullet.OnHit -= _spawner.OnHitPlay;
            }
        );

        _inventory.Init(_bulletPool);
        _spawner.Init(_hitPool);
    }

    private void OnRelease(Bullet bullet)
    {
        _bulletPool.Release(bullet);
    }
}
