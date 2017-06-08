using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour {
    [SerializeField]
    private GameController[] contollers;

    [SerializeField]
    private string[] gameNames = new string[10];

    private Dictionary<string, GameController> controllerDatabase = new Dictionary<string, GameController>();

	void Start() {
        gameNames[0] = "Game Scene";
        gameNames[1] = "Ultimate Game Scene";

        for (int i = 0; i < 2; i++){
            controllerDatabase.Add(gameNames[i], contollers[i]);
        }

        foreach(KeyValuePair<string, GameController> cg in controllerDatabase){
            Debug.Log(cg.Key);
        }
        //Debug.Log(Application.loadedLevelName);
        GameObject go = controllerDatabase[Application.loadedLevelName].gameObject;
        Instantiate(go);
	}
	
	void Update () {
		
	}
}
