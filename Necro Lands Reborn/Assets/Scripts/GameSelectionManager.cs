using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelectionManager : MonoBehaviour {

    public static GameSelectionManager singleton;

    [SerializeField] private GameMode[] gameModes;
    [SerializeField] private GameSelectionCamera selectionCamera;

    void Awake(){
        singleton = this;
    }
	// Use this for initialization
	void Start () {
        selectionCamera = GameSelectionCamera.singleton;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenScene(){
        string scene = gameModes[selectionCamera.getIndex()].Name;
        InterSceneImage.singleton.FinishScene(scene);
    }
}
