using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Class provided by GameGrind
https://www.youtube.com/watch?v=7T4dFqT62Js&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=6
*/

public class Item
{
    public List<BaseStat> stats { get; set; }
    public string objectSlug { get; set; }

    public Item(List<BaseStat> stats, string objectSlug)
    {
        this.stats = stats;
        this.objectSlug = objectSlug;
    }
}
