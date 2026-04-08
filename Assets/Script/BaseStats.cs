using UnityEngine;



public class BaseStats 
{
    // Relación de Composición
    [SerializeField] private int health = 100;
    private int power;
    private int speed;
    private int knockback;
    private int xp;
    public int damageValue = 10;


    public BaseStats(int health , int power, int speed, int knockback , int xp , int damageValue)
    {
        SetHealth(health);
        SetPower(power);
        SetSpeed(speed);
        SetKnockback(knockback);
        SetXP(xp);
        SetDamageValue(damageValue);


    }
    public void SetPower(int power)
    {
        this.power = power;
    }
    public void SetHealth(int health)
    {
        if(health <= 0)
            health = 0;

        this.health = health;
    }
  
    public void SetSpeed(int speed)
    {
        this.speed = speed;
    }
    public void SetKnockback(int knockback)
    {
        this.knockback = knockback;
    }
    public void SetXP(int xp)
    {
        this.xp = xp;
    }

    public void SetDamageValue(int damageValue)
    {
        this.damageValue = damageValue;
    }

    public void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0)
            health = 0;

    }
    public int Health => health;
    public int Power => power;
    public int Speed => speed;
    public int Knockback => knockback;
    public int XP => xp;
    public int DamageValue => damageValue;






    ~BaseStats()
    {
        Debug.Log("Eliminado por el garbage collector");
    }
}
