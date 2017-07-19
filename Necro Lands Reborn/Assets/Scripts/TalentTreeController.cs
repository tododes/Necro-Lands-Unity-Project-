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
    private List<int> nodeStatusData = new List<int>();

    [SerializeField] private Talent currentTalent;
    //[SerializeField] private TalentDatabase talentDB;

    void Awake(){
        singleton = this;
    }

    void OnEnable(){
        
    }

    public void setCurrentTalent(Talent t) { currentTalent = t; }

	// Use this for initialization
	void Start () {
        bf = new BinaryFormatter();
        nodes = new List<Node>(GetComponentsInChildren<Node>());
        if (Application.loadedLevelName.Contains("Main Menu")){
            FileStream fs = File.Create(Application.persistentDataPath + SaveKey.PLAYERTALENTDATABASE_KEY);
            bf.Serialize(fs, playerTalentCollection);
            fs.Close();
            if (!File.Exists(Application.persistentDataPath + SaveKey.TALENTTREEDATA_KEY))
                Root.ChangeStatus(2);
            else
                Debug.Log("Did exist");
            StartCoroutine(DelayToDestroy());
        }
        else if (Application.loadedLevelName.Contains("SkillTree")) {
            FileStream fs = File.Open(Application.persistentDataPath + SaveKey.PLAYERTALENTDATABASE_KEY, FileMode.Open);
            List<PlayerTalentList> ptl = (List<PlayerTalentList>)bf.Deserialize(fs);
            playerTalentCollection = ptl;
            List<Talent> talents = InitializeTalentTreeFromPlayer();
            for (int i = 0; i < talents.Count; i++){
                nodes[i].setTalent(talents[i]);
            }
            loadTalentTree();
        }
        nodes = new List<Node>(GetComponentsInChildren<Node>());
        sb = new StringBuilder();
	}

    private IEnumerator DelayToDestroy(){
        yield return new WaitForSeconds(1);
        if (!File.Exists(Application.persistentDataPath + SaveKey.TALENTTREEDATA_KEY)){
            List<int> statuses = new List<int>();
            for (int i = 0; i < nodes.Count; i++){
                statuses.Add(nodes[i].getStatus());
            }
            ApplicationInitializer.singleton.setTalentStatusData(statuses);
        }
        Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveTreeData(){
        FileStream fs = File.Create(Application.persistentDataPath + SaveKey.TALENTTREEDATA_KEY);
        for(int i = 0; i < 18; i++){
            nodeStatusData.Add(nodes[i].getStatus());
        }
        bf.Serialize(fs, nodeStatusData);
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
        List<int> data = (List<int>) bf.Deserialize(fs);
        for(int i = 0; i< 18; i++){
            nodeStatusData.Add(data[i]);
            nodes[i].ChangeStatus(data[i]);
        }
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