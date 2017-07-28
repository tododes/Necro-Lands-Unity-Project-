using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTreeNode : ScriptableObject {

    public string name;
    public SceneTreeNode parent;
    public List<SceneTreeNode> child;
}
