using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SoundType { BUTTON, MUSIC, SFX }

public class AudioManager : MonoBehaviour {

    public static AudioManager singleton;
    private Button[] buttons;
    //[SerializeField] private AudioClip buttonPressClip;
    //[SerializeField] private AudioClip MusicClip;

    [SerializeField] private AudioClip[] clips;

    private AudioSource source;

    void Awake(){
        singleton = this;
    }
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        buttons = FindObjectsOfType<Button>();
        PlayMusic();
        foreach(Button b in buttons){
            b.onClick.AddListener(PlaySoundOnPressButton);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySoundOnPressButton() {
        source.clip = clips[(int)SoundType.BUTTON];
        source.Play();
    }

    public void PlayMusic() {
        source.clip = clips[(int)SoundType.MUSIC];
        source.Play();
    }
}
