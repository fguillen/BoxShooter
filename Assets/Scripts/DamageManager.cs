using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WeaponSystem;

public class DamageManager : MonoBehaviour, IHittable
{
    int maxHealth;
    int currentHealth;

    public UnityEvent<Vector2> OnHit;
    public UnityEvent OnDie;
    public UnityEvent<int> OnMaxHealthSet;
    public UnityEvent<int> OnHealthChange;

    public Agent agent;
    public bool isDead = false;

    public void Initialize(Agent agent, int maxHealth)
    {
        this.agent = agent;
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
        OnMaxHealthSet?.Invoke(maxHealth);
        isDead = false;
    }

    public void GetHit(int damage, Vector2 point)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(0, currentHealth);

        Debug.Log($"GetHit({damage}, {point}, {currentHealth})");

        OnHealthChange?.Invoke(currentHealth);

        if(currentHealth == 0)
        {
            agent.Die();
            OnDie?.Invoke();
            isDead = true;
        }
        else
            OnHit?.Invoke(point);
    }

    public void AddHealth(int value)
    {
        currentHealth += value;
        currentHealth = Mathf.Min(maxHealth, currentHealth);
        OnHealthChange?.Invoke(currentHealth);
    }

    public Agent Agent()
    {
        return agent;
    }
}
