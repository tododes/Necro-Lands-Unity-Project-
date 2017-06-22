using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingRune : Interactable {

    [SerializeField] private float rate;
    [SerializeField] private float duration;
    private Vector3 originalPos;
    private Vector3 UpsideDownRate;
    private float Timer;

    void Start(){
        originalPos = transform.position;
        UpsideDownRate = Vector3.zero;
        Timer = 0f;
    }

    public override void OnStartReact(FPSCharacter character){
        base.OnStartReact(character);

    }

    public override void Interact(FPSCharacter character){
        base.Interact(character);
        if (Input.GetKeyDown(KeyCode.E)){
            character.RegenHealth(rate, duration);
            gameObject.SetActive(false);
        }
    }

    public override void OnStopReact(FPSCharacter character){
        base.OnStopReact(character);
    }

    void Update(){
        transform.Rotate(0, 360f * Time.deltaTime, 0);
        Timer += Time.deltaTime * 2f;
        if (Timer > Mathf.PI * 2)
            Timer = 0f;
        UpsideDownRate.y = Mathf.Sin(Timer);
        transform.position = originalPos + UpsideDownRate / 3f;
    }
}
