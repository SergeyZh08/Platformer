using UnityEngine;

public enum Team
{
    Player,
    Enemy
}

public class TypeTeam : MonoBehaviour
{
    [SerializeField] private Team _team;
    public Team Team => _team;
}