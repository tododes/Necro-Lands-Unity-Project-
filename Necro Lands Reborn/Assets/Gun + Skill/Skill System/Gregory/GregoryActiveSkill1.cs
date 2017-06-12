using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GregoryActiveSkill1 : Skill {

    private float timer = 0f;
    [SerializeField] private float damage;

    [SerializeField]
    private FPSCharacterController controller;
    private Ray ray;
    private RaycastHit hit;
    private LayerMask enemyMask;

    public override void Use(){
        base.Use();
        if (!controller){
            controller = GetComponentInParent<FPSCharacterController>();
        }
        Debug.Log("Gregory active skill");
        StartCoroutine(Dash());
    }

    protected override void Start(){
        base.Start();
        ray = new Ray();
        enemyMask = LayerMask.GetMask("Enemy Layer");
    }

    protected override void Update(){
        base.Update();
        ray.origin = transform.position;
        ray.direction = transform.forward;
        
    }

    public float getDamage() { return damage; }

    private IEnumerator Dash(){
        controller.enabled = false;
        while (timer < 0.35f){
            owner.transform.Translate(Vector3.forward * 80f * Time.deltaTime);
            transform.position = owner.transform.position;
            if (Physics.Raycast(ray, out hit, 3f, enemyMask)){
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                Debug.Log("We hit an enemy");
                enemy.getDamage(damage);
            }
            yield return new WaitForSeconds(Time.deltaTime);
            timer += Time.deltaTime;
        }
        controller.enabled = true;
        timer = 0f;
    }
}
