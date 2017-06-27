using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class Game<T> where T : Mission
{
    private T objective;
    private BinaryFormatter binaryFormatter;
    private FileStream fileStream;

    public Game(string filename){
        binaryFormatter = new BinaryFormatter();
        fileStream = File.Open(Application.persistentDataPath + filename, FileMode.Open);
        objective = (T) binaryFormatter.Deserialize(fileStream);
        fileStream.Close();
    }

    public T getObjective() { return objective; }
}
