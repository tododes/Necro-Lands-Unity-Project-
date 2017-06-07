using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class DailyRewardManager : MonoBehaviour {

    public static DailyRewardManager singleton;

    private BinaryFormatter binaryFormatter;
    private FileStream fileStream;
    private DateTime previousLoginTime, currentLoginTime;

    [SerializeField] private Reward[] rewards;
    [SerializeField] private int MaxLoginStreak;
    [SerializeField] private int CurrentStreak;

    [SerializeField] private PlayerData playerData;

    void Awake(){
        singleton = this;
        binaryFormatter = new BinaryFormatter();
        rewards = new Reward[MaxLoginStreak];
    }

	// Use this for initialization
	void Start () {
        Chrono lastLoginChrono = LoadLastLoginTime();
        previousLoginTime = lastLoginChrono.ToDateTime();
        currentLoginTime = DateTime.Now;
        
        if (currentLoginTime.Subtract(previousLoginTime).Days > 1){
            DailyRewardPanel.singleton.Trigger();
            CurrentStreak = 0;
        }
        else if (currentLoginTime.Subtract(previousLoginTime).Days == 1){
            DailyRewardPanel.singleton.Trigger();
            CurrentStreak++;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ClaimReward(){
        Reward reward = rewards[CurrentStreak];
        playerData.TotalMoney += reward.getGoldGain();
        playerData.Exp += reward.getExpGain();
        playerData.Token += reward.getTokenGain();
    }

    public void SaveLastLoginTime(Chrono ch){
        fileStream = File.Create(Application.persistentDataPath + "/LoginData.data");
        binaryFormatter.Serialize(fileStream, ch);
        fileStream.Close();
    }

    public Chrono LoadLastLoginTime(){
        fileStream = File.Open(Application.persistentDataPath + "/LoginData.data", FileMode.Open);
        Chrono chrono = (Chrono) binaryFormatter.Deserialize(fileStream);
        fileStream.Close();
        return chrono;
    }
}
