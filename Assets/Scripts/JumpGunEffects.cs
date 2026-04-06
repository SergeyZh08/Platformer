using UnityEngine;

public class JumpGunEffects : MonoBehaviour
{
    [SerializeField] private JumpGun _jumpGun;
    [SerializeField] private ParticleSystem _shootEffect;
    [SerializeField] private AudioSource _shootSound;
    
    private void Start()
    {
        _jumpGun.OnShoot += Play;
    }

    private void OnDestroy()
    {
        _jumpGun.OnShoot -= Play;
    }

    private void Play()
    {
        _shootEffect.Play();
        _shootSound.Play();
    }
}
