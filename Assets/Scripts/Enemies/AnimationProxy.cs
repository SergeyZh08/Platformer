using UnityEngine;

public class AnimationProxy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _parameterName = "Attack";
    private int _attackHash;

    private void Start()
    {
        _attackHash = Animator.StringToHash(_parameterName);
    }

    private void OnEnable()
    {
        _enemy.OnShoot += StartAnimation;
    }

    private void OnDisable()
    {
        _enemy.OnShoot -= StartAnimation;
    }

    private void StartAnimation()
    {
        _animator.SetTrigger(_attackHash);
    }

    public void Shoot()
    {
        _enemy.Shoot();
    }
}
