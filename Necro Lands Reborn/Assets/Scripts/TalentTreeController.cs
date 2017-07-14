using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class TalentTreeController : TodoBehaviour {

    public static TalentTreeController singleton;

    [SerializeField] private int NumberOfPlayers;
    [SerializeField] private List<PlayerTalentList> playerTalentCollection = new List<PlayerTalentList>();
    [SerializeField] private List<Node> nodes;

    [SerializeField]
    private Node Root;
    private StringBuilder sb;
    private BinaryFormatter bf;

    [SerializeField] private Talent currentTalent;

    void Awake(){
        singleton = this;
    }

	// Use this for initialization
	void Start () {
        nodes = new List<Node>(GetComponentsInChildren<Node>());
        sb = new StringBuilder();
        bf = new BinaryFormatter();
        //for (int i = 0; i < NumberOfPlayers; i++){
        //    playerTalentCollection.Add(new PlayerTalentList());
        //}
        Root.ChangeStatus(2);
        List<Talent> talents = InitializeTalentTreeFromPlayer();
        for(int i = 0; i < talents.Count; i++){
            nodes[i].setTalent(talents[i]);
        }
        loadTalentTree();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string getTreeCode(){
        Node curr = Root;
        sb.Append(Root.getStatus());
        while(curr.checkActivatedNode() > -1){
            int checkResult = curr.checkActivatedNode();
            sb.Append(checkResult.ToString());
        }
        return sb.ToString();
    }

    public void SaveTreeCode(){
        FileStream fs = File.Create(Application.persistentDataPath + SaveKey.TALENTTREEDATA_KEY);
        string code = getTreeCode();
        bf.Serialize(fs, code);
        fs.Close();
    }

    private List<Talent> InitializeTalentTreeFromPlayer(){
        FileStream fs = File.Open(Application.persistentDataPath + SaveKey.PLAYERDATA_KEY, FileMode.Open);
        PlayerData pd = (PlayerData) bf.Deserialize(fs);
        for(int i = 0; i < playerTalentCollection.Count; i++){
            List<Talent> talents = playerTalentCollection[i].getTalentByName(pd.Name);
            if (talents != null)
                return talents;
        }
        return null;
    }

    public void loadTalentTree(){
        FileStream fs = File.Open(Application.persistentDataPath + SaveKey.TALENTTREEDATA_KEY, FileMode.Open);
        string code = (string) bf.Deserialize(fs);
        Node curr = Root;
        for(int i = 0; i < code.Length; i++){
            int index = code[i] - '0';
            Node next = curr.getChildAt(index);
            next.ChangeStatus(2);
            curr = next; 
        }
        currentTalent = curr.getTalent();
        fs.Close();
    }

    public void SaveCurrentTalent(){
        FileStream fs = File.Create(Application.persistentDataPath + SaveKey.CURRENTTALENT_KEY);
        bf.Serialize(fs, currentTalent);
        fs.Close();
    }
}

[System.Serializable]
public class PlayerTalentList
{
    [SerializeField] private string name;
    [SerializeField] private List<Talent> playerTalents;

    public PlayerTalentList(){
        playerTalents = new List<Talent>(18);
    }

    public List<Talent> getTalentByName(string n){
        if (name == n)
            return playerTalents;
        return null;
    }

    public string getName() { return name; }
}