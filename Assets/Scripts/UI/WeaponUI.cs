using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private GunCell _gunCellPrefab;
    [SerializeField] private Color _selectedColor;
    [SerializeField] private Color _unSelectedColor;
    private List<GunCell> _gunCells = new List<GunCell>();

    private void Start()
    {
        for (int i = 0; i < _inventory.Guns.Length; i++)
        {
            GunCell newGunCell = Instantiate(_gunCellPrefab, transform);

            newGunCell.Init(_inventory.Guns[i].WeaponData.WeaponImage,
            _inventory.Guns[i].BulletsCount,
            _inventory.Guns[i].WeaponData.MaxBullets);
            
            _gunCells.Add(newGunCell);

            _inventory.Guns[i].OnBulletChanged += ChangeBulletInfoInCell;
        }

        _inventory.OnGunChanged += SetCurrentCellIcon;
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _inventory.Guns.Length; i++)
        {
            _inventory.Guns[i].OnBulletChanged -= ChangeBulletInfoInCell;
        }

         _inventory.OnGunChanged -= SetCurrentCellIcon;
    }

    private void SetCurrentCellIcon(int index)
    {
        for (int i = 0; i < _gunCells.Count; i++)
        {
            _gunCells[i].SetColor(index == i ? _selectedColor : _unSelectedColor);
        }
    }

    private void ChangeBulletInfoInCell(Gun gun)
    {
        int index = Array.IndexOf(_inventory.Guns, gun);

        if (index != -1)
        {
            _gunCells[index].ChangeSliderInfo(gun.BulletsCount);
        }
    }
}
