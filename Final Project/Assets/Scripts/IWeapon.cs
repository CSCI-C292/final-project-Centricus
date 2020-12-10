using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Class provided by GameGrind
https://www.youtube.com/watch?v=7T4dFqT62Js&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=6
*/

public interface IWeapon
{
    List<BaseStat> stats { get; set; }
    CharacterStats characterStats { get; set; }
    void PerformAttack();
}
