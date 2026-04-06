using System;
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    public event Action<ActivateByDistance> OnEnemyDestroyed; 
    [SerializeField] private float _distanceToActivate = 50;
    public float Distance => _distanceToActivate;

    public void Activate()
    {
        if (!gameObject.activeSelf)
        {
             gameObject.SetActive(true);
        }
    }

    public void Deactivate()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        OnEnemyDestroyed?.Invoke(this);
    }
}
