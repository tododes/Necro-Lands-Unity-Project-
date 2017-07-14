using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Talent {
    public string Name;
    public float BonusHP, BonusAttack, BonusArmor, BonusMoveSpeed;
    public float BonusMagicAttack, BonusMagicArmor, BonusLifesteal, BonusSpellLifesteal;
    public TrevorModifier trevorModifier;
    public GregoryModifier gregoryModifier;
    public MiraModifier miraModifier;
    public LucyModifier lucyModifier;
}

[System.Serializable]
public class TrevorModifier {
    public float bonusCritical;
    public float bonusDamageInstance;
    public float bonusMagicDamage;
}

[System.Serializable]
public class GregoryModifier {
    public float bonusReactiveArmor;
    public float bonusHPRegen;
    public float bonusDPSAura, bonusDamageReflection;

}

[System.Serializable]
public class MiraModifier {
    public float bonusFuryShot;
    public float bonusCombatFury;
    public float shootIntervalReduction;
}

[System.Serializable]
public class LucyModifier {
    public int bonusAttackReductionAura;
    public float extraBulletStun;
    public float statSwapCooldownReduction;
    public float cooldownReduction;
}

