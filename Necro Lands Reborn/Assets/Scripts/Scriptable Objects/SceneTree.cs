using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTree : ScriptableObject {
    [SerializeField] private SceneTreeNode Root;
}

[System.Serializable]
public class SceneTreeNode {

    public string name;
    public SceneTreeNode parent;
    public List<SceneTreeNode> child;
}
