using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTree : ScriptableObject {
    [SerializeField] private SceneTreeNode Root;
    [SerializeField] private SceneTreeNode CurrentSceneNode;

    public void OnStartApplication() { CurrentSceneNode = Root; }

    public void ChangeToChild(int index) { CurrentSceneNode = CurrentSceneNode.child[index]; }
    public void ChangeToParent() { CurrentSceneNode = CurrentSceneNode.parent; }
}

[System.Serializable]
public class SceneTreeNode {

    public string name;
    public SceneTreeNode parent;
    public List<SceneTreeNode> child;
}
