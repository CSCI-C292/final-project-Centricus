using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Class framework provided by GameGrind
https://www.youtube.com/watch?v=7T4dFqT62Js&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=6
*/

public class Sword : MonoBehaviour, IWeapon
{
    private Animator animator;
    public List<BaseStat> stats { get; set; }
    public CharacterStats characterStats { get; set; }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PerformAttack()
    {
        animator.SetTrigger("Base_Attack");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit something");
        if (other.tag == "Enemy")
        {
            Debug.Log("Hit " + other.name);
            other.GetComponent<IEnemy>().TakeDamage(characterStats.GetStat(BaseStat.BaseStatType.power).GetCalculatedStatValue());
        }
    }
}
