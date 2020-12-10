using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Class provided by GameGrind
https://www.youtube.com/watch?v=7T4dFqT62Js&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=6
*/

public class InventoryController : MonoBehaviour
{
    public PlayerWeaponController playerWeaponController;
    public Item sword;
    public Item staff;

    void Start()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();
        List<BaseStat> swordStats = new List<BaseStat>();
        swordStats.Add(new BaseStat(BaseStat.BaseStatType.power, 6, "Power", "The sword's power level."));
        sword = new Item(swordStats, "sword");
        staff = new Item(swordStats, "staff");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            playerWeaponController.EquipWeapon(sword);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            playerWeaponController.EquipWeapon(staff);
        }
    }

}
