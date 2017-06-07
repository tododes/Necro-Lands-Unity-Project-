using UnityEngine;
using System.Collections;

public class FPSCharacter : GameActor
{
    [SerializeField]
    private PlayerData playerData;

    void Start () {
        HP = MaxHP = 100;
        Bounty = 50;
	}

	void Update ()
    {

	}

    public void GainReward(Reward reward){
        playerData.TotalMoney += reward.getGoldGain();
        playerData.Exp += reward.getExpGain();
        playerData.Token += reward.getTokenGain();
    }
}
