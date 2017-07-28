using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mission{

    [SerializeField] protected string name;
    [SerializeField] protected string description;
    [SerializeField] protected int kill;
    [SerializeField] protected Clock clock;
    [SerializeField] protected bool useTimer;
    [SerializeField] protected bool accomplished;
    [SerializeField] protected bool unlocked;

    public Mission(string n, string desc, int k, Clock c, bool ut, bool ac, bool ul){
        name = n;
        description = desc;
        kill = k;
        clock = c;
        useTimer = ut;
        accomplished = ac;
        unlocked = ul;
    }

    public virtual bool isAccomplished() { return accomplished; }

    public virtual void validateAccomplishment(int playerKill) {
        if (useTimer){
            if (playerKill >= kill && (clock.min > 0 || clock.sec > 0))
                accomplished = true;
        }
        else{
            if (playerKill >= kill)
                accomplished = true;
        }
        
    }

    public bool isUnlocked() { return unlocked; }

}
