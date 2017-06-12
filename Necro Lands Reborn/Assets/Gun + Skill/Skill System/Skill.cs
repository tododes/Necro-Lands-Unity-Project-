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
        coolDownStatus = 0.000f;
        gun = owner.GetComponentInChildren<Gun>();
        InitializeSkill();
	}

    protected virtual void Update (){
	    if(coolDownStatus > 0.000f)
        {
            coolDownStatus -= Time.deltaTime;
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
}
