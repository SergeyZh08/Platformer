using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    public UnityEvent OnTakeDamage;
    public UnityEvent<int> OnChangeHealth;
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _timeOfImmortality;
    private float _nextDamageTime;

    public int Health => _health;
    public int MaxHealth => _maxHealth;

    public void TakeDamage(int damage)
    {
        if (Time.time < _nextDamageTime)
        {
            return;
        }

        _nextDamageTime = Time.time + _timeOfImmortality;

        _health -= damage;
        _health = Mathf.Clamp(_health, 0, _maxHealth);
        
        OnChangeHealth?.Invoke(_health);
        OnTakeDamage?.Invoke();

        if (_health == 0)
        {
            Debug.Log("Die");
        }
    }

    public void AddHealth(int health)
    {
        _health += health;
        _health = Mathf.Clamp(_health, 0, _maxHealth);

        OnChangeHealth?.Invoke(_health);
    }
}
