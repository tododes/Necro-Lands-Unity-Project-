using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

    public static SettingsManager singleton;

    [SerializeField] private SettingsData settingsData;
    [SerializeField] private Slider musicSlider, SFXSlider;

    void Awake(){
        singleton = this;
        musicSlider.value = settingsData.MusicVolume;
        SFXSlider.value = settingsData.SFXVolume;
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
    }
}
