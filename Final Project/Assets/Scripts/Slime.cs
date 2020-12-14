using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

/*
Class provided by GameGrind
https://www.youtube.com/watch?v=HrNebvxSUsU&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=7
*/

public class Slime : MonoBehaviour, IEnemy
{
    public LayerMask aggroLayerMask;
    public float maxHealth;
    public string behavior;
    [SerializeField] UIManager UIManager;

    private float currentHealth;
    private Player player;
    private NavMeshAgent navAgent;
    private CharacterStats characterStats;
    private Collider[] aggroColliders;

    EnemyFireball fireball;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        // navAgent.enabled = false;
        // Invoke("EnableNavMeshAgent", 1f);
        characterStats = new CharacterStats(6, 10, 2);
        currentHealth = maxHealth;
        fireball = Resources.Load<EnemyFireball>("Weapons/Projectiles/enemyFireball");
    }

    void FixedUpdate()
    {
        aggroColliders = Physics.OverlapSphere(transform.position, 9001, aggroLayerMask);
        if (aggroColliders.Length > 0)
        {
            ChasePlayer(aggroColliders[0].GetComponent<Player>());
        }
    }

    // private void EnableNavMeshAgent()
    // {
    //     navAgent.enabled = true;
    // }   

    public void PerformAttack()
    {
        if (behavior == "Hunt")
        {
            player.TakeDamage(5);
        }
        else if (behavior == "Shoot")
        {
            CastProjectile();
        }
    }

    public void CastProjectile()
    {
        EnemyFireball fireballInstance = Instantiate(fireball, transform.position, transform.rotation);
        fireballInstance.direction = Vector3.Normalize(player.transform.position - transform.position);
        fireballInstance.damage = characterStats.GetStat(BaseStat.BaseStatType.power).GetCalculatedStatValue();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
        Debug.Log(currentHealth);
    }

    void ChasePlayer(Player player)
    {
        this.player = player;
        navAgent.SetDestination(player.transform.position);
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            if (!IsInvoking("PerformAttack"))
            {
                InvokeRepeating("PerformAttack", .5f, 2f);
            }
        }
        else
        {
            CancelInvoke();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        UIManager.score++;
    }
}
