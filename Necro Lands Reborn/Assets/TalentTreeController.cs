using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class TalentTreeController : TodoBehaviour {

    public static TalentTreeController singleton;

    public const string TalentTreeDataPath = "/TalentTreeData.data";
    public const string TalentDataPath = "/TalentData.data";

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
        sb = new StringBuilder();
        bf = new BinaryFormatter();
        Root.ChangeStatus(2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string getTreeCode(){
        Node curr = Root;
        while(curr.checkActivatedNode() > -1){
            int checkResult = curr.checkActivatedNode();
            sb.Append(checkResult.ToString());
        }
        return sb.ToString();
    }

    public void SaveTreeCode(){
        FileStream fs = File.Create(Application.persistentDataPath + TalentTreeDataPath);
        string code = getTreeCode();
        bf.Serialize(fs, code);
        fs.Close();
    }

    public void loadTalentTree(){
        FileStream fs = File.Open(Application.persistentDataPath + TalentTreeDataPath, FileMode.Open);
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
        FileStream fs = File.Create(Application.persistentDataPath + TalentDataPath);
        bf.Serialize(fs, currentTalent);
        fs.Close();
    }
}
