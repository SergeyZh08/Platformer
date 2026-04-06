using UnityEngine;

[CreateAssetMenu(fileName = "CornAttack", menuName = "Scriptable Objects/CornAttack")]
public class CornAttack : AttackSO
{
    [SerializeField] private Corn _cornPrefab;
    [SerializeField] private float _force;
    
    public override void Execute(Transform spawnPoint, Transform target)
    {
        if (!target)
        {
            return;
        }

        SpawnPoint[] spawnPoints = spawnPoint.GetComponentsInChildren<SpawnPoint>();

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Corn newCorn = Instantiate(_cornPrefab, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
            newCorn.Init(_force);
        }
    }
}
