using UnityEngine;
using System.Collections;

public class AreYouSurePanel : MonoBehaviour {

    public static AreYouSurePanel singleton;

    protected RectTransform rect;

    [SerializeField] protected int Index;

    protected Vector3 IncrementFactor;
    [SerializeField] protected float desiredSize;

    protected Vector3 zeroVector;

    protected void Awake (){
        singleton = this;
	}

    protected void Start(){
        rect = GetComponent<RectTransform>();
        IncrementFactor = Vector3.one * 2 * desiredSize;
        zeroVector = new Vector3(0, 0, 1);
    }

    //public void SetIndex(int i)
    //{
    //    Index = i;
    //}

    protected virtual void Update ()
    {
        if (Index == 0 && rect.localScale.x > 0){
            rect.localScale = rect.localScale - IncrementFactor * Time.deltaTime;

        }
        else if (Index == 0 && rect.localScale.x <= 0){
            rect.localScale = zeroVector;
        }

        if (Index == 1 && rect.localScale.x < desiredSize){
            rect.localScale = rect.localScale + IncrementFactor * Time.deltaTime;
        }
    }

    public void No()
    {
        Index = 0;
    }

    public virtual void Yes(string name)
    {
        if (name == "Quit")
            Application.Quit();
        else
            Application.LoadLevel(name);
    }

    public virtual void Trigger(){
        Index = 1;
    }
}
