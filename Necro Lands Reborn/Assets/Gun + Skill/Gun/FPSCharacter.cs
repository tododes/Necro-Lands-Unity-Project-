using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public enum Gender { MALE, FEMALE }

public class FPSCharacter : GameActor
{
    //[SerializeField]
    //public Gender gender;

    [SerializeField]
    protected PlayerData playerData;

    [SerializeField]
    protected int totalKill;

    [SerializeField]
    protected WeaponManager weaponManager;

    [SerializeField]
    protected PlayerInteraction MyInteraction;

    [SerializeField]
    protected DamageImage damageImage;

    [SerializeField]
    protected Gun gun;

    [SerializeField]
    private MissionFailedPanel failedPanel;

    private Vector3 playerDown, playerFall;
    private Rigidbody body;
    protected Modifier modifier;
    private BinaryFormatter bf;

    public DamageImage getDamageImage(){
        return damageImage;
    }

    public PlayerInteraction getPlayerInteraction(){
        return MyInteraction;
    }

    public WeaponManager getWeaponManager(){
        return weaponManager;
    }

    protected void Start () {
        bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + SaveKey.PLAYERDATA_KEY)){
            FileStream fs = File.Open(Application.persistentDataPath + SaveKey.PLAYERDATA_KEY, FileMode.Open);
            playerData = (PlayerData) bf.Deserialize(fs);
        }
        Name = playerData.Name;
        Bounty = 50;
        totalKill = 0;
        weaponManager = Cp_C<WeaponManager>();
        MyInteraction = Cp<PlayerInteraction>();
        gun = Cp_C<Gun>();
        playerDown = new Vector3(0, 0, 90);
        playerFall = Vector3.zero;
        body = Cp<Rigidbody>();
    }

    public int getTotalKill() { return totalKill; }
    public void killEnemy() { totalKill++; }

	protected void Update ()
    {
        if (!gun){
            gun = weaponManager.getGunAt(0);
        }
	}

    public void GainReward(Reward reward){
        playerData.TotalMoney += reward.getGoldGain();
        playerData.Exp += reward.getExpGain();
        playerData.Token += reward.getTokenGain();
    }

    private IEnumerator RegenerateHealth(float rate, float duration){
        float D = duration / Time.deltaTime;
        int intD = (int) D;
        for(int i = 0; i < intD; i++){
            HP += rate * Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public void RegenHealth(float rate, float duration){
        StartCoroutine(RegenerateHealth(rate, duration));
    }

    public override void getDamage(float amount){
        damageImage.Trigger(amount / MaxHP);
        base.getDamage(amount);
        if(HP <= 0f){
            HP = 0f;
            StartCoroutine(DeadMotion());
        }
    }

    private IEnumerator DeadMotion(){
        failedPanel.Trigger();
        gun.gameObject.SetActive(false);
        body.constraints = RigidbodyConstraints.FreezeRotationX;
        playerFall.x = transform.position.x;
        playerFall.z = transform.position.z;
        playerFall.y = 0f;
        transform.position = playerFall;
        while (transform.eulerAngles.z < 90f){
            transform.eulerAngles += playerDown * Time.deltaTime;
            transform.position -= Vector3.down * Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public void AddModifier(Modifier newMod){
        modifier = modifier + newMod;
    }
}
