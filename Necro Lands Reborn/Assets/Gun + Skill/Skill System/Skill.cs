using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour {

    public Sprite sprite;
    protected float coolDown;
    protected float coolDownStatus;
    

	void Start ()
    {
        coolDownStatus = 0.000f;
	}

	void Update ()
    {
	    if(coolDownStatus > 0.000f)
        {
            coolDownStatus -= Time.deltaTime;
        }
	}

    public bool Ready()
    {
        return (coolDownStatus == 0.000f);
    }

    public virtual void Use()
    {
        coolDownStatus = coolDown;
    }
}
