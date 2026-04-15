using UnityEngine;

public class XpOrb : BaseCollectable
{
    [SerializeField] private int xpValue = 10;

    protected override void ApplyEffect(Player player)
    {
        Debug.Log("Puntos de Experiencia obtenidos: " + xpValue);
    }
}