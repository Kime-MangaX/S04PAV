using UnityEngine;

public class HealthPotion : BaseCollectable
{
    [SerializeField] private int healAmount = 20;

    protected override void ApplyEffect(Player player)
    {
        int vidaActual = player.Stats.Health;
        player.Stats.SetHealth(vidaActual + healAmount);

        Debug.Log("Vida restaurada. Nueva vida: " + player.Stats.Health);
    }
}