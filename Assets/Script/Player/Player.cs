using System.Collections.Generic;
using UnityEngine;

public class Player : BaseEntity
{
    public CircleCollider2D coll;
    public float range;
    public List<GameObject> Enemys = new();
    

    protected override void Awake()
    {
        // Primero vamos a jecutar el Awake del padre para crear las stats
        base.Awake();

        // Luego configuramos lo propio del Player
        coll = GetComponent<CircleCollider2D>();
        if (coll != null) coll.radius = range;
    }

    void Start()
    {
        InvokeRepeating("AutoAttackEnemies", 1f, 1f);
    }

    public void AutoAttackEnemies()
    {
        // Usamos un bucle for en inverso para limpiar la lista si un enemigo se muere y evitamos que aparesca mas
        for (int i = Enemys.Count - 1; i >= 0; i--)
        {
            if (Enemys[i] == null)
            {
                Enemys.RemoveAt(i);
                continue;
            }

            float distance = Vector3.Distance(Enemys[i].transform.position, transform.position);
            if (distance <= range)
            {
                // Aplicamos daño elemental
                Enemys[i].GetComponent<Enemy>().TakeDamage(this, this.element);
            }
        }
    }

    public override void TakeDamage(BaseEntity damager, Elements damageElement)
    {
        int damage = damager.Stats.Power;

        switch (damageElement)
        {
            case Elements.Fire: damage *= 2; break;
            case Elements.Water: damage /= 2; break;
            case Elements.Earth: damage *= 3; break;
            case Elements.Air: damage = 0; break;
        }

        stats.TakeDamage(damage);
        Debug.Log($"Player recibió daño. Vida actual: {stats.Health}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
            Enemys.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Enemys.Remove(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            this.TakeDamage(enemy, enemy.Element);
        }
    }
}