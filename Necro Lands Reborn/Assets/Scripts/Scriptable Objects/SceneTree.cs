using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTree : ScriptableObject {
    [SerializeField] private SceneTreeNode Root;
    [SerializeField] private SceneTreeNode CurrentSceneNode;

    public void OnStartApplication() {
        CurrentSceneNode = Root;
        Parentize(Root);
    }

    public void ChangeToChild(int index) { CurrentSceneNode = CurrentSceneNode.child[index]; }
    public void ChangeToParent() {
        Debug.Log(CurrentSceneNode.name);
        CurrentSceneNode = CurrentSceneNode.parent;
        Debug.Log(CurrentSceneNode.name);
        //Debug.Log(CurrentSceneNode.parent.name);
    }
    public SceneTreeNode getCurrent() { return CurrentSceneNode; }

    public void Parentize(SceneTreeNode node){
        if (node.child.Count <= 0)
            return;

        foreach(SceneTreeNode s in node.child){
            s.parent = node;
            Parentize(s);
        }
    }
}

