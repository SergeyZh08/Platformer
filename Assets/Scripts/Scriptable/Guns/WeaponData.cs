using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private Sprite _weaponImage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _timeToRecharge;
    [SerializeField] private int _maxBullets;
    [SerializeField] private int _damage;

    public AudioClip ShootSound => _shootSound;
    public Sprite WeaponImage => _weaponImage;
    public float BulletSpeed => _bulletSpeed;
    public float TimeToRecharge => _timeToRecharge;
    public int MaxBullets => _maxBullets;
    public int Damage => _damage;
}