using UnityEngine;

[CreateAssetMenu(fileName = "CarrotAttackSO", menuName = "Scriptable Objects/CarrotAttackSO")]
public class CarrotAttackSO : AttackSO
{
    [SerializeField] private Carrot _carrot;
    public override void Execute(Transform spawnPoint, Transform target)
    {
        if (!target)
        {
            return;
        }

        Carrot newCarrot = Instantiate(_carrot, new Vector3(spawnPoint.position.x, spawnPoint.position.y, 0f), Quaternion.identity);
        newCarrot.Init(target);
    }
}
