using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FPSCharacter : GameActor
{
    [SerializeField]
    private PlayerData playerData;

    [SerializeField]
    private int totalKill;

    [SerializeField]
    private WeaponManager weaponManager;

    [SerializeField]
    private PlayerInteraction MyInteraction;

    public PlayerInteraction getPlayerInteraction(){
        return MyInteraction;
    }

    public WeaponManager getWeaponManager(){
        return weaponManager;
    }

    void Start () {
        HP = MaxHP = 100;
        Bounty = 50;
        totalKill = 0;
	}

    public int getTotalKill() { return totalKill; }
    public void killEnemy() { totalKill++; }

	void Update ()
    {

	}

    public void GainReward(Reward reward){
        playerData.TotalMoney += reward.getGoldGain();
        playerData.Exp += reward.getExpGain();
        playerData.Token += reward.getTokenGain();
    }
}
