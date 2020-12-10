using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Class provided by GameGrind
https://www.youtube.com/watch?v=HrNebvxSUsU&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=7
*/

public interface IEnemy
{
    void TakeDamage(int amount);
    void PerformAttack();
}
