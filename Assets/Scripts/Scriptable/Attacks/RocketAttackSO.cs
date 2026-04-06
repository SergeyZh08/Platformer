using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "RocketAttackSO", menuName = "Scriptable Objects/RocketAttackSO")]
public class RocketAttackSO : AttackSO
{
    [SerializeField] private Rocket _rocketPrefab;
    public override void Execute(Transform spawnPoint, Transform target)
    {
        if (!target)
        {
            return;
        }

        Rocket newRocket = Instantiate(_rocketPrefab, new Vector3(spawnPoint.position.x, spawnPoint.position.y, 0f), spawnPoint.rotation);
        newRocket.Init(target);
    }
}
