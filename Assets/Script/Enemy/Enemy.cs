using UnityEngine;

public class Enemy : BaseEntity
{

    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float range;

    private bool isFacingRight = true;

    public GameObject xpOrbPrefab; 

    protected override void Awake()
    {
        base.Awake(); 
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
    void Update()
    {
        bool isPlayerRight = transform.position.x < player.transform.position.x;
        Flip(isPlayerRight);

        MoveToTarget();
    }

    private void Flip(bool isPlayerRight)
    {
        if ((isFacingRight && !isPlayerRight) || (!isFacingRight && isPlayerRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    public Transform GetTransform()
    {
        return transform;
    }
    public void MoveToTarget()
    {
        Vector3 dir = player.position - transform.position;
        Vector3 normalizedDir = dir.normalized;

        transform.position += normalizedDir * speed * Time.deltaTime;
    }

    public override void TakeDamage(BaseEntity damager, Elements damageElement)
    {
        int finalDamage = damager.Stats.Power;

        if (this.element == Elements.Air && damageElement == Elements.Earth) finalDamage *= 2;

        stats.TakeDamage(finalDamage);
        Debug.Log($"{gameObject.name} recibió {finalDamage} de daño.");

        if (stats.Health <= 0) Die();
    }

    private void Die()
    {
        // Soltar XP al morir
        if (xpOrbPrefab != null)
            Instantiate(xpOrbPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}