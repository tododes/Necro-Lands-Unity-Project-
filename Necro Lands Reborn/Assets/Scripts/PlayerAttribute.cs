using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : MonoBehaviour {

    [SerializeField] private string playerName;
    [SerializeField] private List<string> skillNames;

    public string getPlayerName() { return playerName; }
    public List<string> getPlayerSkillNames() { return skillNames; }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
