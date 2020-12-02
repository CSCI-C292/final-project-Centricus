using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject playerHandRight;
    public GameObject EquippedWeapon { get; set; }

    IWeapon equippedWeapon;
    CharacterStats characterStats;

    private void Start() {
        characterStats = GetComponent<CharacterStats>();
        EquippedWeapon = playerHandRight.transform.GetChild(0).gameObject;
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
    }

    public void EquipWeapon(Item item)
    {
        if (EquippedWeapon != null)
        {
            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHandRight.transform.GetChild(0).gameObject);
        }
        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" 
            + item.ObjectSlug), playerHandRight.transform.position,
                playerHandRight.transform.rotation);
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        equippedWeapon.Stats = item.Stats;
        EquippedWeapon.transform.SetParent(playerHandRight.transform);
        characterStats.AddStatBonus(item.Stats);
        Debug.Log(equippedWeapon.Stats[0] + "THIS ONE");
    }

    public void PerformWeaponAttack()
    {
        equippedWeapon.PerformAttack();
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            PerformWeaponAttack();
        }
    }
}
