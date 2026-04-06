using UnityEngine;

public class EffectSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private Transform _point;

    public void Spawn()
    {
        Instantiate(_effect, _point.position, Quaternion.identity);
    }
}
