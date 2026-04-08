
using Unity.Android.Gradle;
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

    private void Awake()
    {
        stats = new(10, 10, 10, 10, 10, 10);
    }
    private void Start()
    {
        
    }
    public virtual void TakeDamage(BaseEntity damager, Elements elements)
    {
        stats.TakeDamage(damager.stats.Power);
    }

    public BaseStats Stats => stats;
    public Elements Element => element;
}
