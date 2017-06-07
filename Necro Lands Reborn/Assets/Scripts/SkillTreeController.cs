using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeController : MonoBehaviour {

    public static SkillTreeController singleton;
    [SerializeField] private Node Root;

    void Awake(){
        singleton = this;
        Root.ChangeStatus(2); 
    }

}
