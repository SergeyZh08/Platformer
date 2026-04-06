using UnityEngine;
using UnityEngine.UI;

public class SlowMo : MonoBehaviour
{
    [SerializeField] private TimeManager _timeManager;
    [SerializeField] private Animator _animator;
    [SerializeField] private Image _source;
    [SerializeField] private string _animationName = "IsSlowMo";

    private void Start()
    {
        _timeManager.OnSlowMo += OnSlowMo;
    }

    private void OnDestroy()
    {
        _timeManager.OnSlowMo -= OnSlowMo;
    }

    public void OnSlowMo(bool isSlowMo)
    {
        _source.enabled = isSlowMo;
        _animator.SetBool(_animationName, isSlowMo);
    }
}
