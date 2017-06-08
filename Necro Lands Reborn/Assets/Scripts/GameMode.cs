using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameMode : MonoBehaviour {

    [SerializeField] protected string SceneName;

    private Mission mission;
    protected BinaryFormatter binaryFormatter;
    protected FileStream fileStream;
     
    public string Name {
        get { return SceneName; }
    }

	// Use this for initialization
	protected void Start () {
        binaryFormatter = new BinaryFormatter();
	}

    public Mission getMission() { return mission; }

    protected void SaveMission<T>(T mission, string filename) where T : Mission {
        fileStream = File.Create(Application.persistentDataPath + filename);
        binaryFormatter.Serialize(fileStream, mission);
        fileStream.Close();
    }

    public virtual void Save(){
        Clock clock = new Clock(3, 0);
        mission = new Mission("Ez standard", "Catch the cat", 3, clock, true, false, true);
        SaveMission<Mission>(mission, "/MissionData.data");
    }
}
