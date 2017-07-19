using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterSceneButton : TodoBehaviour {

    private Button button;

    [SerializeField] private int index;
    [SerializeField] private SceneTree sceneTree;
    [SerializeField] private InterSceneButtonType buttonType;

    void Start () {
        button = Cp<Button>();
        if(buttonType == InterSceneButtonType.TOCHILD)
            button.onClick.AddListener(ChangeCurrentSceneTreeNodeToChild);
        else
            button.onClick.AddListener(ChangeCurrentSceneTreeNodeToParent);
    }

	void Update () {
		
	}

    public void ChangeCurrentSceneTreeNodeToChild(){
        sceneTree.ChangeToChild(index);
    }

    public void ChangeCurrentSceneTreeNodeToParent(){
        sceneTree.ChangeToParent();
    }
}

public enum InterSceneButtonType { TOCHILD, TOPARENT }
