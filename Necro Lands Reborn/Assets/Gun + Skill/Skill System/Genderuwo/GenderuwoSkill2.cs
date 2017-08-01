using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderuwoSkill2 : Skill {

    //private List<FPSCharacter> femaleCharacters = new List<FPSCharacter>();

    public override void InitializeSkill(){
        SphereCollider sColl = gameObject.AddComponent<SphereCollider>();
        sColl.radius = 10f;
        sColl.isTrigger = true;
    }

    public override void Use(){
        base.Use();
    }

    void OnTriggerEnter(Collider coll){
        if (coll.tag.Contains("Player")){
            GameActor character = coll.GetComponent<GameActor>();
            if (character)
                if(character.gender == Gender.FEMALE){
                    owner.ModifyAttack(10);
                    owner.ModifySpeed(2);
                }
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag.Contains("Player")){
            GameActor character = coll.GetComponent<GameActor>();
            if (character)
                if (character.gender == Gender.FEMALE){
                    owner.ModifyAttack(-10);
                    owner.ModifySpeed(-2);
                }
        }
    }
}
