using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Reward
{
    [SerializeField] private int goldGain;
    [SerializeField] private int expGain;
    [SerializeField] private int tokenGain;

    public Reward(int gg = 0, int eg = 0, int tg = 0){
        goldGain = gg;
        expGain = eg;
        tokenGain = tg;
    }

    public static Reward operator +(Reward ra, Reward rw){
        ra.goldGain += rw.goldGain;
        ra.expGain += rw.expGain;
        ra.tokenGain += rw.tokenGain;
        return ra;
    }

    public static Reward operator -(Reward ra, Reward rw){
        ra.goldGain -= rw.goldGain;
        ra.expGain -= rw.expGain;
        ra.tokenGain -= rw.tokenGain;
        return ra;
    }

    public int getGoldGain() { return goldGain; }
    public int getExpGain() { return expGain; }
    public int getTokenGain() { return tokenGain; }
}
