using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateGameController : GameController {

    [SerializeField] private UltimateMission objective;
    private Game<UltimateMission> ultimateGame;
	// Use this for initialization
	protected override void Start () {
        ultimateGame = new Game<UltimateMission>("/MissionData.data");
        objective = ultimateGame.getObjective();
        fpsCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSCharacter>();
        panel = MissionAccomplishedPanel.singleton;
    }

    // Update is called once per frame
    protected override void Update () {
		
	}
}
