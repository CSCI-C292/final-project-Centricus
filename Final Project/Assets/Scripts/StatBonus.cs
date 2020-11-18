using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Class provided by GameGrind
https://www.youtube.com/watch?v=
    wqEk5mzJB3M&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=5&ab_channel=GameGrind
*/

public class StatBonus
{
    public int BonusValue { get; set; }

    public StatBonus(int bonusValue)
    {
        this.BonusValue = bonusValue;
        Debug.Log("New stat bonus initiated");
    }
}
