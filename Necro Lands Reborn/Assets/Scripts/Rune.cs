using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : Interactable {

    [SerializeField]
    protected int DurationOfEffect;

    protected Vector3 originalPos;
    protected Vector3 UpsideDownRate;
    protected float Timer;

    protected virtual void Start()
    {
        originalPos = transform.position;
        UpsideDownRate = Vector3.zero;
        Timer = 0f;
    }

    public override void OnStartReact(FPSCharacter character)
    {
        base.OnStartReact(character);

    }

    public override void Interact(FPSCharacter character)
    {
        base.Interact(character);
        RuneInteraction(character);
    }

    public override void OnStopReact(FPSCharacter character)
    {
        base.OnStopReact(character);
    }

    protected virtual void Update()
    {
        transform.Rotate(0, 360f * Time.deltaTime, 0);
        Timer += Time.deltaTime * 2f;
        if (Timer > Mathf.PI * 2)
            Timer = 0f;
        UpsideDownRate.y = Mathf.Sin(Timer);
        transform.position = originalPos + UpsideDownRate / 3f;
    }

    public virtual void RuneInteraction(FPSCharacter character){
        gameObject.SetActive(false);
    }
}
