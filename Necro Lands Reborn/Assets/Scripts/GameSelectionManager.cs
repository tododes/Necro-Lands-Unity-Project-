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
        GameMode mode = gameModes[selectionCamera.getIndex()];
        string scene = mode.Name;
        mode.Save();
        InterSceneImage.singleton.FinishScene(scene);
    }

   
}
