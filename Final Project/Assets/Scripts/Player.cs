using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Class provided by GameGrind
https://www.youtube.com/watch?v=Bs0rJEkYBvc&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=16
*/

public class Player : MonoBehaviour
{
    public CharacterStats characterStats;
    public float currentHealth;
    public float maxHealth;

    void Awake()
    {
        characterStats = new CharacterStats(10, 10, 10);
        this.currentHealth = this.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died: resetting health.");
        this.currentHealth = this.maxHealth;
    }
}
