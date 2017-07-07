using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour  {

    [SerializeField] private Mission objective;
    [SerializeField] protected FPSCharacter fpsCharacter;

    protected BinaryFormatter bf;
    protected MissionAccomplishedPanel panel;
    protected bool Accomplished;
    protected MissionDatabase missionDatabase;

    public bool isAccomplished{
        get { return Accomplished; }
    }

    private Game<Mission> game;
    protected void Awake(){
   
    }

    protected virtual void Start () {
        bf = new BinaryFormatter();
        missionDatabase = LoadMissionDatabase();
        if(File.Exists(Application.persistentDataPath + SaveKey.MISSION_KEY)){
            game = new Game<Mission>(SaveKey.MISSION_KEY);
            objective = game.getObjective();
        }
        fpsCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSCharacter>();
        panel = MissionAccomplishedPanel.singleton;
	}

    protected virtual void Update () {
        if(objective != null){
            if (Accomplished != objective.isAccomplished())
                Accomplished = objective.isAccomplished();
        }
        objective.validateAccomplishment(fpsCharacter.getTotalKill());
        if (objective.isAccomplished()){
            missionDatabase.MissionAccomplished(objective);
            panel.Trigger();
        }
	}

    protected MissionDatabase LoadMissionDatabase(){
        FileStream fs = File.Open(Application.persistentDataPath + SaveKey.MISSIONDATABASE_KEY, FileMode.Open);
        MissionDatabase m = (MissionDatabase) bf.Deserialize(fs);
        fs.Close();
        return m;
    }
}
