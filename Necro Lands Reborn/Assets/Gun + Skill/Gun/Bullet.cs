using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    [SerializeField] private int damage;
    public float speed;
    //private Rigidbody rigidBody;
    private Vector3 startPos;
    public FPSCharacter owner { get; protected set; }

    [SerializeField]
    private float Range;

    public int GetDamage()
    {
        return damage;
    }
	// Use this for initialization
	void Start ()
    {
        //rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //rigidBody.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        gameObject.SetActive(Vector3.Distance(transform.position, startPos) < Range);
    }

    public void SetOwner(FPSCharacter character){
        owner = character;
    }
}
