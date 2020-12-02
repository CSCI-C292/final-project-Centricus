using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Class framework provided by GameGrind
https://www.youtube.com/watch?v=7T4dFqT62Js&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=6
*/

public class Sword : MonoBehaviour, IWeapon
{
    public List<BaseStat> stats { get; set; }

    public void PerformAttack()
    {
        Debug.Log("Sword attack");
    }
}
