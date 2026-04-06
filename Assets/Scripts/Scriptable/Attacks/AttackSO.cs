using UnityEngine;

[CreateAssetMenu(fileName = "AttackSO", menuName = "Scriptable Objects/AttackSO")]
public abstract class AttackSO : ScriptableObject
{
    public abstract void Execute(Transform spawnPoint, Transform target);
}
