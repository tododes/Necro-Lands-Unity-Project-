using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour  {

    //public static GameController singleton;

    [SerializeField] private Mission objective;
    [SerializeField] protected FPSCharacter fpsCharacter;

    protected MissionAccomplishedPanel panel;
    protected bool Accomplished;

    public bool isAccomplished{
        get { return Accomplished; }
    }

    private Game<Mission> game;
    protected void Awake(){
   
    }

    protected virtual void Start () {
        game = new Game<Mission>("/MissionData.data");
        objective = game.getObjective();
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
            panel.Trigger();
        }
	}
}
