using UnityEngine;
using UnityEngine.Events;

public class AmmoPick : MonoBehaviour, ICollectable
{
    public UnityEvent OnPickedUp;
    [SerializeField] private int _index;
    [SerializeField] private int _bulletCount;

    public void Collect(GameObject collector)
    {
        if (collector.TryGetComponent(out Inventory inventory))
        {
            if (inventory.AddBullets(_index, _bulletCount))
            {
                OnPickedUp?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
