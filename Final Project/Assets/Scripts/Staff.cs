using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Class framework provided by GameGrind
https://www.youtube.com/watch?v=hyh3kKGvJQw&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=8
*/

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon
{
    private Animator animator;
    public List<BaseStat> stats { get; set; }
    public Transform projectileSpawn { get; set; }
    public CharacterStats characterStats { get; set; }

    Fireball fireball;

    void Start()
    {
        fireball = Resources.Load<Fireball>("Weapons/Projectiles/fireball");
        animator = GetComponent<Animator>();
    }

    public void PerformAttack()
    {
        animator.SetTrigger("Base_Attack");
    }

    public void CastProjectile()
    {
        Fireball fireballInstance = Instantiate(fireball, projectileSpawn.position, projectileSpawn.rotation);
        fireballInstance.direction = transform.parent.parent.forward;
        fireballInstance.damage = characterStats.GetStat(BaseStat.BaseStatType.power).GetCalculatedStatValue();
    }
}
