using Unity.VisualScripting;
using UnityEngine;

public class Enemy : BaseEntity
{
    public BoxCollider2D coll;
    public float range;


    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        coll.AddComponent<Enemy>();
    }

    void Start()
    {
       

    }

    void Update()
    {
        
    }

   /* public override void TakeDamage(BaseEntity damager)
    {
        base.TakeDamage(damager, enemyType); 
    }
   */
    
}
