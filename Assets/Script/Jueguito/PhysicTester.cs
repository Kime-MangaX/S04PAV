using UnityEngine;
using UnityEngine.InputSystem;

public class PhysicTester : MonoBehaviour
{
    private Rigidbody2D rb;
    public LayerMask layer;
    public float radius;
    public float force;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 20, layer);

        if (hit.collider != null)
        {
            Debug.Log("Hit:" + hit.collider.name);
        }
    }

    private void Update()
    {

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            print("press space");
            DomainExpansion();
        }
    }

    public void DomainExpansion()
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach(Collider2D collision in collisions)
        {
            Debug.Log("coll" + collision.name);

            if(collision.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                Vector2 dir = (collision.transform.position - transform.position).normalized;

                collision.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

                collision.GetComponent<Rigidbody2D>().AddForce(dir * force, ForceMode2D.Impulse);
            }
        }

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, Vector2.up * 20);
    }
}
