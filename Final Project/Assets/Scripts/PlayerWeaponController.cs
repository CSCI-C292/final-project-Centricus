using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Class provided by GameGrind
https://www.youtube.com/watch?v=7T4dFqT62Js&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=6
*/

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject playerHandRight;
    public GameObject equippedWeapon { get; set; }

    Transform spawnProjectile;
    CharacterStats characterStats;

    void Start()
    {
        spawnProjectile = transform.Find("ProjectileSpawn");
        characterStats = GetComponent<Player>().characterStats;
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if (equippedWeapon != null)
        {
            // characterStats.RemoveStatBonus(equippedWeapon.GetComponent<IWeapon>().stats);
            Destroy(playerHandRight.transform.GetChild(0).gameObject);
        }
        equippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/"+itemToEquip.objectSlug)/*, 
            playerHandRight.transform.position, playerHandRight.transform.rotation*/);
        if (equippedWeapon.GetComponent<IProjectileWeapon>() != null)
        {
            equippedWeapon.GetComponent<IProjectileWeapon>().projectileSpawn = spawnProjectile;
        }
        equippedWeapon.GetComponent<IWeapon>().stats = itemToEquip.stats;
        equippedWeapon.GetComponent<IWeapon>().characterStats = characterStats;
        equippedWeapon.transform.SetParent(playerHandRight.transform);
        characterStats.AddStatBonus(itemToEquip.stats);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PerformWeaponAttack();
        }
    }

    public void PerformWeaponAttack()
    {
        equippedWeapon.GetComponent<IWeapon>().PerformAttack();
    }
}
