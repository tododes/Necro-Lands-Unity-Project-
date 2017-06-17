using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SettingsManager : MonoBehaviour {

    public static SettingsManager singleton;

    [SerializeField] private SettingsData settingsData;
    [SerializeField] private Slider musicSlider, SFXSlider;

    private BinaryFormatter bf;
    private FileStream fs;

    void Awake(){
        singleton = this;
        bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/SettingsData.data")){
            settingsData = LoadPreviousSettings("/SettingsData.data");
            musicSlider.value = settingsData.MusicVolume;
            SFXSlider.value = settingsData.SFXVolume;
        }
        else{
            musicSlider.value = 1f;
            SFXSlider.value = 1f;
        }
        
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveChanges(){
        settingsData.MusicVolume = musicSlider.value;
        settingsData.SFXVolume = SFXSlider.value;
        fs = File.Create(Application.persistentDataPath + "/SettingsData.data");
        bf.Serialize(fs, settingsData);
        fs.Close();
    }

    public SettingsData LoadPreviousSettings(string path)
    {
        fs = File.Open(Application.persistentDataPath + path, FileMode.Open);
        SettingsData obj = (SettingsData)bf.Deserialize(fs);
        fs.Close();
        return obj;
    }
}
