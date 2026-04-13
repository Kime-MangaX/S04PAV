// Clase base para ítems
using UnityEngine;

public abstract class BaseCollectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            ApplyEffect(player);
            Destroy(gameObject);
        }
    }
    protected abstract void ApplyEffect(Player player);
}
