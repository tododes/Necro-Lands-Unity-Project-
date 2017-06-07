using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    [SerializeField] private List<Node> childs = new List<Node>();
    private Node parent;
    [SerializeField] private int status;
    private bool statusChanged;

    public void AddChild(Node n){
        if(!childs.Contains(n))
            childs.Add(n);
    }

    public Node getParent() { return parent; }
    public Node getChildAt(int i) { return childs[i]; }

    public void setParent(Node p) { parent = p; }

    //void Start(){
    //    status = 0;
    //    statusChanged = false;
    //}

    void Update(){
        if (statusChanged){
            NotifyChangeToChild();
            statusChanged = false;
        }
    }

    public void NotifyChangeToChild(){
        for (int i = 0; i < childs.Count; i++){
            int x = status - 1;
            x = Mathf.Clamp(x, 0, 2);
            childs[i].ChangeStatus(x);
        }
    }

    public void ChangeStatus(int change){
        if(change >= 1){
            status = change;
            statusChanged = true;
        }
    }
}
