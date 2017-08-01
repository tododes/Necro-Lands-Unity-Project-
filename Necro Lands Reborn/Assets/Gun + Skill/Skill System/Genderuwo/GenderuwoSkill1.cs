using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderuwoSkill1 : Skill {

    private Vector3 originPosition, slamPosition;
    private Vector3 altittudeVector;
    [SerializeField] private GameObject genderuwoClapPrefab;

    public override void InitializeSkill(){
        owner = GetComponentInParent<GameActor>();
        originPosition = transform.position;
        altittudeVector = Vector3.zero;
    }

    public override void Use(){
        base.Use();
        StartCoroutine(JumpClap());
    }

    private IEnumerator JumpClap(){
        float h = 0f;
        while(h < 3.14f){
            h += 6.28f * Time.deltaTime;
            altittudeVector.y = Mathf.Sin(h) * 4f;
            owner.transform.position = altittudeVector;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        slamPosition = transform.position;
        slamPosition.y = -0.75f;
        GameObject genderuwoSlam = Instantiate(genderuwoClapPrefab, slamPosition, Quaternion.identity);
        genderuwoSlam.transform.parent = owner.transform;
        yield return new WaitForSeconds(0.2f);
        genderuwoSlam.SetActive(false);
    }
}
