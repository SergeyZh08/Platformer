using UnityEngine;

[RequireComponent(typeof(TypeTeam))]
public class DamageOnTouch : MonoBehaviour
{
    [SerializeField] private int _damage;
    private TypeTeam _team;

    private void Awake()
    {
        _team = GetComponent<TypeTeam>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        TryTakeDamage(collision.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        TryTakeDamage(other);
    }

    private void TryTakeDamage(Collider target)
    {
        TypeTeam otherTeam = target.GetComponentInParent<TypeTeam>();

        if (_team == null || otherTeam == null || _team.Team == otherTeam.Team)
        {
            return;
        }

        IDamagable damagable = target.GetComponentInParent<IDamagable>();

        damagable?.TakeDamage(_damage);
    }
}
