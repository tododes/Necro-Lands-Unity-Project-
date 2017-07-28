using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterSceneButton : TodoBehaviour {

    private Button button;

    [SerializeField] private int index;
    [SerializeField] private SceneTree sceneTree;
    [SerializeField] private InterSceneButtonType buttonType;
    [SerializeField] private InterSceneImage image;

    void Start () {
        button = Cp<Button>();
        image = InterSceneImage.singleton;
        if(buttonType == InterSceneButtonType.TOCHILD)
            button.onClick.AddListener(ChangeCurrentSceneTreeNodeToChild);
        else
            button.onClick.AddListener(ChangeCurrentSceneTreeNodeToParent);
    }

	void Update () {
		
	}

    public void ChangeCurrentSceneTreeNodeToChild(){
        sceneTree.ChangeToChild(index);
        SceneTreeNode ss = sceneTree.getCurrent();
        image.FinishScene(ss.name);
    }

    public void ChangeCurrentSceneTreeNodeToParent(){
        sceneTree.ChangeToParent();
        SceneTreeNode ss = sceneTree.getCurrent();
        image.FinishScene(ss.name);
    }
}

public enum InterSceneButtonType { TOCHILD, TOPARENT }
