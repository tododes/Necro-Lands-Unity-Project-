using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    [SerializeField] private List<Node> childs = new List<Node>();
    [SerializeField] private Node parent;
    [SerializeField] private Node chosenChild;

    [SerializeField] private int status;
    private bool statusChanged;

    [SerializeField] private Talent talent;
    private Color[] statusColors;
    private TalentTreeController controller;

    public void AddChild(Node n){
        if(!childs.Contains(n))
            childs.Add(n);
    }

    public int getStatus() { return status; }
    public Node getParent() { return parent; }
    public Node getChildAt(int i) { return childs[i]; }

    public void setParent(Node p) { parent = p; }
    private SpriteRenderer spriteRenderer;

    //void Start()
    //{
    //    //status = 0;
    //    statusChanged = false;
    //}

    public void setChosenChild(Node cc)
    {
        chosenChild = cc;
        for (int i = 0; i < childs.Count; i++)
        {
            if (!childs[i].Equals(chosenChild))
                childs[i].PurelyChangeStatus(0);
        }
    }

    void Awake(){
        statusColors = new Color[4];
        statusColors[0] = Color.red;
        statusColors[1] = Color.blue;
        statusColors[2] = Color.green;
        statusColors[3] = Color.black;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = statusColors[status];
    }

    void Start(){
        controller = TalentTreeController.singleton;
    }

    void Update(){
        if (statusChanged){
            NotifyChangeToChild();
            statusChanged = false;
        }
        spriteRenderer.color = statusColors[status];
    }

    public void NotifyChangeToChild(){
        for (int i = 0; i < childs.Count; i++){
            int x = status - 1;
            x = Mathf.Clamp(x, 0, 3);
            childs[i].ChangeStatus(x);
        }
    }

    public void ChangeStatus(int change){
        spriteRenderer.color = statusColors[change];
        if (change >= 1){
            status = change;
            statusChanged = true;
        }
        if(change == 2 && parent){
            Debug.Log(gameObject.name);
            if(parent)
                parent.PurelyChangeStatus(change + 1);
        }
            
    }

    public void PurelyChangeStatus(int change){
        status = change;
    }

    public int checkActivatedNode(){
        for (int i = 0; i < childs.Count; i++){
            if (childs[i].getStatus() >= 2)
                return i;
        }
        return -1;
    }

    public Talent getTalent(){
        return talent;
    }

    public void setTalent(Talent t){
        talent = t;
    }

    void OnMouseDown(){
        if(status == 1){
            ChangeStatus(2);
            parent.setChosenChild(this);
            controller.setCurrentTalent(talent);
        }
    }

    void OnMouseEnter(){
        //Debug.Log("Enter");
    }

    //public override bool Equals(object other)
    //{
    //    Node node = (Node)other;
    //    if (node.talent.Name == talent.Name)
    //        Debug.Log(node.talent.Name + " is equal to " + talent.Name);
    //    else
    //        Debug.Log(node.talent.Name + " is not equal to " + talent.Name);
    //    return node.talent.Name == talent.Name;
    //}
}
