using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField] private Transform[] _spawnPoints;
    protected override void Shoot()
    {
        base.Shoot();

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Bullet newBullet = _pool.Get();
            newBullet.transform.SetPositionAndRotation(_spawnPoints[i].position, _spawnPoints[i].rotation);
            newBullet.gameObject.SetActive(true);
            newBullet.Init(WeaponData.Damage, WeaponData.BulletSpeed);
        }
    }
}