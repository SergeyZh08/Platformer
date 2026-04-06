using UnityEngine;

public class GunEffects : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    [SerializeField] private GameObject _muzzleFlash;
    [SerializeField] private AudioSource _shootSound;
    [SerializeField] private ParticleSystem _smoke;

    private void Start()
    {
        _gun.OnShoot += StartEffects;
    }

    private void OnDestroy()
    {
        _gun.OnShoot -= StartEffects;
    }

    private void StartEffects(WeaponData data)
    {
        _muzzleFlash.SetActive(true);
        _shootSound.pitch = Random.Range(0.8f, 1.2f);
        _shootSound.PlayOneShot(data.ShootSound);
        Invoke(nameof(HideFlash), data.TimeToRecharge / 4);
        _smoke.Play();
    }
    
    private void HideFlash()
    {
        _muzzleFlash.SetActive(false);
    }
}
