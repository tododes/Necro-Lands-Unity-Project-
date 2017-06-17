using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerSelectionContainer : TodoBehaviour {

    [SerializeField] private int index;
    [SerializeField] private PlayerAttribute[] attributes;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private InventoryData id;

    private BinaryFormatter bf;
    private FileStream fs;

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
        bf = new BinaryFormatter();
    }

    void Update(){
        desiredPosition.x = 20f * index;
        if (pos.x < desiredPosition.x)
            t_a(Vector3.right, 25f);
        if (pos.x > desiredPosition.x)
            t_a(Vector3.left, 25f);
    }

    public void SavePlayerName(){
        playerData.Name = attributes[index * -1].getPlayerName();
        playerData.Level = 1;
        playerData.TotalMoney = 100;
        Save<PlayerData>("/PlayerData.data", playerData);
        Save<InventoryData>("/InventoryData.data", id);
    }

    public void Save<T>(string path, T obj)
    {
        fs = File.Create(Application.persistentDataPath + path);
        bf.Serialize(fs, obj);
        fs.Close();
    }
}
