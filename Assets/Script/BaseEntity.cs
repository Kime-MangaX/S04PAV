using UnityEngine;

public enum Elements
{
    None,
    Fire,
    Water,
    Earth,
    Air
}

public enum EnemyType
{
    Araña,
    Ciclope,
    Murcielago,
    Arañita
}

public abstract class BaseEntity : MonoBehaviour
{
    [SerializeField] protected int entityID;
    [SerializeField] protected string entityName;
    [SerializeField] protected string enetityDescription;

    [SerializeField] protected Elements element;
    [SerializeField] protected EnemyType enemyType;

    [SerializeField] protected BaseStats stats;

    protected virtual void Awake()
    {
        stats = new BaseStats(100, 10, 10, 10, 10, 10);
    }

    public abstract void TakeDamage(BaseEntity damager, Elements elements);

    public BaseStats Stats => stats;
    public Elements Element => element;
}