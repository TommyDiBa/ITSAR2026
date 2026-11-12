using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;

    float currentHealth;
    public float CurrentHealth => currentHealth;

    public bool IsDead { get; private set; }
    public Action<float, float> OnHealthChanged;
    public Action Died;

    private void Awake()
    
    {
        currentHealth = maxHealth;
    }


   public void TakeDamage(float damage)
    {
        if (IsDead) return;
        
        currentHealth -= damage;

        Debug.Log($"HP: {currentHealth}/{maxHealth}");
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        if(currentHealth <= 0)
        {
            Die();
        }
    }


    private void Heal(float heal)
    {
        currentHealth += heal;
        Mathf.Clamp(currentHealth, 0f, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    private void SetHealth(float _health, float _maxHealth)
    {
        currentHealth = _health;
        maxHealth = _maxHealth;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    void Die()
    {
        IsDead = true; 
        gameObject.SetActive(false);
        Died?.Invoke();
    }
}
