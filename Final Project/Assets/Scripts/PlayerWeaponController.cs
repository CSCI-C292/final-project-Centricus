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

    CharacterStats characterStats;

    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if (equippedWeapon != null)
        {
            characterStats.RemoveStatBonus(equippedWeapon.GetComponent<IWeapon>().stats);
            Destroy(playerHandRight.transform.GetChild(0).gameObject);
        }
        equippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/"+itemToEquip.objectSlug), 
            playerHandRight.transform.position, playerHandRight.transform.rotation);
        equippedWeapon.GetComponent<IWeapon>().stats = itemToEquip.stats;
        equippedWeapon.transform.SetParent(playerHandRight.transform);
        characterStats.AddStatBonus(itemToEquip.stats);
    }

    public void PerformWeaponAttack()
    {
        equippedWeapon.GetComponent<IWeapon>().PerformAttack();
    }
}
