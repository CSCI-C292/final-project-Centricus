using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    Animator animator;
    public List<BaseStat> Stats { get; set; }

    private void Start() 
    {
        animator = GetComponent<Animator>();
        Stats.Add(new BaseStat(0, "Power", "Your power level."));
    }

    public void PerformAttack()
    {
        animator.SetTrigger("Base_Attack");
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<IEnemy>().TakeDamage(Stats[0].GetCalculatedStatValue());
        }
    }
}