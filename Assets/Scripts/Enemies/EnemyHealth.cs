using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    public UnityEvent OnEnemyHit;
    public UnityEvent OnEnemyDie;
    [SerializeField] private int _health = 1;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        _health = Mathf.Clamp(_health, 0, _health);

        OnEnemyHit?.Invoke();

        if (_health == 0)
        {
            OnEnemyDie?.Invoke();
            Destroy(gameObject);
        }
    }
}