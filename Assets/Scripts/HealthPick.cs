using UnityEngine;
using UnityEngine.Events;

public class HealthPick : MonoBehaviour, ICollectable
{
    public UnityEvent OnPickedUp;
    [SerializeField] private int _health;

    public void Collect(GameObject collector)
    {
        if (collector.TryGetComponent(out PlayerHealth playerHealth))
        {
            if (playerHealth.Health < playerHealth.MaxHealth)
            {
                playerHealth.AddHealth(_health);

                OnPickedUp?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}