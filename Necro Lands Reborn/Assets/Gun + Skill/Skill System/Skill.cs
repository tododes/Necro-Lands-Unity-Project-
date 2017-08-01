using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour {

    public Sprite sprite;
    protected float coolDown;
    protected float coolDownStatus;
    
    [SerializeField] protected GameActor owner;
    [SerializeField] protected Gun gun;

    public GameActor getOwner() { return owner; }
    public void setOwner(GameActor o) { owner = o; }

	protected virtual void Start (){
        InitializeSkill();
        coolDownStatus = 0.000f;
        if(owner)
            if(owner.GetComponentInChildren<Gun>())
                gun = owner.GetComponentInChildren<Gun>();
	}

    protected virtual void Update (){
	    if(coolDownStatus > 0.000f){
            coolDownStatus -= Time.deltaTime;
        }
        else if (coolDownStatus < 0.000f){
            coolDownStatus = 0.000f;
        }

    }

    public bool Ready(){
        return (coolDownStatus <= 0.000f);
    }

    public virtual void InitializeSkill(){

    }

    public virtual void Use(){
        coolDownStatus = coolDown;
    }

    public override bool Equals(object other){
        Skill skill = (Skill) other;
        return skill.name == name;
    }
}
