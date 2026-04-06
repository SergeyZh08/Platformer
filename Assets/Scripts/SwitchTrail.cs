using UnityEngine;

public class SwitchTrail : MonoBehaviour
{
    [SerializeField] private GameObject _trail;

    private void OnEnable()
    {
        _trail.SetActive(true);
    }

    private void OnDisable()
    {
        _trail.SetActive(false);
    }
}
