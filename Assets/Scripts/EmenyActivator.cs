using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyActivator : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private List<ActivateByDistance> _enemies = new List<ActivateByDistance>();

    private void Start()
    {
        ActivateByDistance[] enemies = GetComponentsInChildren<ActivateByDistance>();

        for (int i = 0; i < enemies.Length; i++)
        {
            RegisterEnemy(enemies[i]);
        }

        StartCoroutine(CheckDistanceRoutine());
    }

    private IEnumerator CheckDistanceRoutine()
    {
        var wait = new WaitForSeconds(0.2f);

        while (true)
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                float distanceSqr = (_enemies[i].transform.position - _player.position).sqrMagnitude;
                float activationSqr = _enemies[i].Distance * _enemies[i].Distance;

                if (distanceSqr < activationSqr)
                {
                    _enemies[i].Activate();
                }
                else
                {
                    _enemies[i].Deactivate();
                }
            }

            yield return wait;
        }
    }

    private void RegisterEnemy(ActivateByDistance enemy)
    {
        _enemies.Add(enemy);
        enemy.OnEnemyDestroyed += UnRegisterEnemy;
    }

    private void UnRegisterEnemy(ActivateByDistance enemy)
    {
        _enemies.Remove(enemy);
        enemy.OnEnemyDestroyed -= UnRegisterEnemy;
    }
}
