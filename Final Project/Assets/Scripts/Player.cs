using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Class provided by GameGrind
https://www.youtube.com/watch?v=Bs0rJEkYBvc&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=16
*/

public class Player : MonoBehaviour
{
    public CharacterStats characterStats;
    public float currentHealth;
    public float maxHealth;
    [SerializeField] UIManager UIManager;

    void Awake()
    {
        characterStats = new CharacterStats(3, 3, 3);
        this.currentHealth = this.maxHealth;
        UIManager.score = 0;
    }

    void Update()
    {
        UIManager.currentHP = currentHealth;
        UIManager.maxHP = maxHealth;
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
        SceneManager.LoadScene("GameOver");
        this.currentHealth = this.maxHealth;
    }
}
