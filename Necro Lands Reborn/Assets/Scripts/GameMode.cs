﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameMode : MonoBehaviour {

    [SerializeField] protected string SceneName;

    [SerializeField]
    protected Mission mission;
    protected BinaryFormatter binaryFormatter;
    protected FileStream fileStream;
    protected bool Unlocked;
    //protected GameSelectionCamera selectionCamera;

    [SerializeField] protected Enemy[] enemies;

    public Enemy[] getEnemies() { return enemies; }
     
    public string Name {
        get { return SceneName; }
    }

    public void setMission(Mission m){
        mission = m;
    }

	// Use this for initialization
	protected void Start () {
        binaryFormatter = new BinaryFormatter();
        fileStream = File.Open(Application.persistentDataPath + SaveKey.MISSIONDATABASE_KEY, FileMode.Open);
        fileStream.Close();
    }

    public Mission getMission() { return mission; }
    public bool isUnlocked() { return Unlocked; }

    protected void SaveMission<T>(T mission, string filename) where T : Mission {
        fileStream = File.Create(Application.persistentDataPath + filename);
        binaryFormatter.Serialize(fileStream, mission);
        fileStream.Close();
    }

    public virtual void Save(){
        //Clock clock = new Clock(3, 0);
        //mission = new Mission("Ez standard", "Catch the cat", 3, clock, true, false, true);
        SaveMission<Mission>(mission, SaveKey.MISSION_KEY);
    }
}
