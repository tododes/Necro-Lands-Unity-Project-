using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    [SerializeField] private List<Node> childs = new List<Node>();
    [SerializeField] private Node parent;
    [SerializeField] private Node chosenChild;

    [SerializeField] private int status;
    private bool statusChanged;

    public void AddChild(Node n){
        if(!childs.Contains(n))
            childs.Add(n);
    }

    public int getStatus() { return status; }
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

    public int checkActivatedNode(){
        for (int i = 0; i < childs.Count; i++){
            if (childs[i].getStatus() >= 2)
                return (i + 1);
        }
        return -1;
    }
}
