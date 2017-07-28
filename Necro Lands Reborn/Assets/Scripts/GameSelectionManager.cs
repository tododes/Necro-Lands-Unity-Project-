using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameSelectionManager : MonoBehaviour {

    public static GameSelectionManager singleton;

    [SerializeField] private GameMode[] gameModes;
    [SerializeField] private GameSelectionCamera selectionCamera;
    [SerializeField] private Image proceedImage;
    [SerializeField] private GameModeEnemyDatabase enemyDB;
    [SerializeField] private List<MissionDatabase> missionDB;

    private BinaryFormatter bf;
    private PlayerData playerData;
    private FileStream fs;

    [SerializeField] private MissionDatabase currentMissionDB;

    void Awake(){
        singleton = this;
    }
	// Use this for initialization
	void Start () {
        gameModes = GetComponentsInChildren<GameMode>();
        bf = new BinaryFormatter();
        selectionCamera = GameSelectionCamera.singleton;
        fs = File.Open(Application.persistentDataPath + SaveKey.MISSIONDATABASE_KEY, FileMode.Open);
        missionDB = (List<MissionDatabase>) bf.Deserialize(fs);
        fs.Close();
        fs = File.Open(Application.persistentDataPath + SaveKey.PLAYERDATA_KEY, FileMode.Open);
        playerData = (PlayerData) bf.Deserialize(fs);
        fs.Close();
        Debug.Log(playerData.currentStage);
        currentMissionDB = missionDB[playerData.currentStage - 1];
        List<Mission> currentStageMissions = currentMissionDB.getMissions();
        for (int i = 0; i < gameModes.Length; i++){
            gameModes[i].setMission(currentStageMissions[i]);
        }
	}

    public void Save(){
        gameModes[selectionCamera.getIndex()].Save();
    }
	
	// Update is called once per frame
	void Update () {
        //proceedImage.enabled = gameModes[selectionCamera.getIndex()].isUnlocked();
    }

    //public void OpenScene(){
    //    GameMode mode = gameModes[selectionCamera.getIndex()];
    //    if (mode.isUnlocked()){
    //        string scene = mode.Name;
    //        enemyDB.setEnemies(mode.getEnemies());
    //        mode.Save();
    //        InterSceneImage.singleton.FinishScene(scene);
    //    }
    //}

   
}
