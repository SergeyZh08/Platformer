using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] private LocalTime _time;
    public event Action<Gun> OnBulletChanged;
    public event Action<Gun> OnBulletEnd;
    public event Action<WeaponData> OnShoot;
    [SerializeField] protected WeaponData _weaponData;
    public WeaponData WeaponData => _weaponData;
    public int BulletsCount { get; private set; }
    private float _timer;
    protected Pool<Bullet> _pool;

    public void Init(Pool<Bullet> pool)
    {
        _pool = pool;
    }

    private void Update()
    {
        _timer += _time.LocalDeltaTime;

        if (_timer >= WeaponData.TimeToRecharge && CanShoot())
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
                _timer = 0;
            }
        }
    }

    public virtual bool CanShoot()
    {
        return BulletsCount > 0;
    }

    protected virtual void Shoot()
    {
        SpentBullet();
        OnShoot?.Invoke(WeaponData);
    }

    protected virtual void SpentBullet()
    {
        BulletsCount--;
        BulletsCount = Mathf.Clamp(BulletsCount, 0, WeaponData.MaxBullets);

        OnBulletChanged?.Invoke(this);

        if (BulletsCount == 0)
        {
            OnBulletEnd?.Invoke(this);
        }
    }
    
    public virtual void AddBullets(int bulletsCount)
    {
        BulletsCount += bulletsCount;

        BulletsCount = Mathf.Clamp(BulletsCount, 0, WeaponData.MaxBullets);

        OnBulletChanged?.Invoke(this);
    }
}
