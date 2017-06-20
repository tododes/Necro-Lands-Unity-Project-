using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


public class SkillTreeController : MonoBehaviour {

    public static SkillTreeController singleton;
    [SerializeField] private Node Root;

    private StringBuilder sb;
    public string code;

    void Awake(){
        singleton = this;
        Root.ChangeStatus(2);
        sb = new StringBuilder();
    }

    void Start(){
 
    }

    public void MapSkillTree() {
        int x = 0;
        Node current = Root;
        for(int i = 0; i < code.Length; i++){
            current.ChangeStatus(2);
            x = code[i] - '0';
            current = current.getChildAt(x);
        }
    }

    public void SetCode(){
        Node n = Root;
        while(n.checkActivatedNode() > -1){
            int activatedNodeIndex = n.checkActivatedNode();
            sb.Append(activatedNodeIndex.ToString());
            n = Root.getChildAt(activatedNodeIndex - 1);
        }
    }
}
