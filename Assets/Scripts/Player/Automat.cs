using UnityEngine;

public class Automat : Gun
{
    [SerializeField] private Transform _spawnPoint;

    protected override void Shoot()
    {
        base.Shoot();
        Bullet newBullet = _pool.Get();
        newBullet.transform.SetPositionAndRotation(_spawnPoint.position, _spawnPoint.rotation);
        newBullet.gameObject.SetActive(true);
        newBullet.Init(WeaponData.Damage, WeaponData.BulletSpeed);
    }

}
