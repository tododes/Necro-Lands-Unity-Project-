using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public FPSCharacter owner { private get; set; }

    [SerializeField]
    private SHOOTTYPE STYPE;
    private enum SHOOTTYPE
    {
        SINGLE, ASSAULT, BURSTFIRE, FLAMETHROWER
    }
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform gunEnd;

    [SerializeField]
    private float intervalBetweenBullets;
    private float currInterval;
    private int BurstFireCount;
    private float BurstFireWaitInterval;


    [SerializeField]
    private int TotalAmmo, StockAmmo, CurrentStockAmmo;

	protected void Start ()
    {
        BurstFireCount = 0;
        currInterval = 0f;
        BurstFireWaitInterval = 0f;
        owner = transform.parent.GetComponent<FPSCharacter>();
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

    public void Shoot()
    {
        GameObject g = Instantiate(bullet, gunEnd.position, gunEnd.rotation) as GameObject;
        g.GetComponent<Bullet>().SetOwner(owner);
        CurrentStockAmmo--;
    }
}
