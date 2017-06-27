using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSelectionManager : MonoBehaviour {

    public static GameSelectionManager singleton;

    [SerializeField] private GameMode[] gameModes;
    [SerializeField] private GameSelectionCamera selectionCamera;
    [SerializeField] private Image proceedImage;

    void Awake(){
        singleton = this;
    }
	// Use this for initialization
	void Start () {
        selectionCamera = GameSelectionCamera.singleton;
        
	}
	
	// Update is called once per frame
	void Update () {
        proceedImage.enabled = gameModes[selectionCamera.getIndex()].isUnlocked();
    }

    public void OpenScene(){
        GameMode mode = gameModes[selectionCamera.getIndex()];
        if (mode.isUnlocked()){
            string scene = mode.Name;
            mode.Save();
            InterSceneImage.singleton.FinishScene(scene);
        }
    }

   
}
