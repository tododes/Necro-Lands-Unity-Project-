using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakSkill2 : Skill {

    [SerializeField]
    private GameObject magicBurst, magicBurstPrefab;
    [SerializeField]
    private Transform magicBurstPoint;
    private WaitForSeconds zeroPointEight = new WaitForSeconds(0.8f);
    private WaitForSeconds zeroPointTwo = new WaitForSeconds(0.2f);

    public override void InitializeSkill(){
        magicBurst = Instantiate(magicBurstPrefab, magicBurstPoint.position, magicBurstPoint.rotation);
        magicBurst.SetActive(false);
        Use();
    }

    public override void Use(){
        base.Use();
        StartCoroutine(CreateMagicBurst());
    }

    private IEnumerator CreateMagicBurst(){
        yield return zeroPointEight;
        magicBurst.SetActive(true);
        yield return zeroPointTwo;
        magicBurst.SetActive(false);
    }
}
