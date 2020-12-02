using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Class provided by GameGrind
https://www.youtube.com/watch?v=wqEk5mzJB3M&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=5
*/

public class CharacterStats : MonoBehaviour
{
    public List<BaseStat> stats = new List<BaseStat>();

    void Start()
    {
        stats.Add(new BaseStat(4, "Power", "Your power level."));
    }

    public void AddStatBonus(List<BaseStat> baseStats)
    {
        foreach(BaseStat baseStat in baseStats)
        {
            stats.Find(x => x.statName == baseStat.statName).AddStatBonus(new StatBonus(baseStat.baseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> baseStats)
    {
        foreach(BaseStat baseStat in baseStats)
        {
            stats.Find(x => x.statName == baseStat.statName).RemoveStatBonus(new StatBonus(baseStat.baseValue));
        }
    }
}
