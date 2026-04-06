using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Target {get; set;}
    public event Action OnShoot;
    [SerializeField] private AttackSO _attack;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _timeToAttack;
    
    private float _timer = 0;

    private void Update()
    {
        if (Target)
        {
            _timer += Time.deltaTime;

            if (_timer >= _timeToAttack)
            {
                OnShoot?.Invoke();
                _timer = 0;
            }
        }
    }

    public void Shoot()
    {
        if (Target)
        {
            _attack.Execute(_spawnPoint, Target);
        }
    }
}
