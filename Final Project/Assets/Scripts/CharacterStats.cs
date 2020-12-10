using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Class provided by GameGrind
https://www.youtube.com/watch?v=wqEk5mzJB3M&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=5
*/

public class CharacterStats
{
    public List<BaseStat> stats = new List<BaseStat>();

    public CharacterStats(int power, int toughness, int attackSpeed)
    {
        stats = new List<BaseStat>() 
        {
            new BaseStat(BaseStat.BaseStatType.power, power, "Power", "Your power level."),
            new BaseStat(BaseStat.BaseStatType.toughness, toughness, "Toughness", "Your toughness level."),
            new BaseStat(BaseStat.BaseStatType.attackSpeed, attackSpeed, "Attack Speed", "Your Attack Speed."),
        };
    }

    public BaseStat GetStat(BaseStat.BaseStatType stat)
    {
        return this.stats.Find(x => x.statType == stat);
    }

    public void AddStatBonus(List<BaseStat> baseStats)
    {
        foreach(BaseStat baseStat in baseStats)
        {
            GetStat(baseStat.statType).AddStatBonus(new StatBonus(baseStat.baseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> baseStats)
    {
        foreach(BaseStat baseStat in baseStats)
        {
            GetStat(baseStat.statType).RemoveStatBonus(new StatBonus(baseStat.baseValue));;
        }
    }
}
