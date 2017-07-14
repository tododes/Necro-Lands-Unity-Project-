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
    private bool NeverLogin;

    [SerializeField] private Reward[] rewards;
    [SerializeField] private int MaxLoginStreak;
    [SerializeField] private int CurrentStreak;

    [SerializeField] private PlayerData playerData;
    [SerializeField] private Chrono lastLoginChrono;
    [SerializeField] private DailyRewardPanel rewardPanel;

    void Awake(){
        singleton = this;
        binaryFormatter = new BinaryFormatter();
        rewards = new Reward[MaxLoginStreak];
        NeverLogin = false;
    }

	// Use this for initialization
	void Start () {
        if (File.Exists(Application.persistentDataPath + SaveKey.LOGINDATA_KEY))
        {
            lastLoginChrono = LoadLastLoginTime();
        }
        else
        {
            NeverLogin = true;
            lastLoginChrono = new Chrono(DateTime.Now);
        }

        previousLoginTime = lastLoginChrono.ToDateTime();
        currentLoginTime = DateTime.Now;

        Debug.Log(currentLoginTime.Subtract(previousLoginTime));

        if (!NeverLogin)
        {
            if (currentLoginTime.Subtract(previousLoginTime).Days > 1)
            {
                Debug.Log("trigger time extra day");
                DailyRewardPanel.singleton.Trigger();
                CurrentStreak = 0;
            }
            else if (currentLoginTime.Subtract(previousLoginTime).Days == 1)
            {
                Debug.Log("trigger time reset day");
                DailyRewardPanel.singleton.Trigger();
                CurrentStreak++;
            }
        }
        else
        {
            Debug.Log("trigger time first play");
            DailyRewardPanel.singleton.Trigger();
            CurrentStreak = 0;
        }

        SaveLastLoginTime(new Chrono(DateTime.Now));
    }

    // Update is called once per frame
    void Update () {
    }

    public void ClaimReward(){
        Reward reward = rewards[CurrentStreak];
        playerData.TotalMoney += reward.getGoldGain();
        playerData.Exp += reward.getExpGain();
        playerData.Token += reward.getTokenGain();
        fileStream = File.Create(Application.persistentDataPath + SaveKey.PLAYERDATA_KEY);
        binaryFormatter.Serialize(fileStream, playerData);
        fileStream.Close();
    }

    public void SaveLastLoginTime(Chrono ch){
        fileStream = File.Create(Application.persistentDataPath + SaveKey.LOGINDATA_KEY);
        binaryFormatter.Serialize(fileStream, ch);
        fileStream.Close();
    }

    public Chrono LoadLastLoginTime(){
        fileStream = File.Open(Application.persistentDataPath + SaveKey.LOGINDATA_KEY, FileMode.Open);
        Chrono chrono = (Chrono) binaryFormatter.Deserialize(fileStream);
        fileStream.Close();
        return chrono;
    }
}
