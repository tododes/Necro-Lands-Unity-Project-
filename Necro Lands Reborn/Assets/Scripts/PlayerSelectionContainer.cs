using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionContainer : TodoBehaviour {

    [SerializeField] private int index;
    [SerializeField] private PlayerAttribute[] attributes;
    [SerializeField] private PlayerData playerData;

	public void inc() {
        index--;
        if (index < -3) index = -3;
    }
    public void dec() {
        index++;
        if (index > 0) index = 0;
    }

    private Vector3 desiredPosition;

    void Start()
    {
        desiredPosition = new Vector3(0, transform.position.y, transform.position.z);
    }

    void Update(){
        desiredPosition.x = 20f * index;
        if (pos.x < desiredPosition.x)
            t_a(Vector3.right, 25f);
        if (pos.x > desiredPosition.x)
            t_a(Vector3.left, 25f);
    }

    public void SetPlayerName(){
        playerData.Name = attributes[index * -1].getPlayerName();
    }
}
