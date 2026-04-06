using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Pool<Bullet> _pool;
    public event Action<int> OnGunChanged;
    [SerializeField] private Gun[] _guns;
    [SerializeField] private int _currentGunIndex = 0;
    public Gun[] Guns => _guns;

    private void Awake()
    {
        for (int i = 0; i < Guns.Length; i++)
        {
            Guns[i].OnBulletEnd += OnGunEmpty;
        }
    }

    public void Init(Pool<Bullet> pool)
    {
        _pool = pool;
        
        for (int i = 0; i < Guns.Length; i++)
        {
            Guns[i].Init(pool);
        }
    }

    private void Start()
    {
        SetGunByIndex(_currentGunIndex);
    }

    private void OnDestroy()
    {
        for (int i = 0; i < Guns.Length; i++)
        {
            Guns[i].OnBulletEnd -= OnGunEmpty;
        }

        _pool?.Clear();
    }

    private void Update()
    {
        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");

        if (Mathf.Abs(scroll) > 0.01f)
        {
            int direction = scroll > 0 ? 1 : -1;
            TryNextGun(_currentGunIndex, direction);
        }
    }

    private void OnGunEmpty(Gun gun)
    {
        TryNextGun(Array.IndexOf(_guns, gun), -1);
    }

    private void TryNextGun(int index, int direction)
    {
        int legIndex = FindNextGunWithBullets(index, direction);

        SetGunByIndex(legIndex);
    }

    private int FindNextGunWithBullets(int index, int direction)
    {
        for (int step = 1; step < Guns.Length; step++)
        {
            int nextIndex = index + step * direction;

            if (nextIndex >= Guns.Length)
            {
                nextIndex -= Guns.Length;
            }
            else if (nextIndex < 0)
            {
                nextIndex += Guns.Length;
            }

            if (Guns[nextIndex].CanShoot())
            {
                return nextIndex;
            }
        }

        return 0;
    }

    private void SetGunByIndex(int index)
    {
        _currentGunIndex = index;
        for (int i = 0; i < Guns.Length; i++)
        {
            Guns[i].gameObject.SetActive(_currentGunIndex == i);
        }

        OnGunChanged?.Invoke(_currentGunIndex);
    }

    public bool AddBullets(int index, int bulletCount)
    {
        if (index >= Guns.Length || index < 0)
        {
            return false;
        }

        Gun gun = Guns[index];

        if (gun.BulletsCount < gun.WeaponData.MaxBullets)
        {
            Guns[index].AddBullets(bulletCount);
            return true;
        }

        return false;
    }
}