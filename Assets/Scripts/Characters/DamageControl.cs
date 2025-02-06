using UnityEngine;

public abstract class DamageControl : MonoBehaviour
{
    [Header("Character Health")]
    [SerializeField] private int maxHealth;  
    private int currentHealth; 

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    protected virtual void DealDamage(DamageControl target, int damage)
    {
        Debug.Log($"{gameObject.name} наносит {damage} урона {target.gameObject.name.ToString()}");
        target.TakeDamage(damage);
    }

    protected virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} получил {damage} урона. Осталось здоровья: {currentHealth}");

        if (!IsAlive())
        {
            Die();
        }
    }

    protected virtual bool IsAlive()
    { 
        return currentHealth > 0;
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
        Debug.Log($"{gameObject.name} погиб");
    }
}

