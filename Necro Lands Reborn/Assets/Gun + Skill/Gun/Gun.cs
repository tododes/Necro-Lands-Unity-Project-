using UnityEngine;
using System.Collections;

public class Gun : TodoBehaviour {

    public FPSCharacter owner { protected get; set; }

    [SerializeField]
    protected SHOOTTYPE STYPE;
    protected enum SHOOTTYPE
    {
        SINGLE, ASSAULT, BURSTFIRE, FLAMETHROWER
    }
    [SerializeField]
    protected GameObject bullet;

    [SerializeField]
    protected Transform gunEnd;

    [SerializeField]
    protected float intervalBetweenBullets;
    protected float currInterval;
    protected int BurstFireCount;
    protected float BurstFireWaitInterval;

    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    protected int TotalAmmo, StockAmmo, CurrentStockAmmo;

    private Animation anim;
    public Sprite getSprite(){
        return sprite;
    }

	protected void Start (){
        BurstFireCount = 0;
        currInterval = 0f;
        BurstFireWaitInterval = 0f;
        owner = transform.parent.parent.GetComponent<FPSCharacter>();
        anim = Cp<Animation>();
	}

    protected void Update ()
    {
        if(TotalAmmo > 0 || CurrentStockAmmo > 0)
        {
            if (STYPE == SHOOTTYPE.ASSAULT)
            {
                if (Input.GetMouseButton(0))
                {
                    if (currInterval == 0f)
                        Shoot();
                    currInterval += Time.deltaTime;
                    if (currInterval >= intervalBetweenBullets)
                        currInterval = 0f;
                }
            }
            else if (STYPE == SHOOTTYPE.SINGLE)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Shoot();
                }
            }
            else if (STYPE == SHOOTTYPE.BURSTFIRE)
            {

                if (Input.GetMouseButton(0))
                {
                    
                    if (currInterval == 0f)
                    {
                        if (BurstFireCount < 3)
                        {
                            Shoot();
                            BurstFireCount++;
                        }
                        else
                        {
                            Debug.Log(BurstFireWaitInterval);
                            BurstFireWaitInterval += Time.deltaTime;
                            if (BurstFireWaitInterval >= intervalBetweenBullets * 1.2f)
                            {
                                BurstFireWaitInterval = 0f;
                                BurstFireCount = 0;
                            }
                        }
                    }
                    currInterval += Time.deltaTime;
                    if (currInterval >= intervalBetweenBullets)
                        currInterval = 0f;
                }

            }
            
            if (CurrentStockAmmo <= 0)
            {
                CurrentStockAmmo += StockAmmo;
                TotalAmmo -= StockAmmo;
            }
        }
    }

    public void SetBulletToBeInstantiated(GameObject b){
        bullet = b;
    }

    public virtual void Shoot()
    {
        if (anim.isPlaying)
            anim.Stop();
        anim.Play();
        GameObject g = Instantiate(bullet, gunEnd.position, gunEnd.rotation) as GameObject;
        g.GetComponent<Bullet>().SetOwner(owner);
        CurrentStockAmmo--;
    }
}
