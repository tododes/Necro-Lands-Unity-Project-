using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UltimateMission : Mission {

    [SerializeField] private int MonsterKill;
    [SerializeField] private int collectedTreasure;

    public UltimateMission(string n, string desc, int k, Clock c, bool ut, bool ac, bool ul, int mk, int ct) : base(n, desc, k, c, ut, ac, ul){
        MonsterKill = mk;
        collectedTreasure = ct;
    }
}
