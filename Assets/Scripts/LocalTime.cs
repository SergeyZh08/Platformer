using UnityEngine;

public class LocalTime : MonoBehaviour
{
    [Range(0f, 2f)]
    [SerializeField] private float _localTime;
    public float LocalDeltaTime => Time.unscaledDeltaTime * _localTime;
}
