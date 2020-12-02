using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Class provided by GameGrind
https://www.youtube.com/watch?v=wqEk5mzJB3M&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=5
*/

public class BaseStat
{
    public List<StatBonus> baseAdditives { get; set; }
    public int baseValue { get; set; }
    public string statName { get; set; }
    public string statDescription { get; set; }
    public int finalValue { get; set; }

    public BaseStat(int baseValue, string statName, string statDescription)
    {
        this.baseAdditives = new List<StatBonus>();
        this.baseValue = baseValue;
        this.statName = statName;
        this.statDescription = statDescription;
    }

    public void AddStatBonus(StatBonus statBonus)
    {
        this.baseAdditives.Add(statBonus);
    }

    public void RemoveStatBonus(StatBonus statBonus)
    {
        this.baseAdditives.Remove(this.baseAdditives.Find(x => x.bonusValue == statBonus.bonusValue));
    }

    public int GetCalculatedStatValue()
    {
        this.finalValue = 0;
        this.baseAdditives.ForEach(x => this.finalValue += x.bonusValue);
        return this.finalValue += this.baseValue;
    }
}
