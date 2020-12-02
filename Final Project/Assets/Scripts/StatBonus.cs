using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Class provided by GameGrind
https://www.youtube.com/watch?v=wqEk5mzJB3M&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=5
*/

public class StatBonus
{
    public int bonusValue { get; set; }
    
    public StatBonus(int bonusValue)
    {
        this.bonusValue = bonusValue;
        Debug.Log("New stat bonus of " + bonusValue + " initiated");
    }
}
