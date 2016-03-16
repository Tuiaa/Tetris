using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/*
 *  Saves data into a file and reads from it
 */
public class DataSaver : MonoBehaviour
{
    [Serializable]
    class PlayerData
    {
        public int bestScore;
    }

    void Awake()
    {
        Load();
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        Debug.Log("Path for saved file: " + Application.persistentDataPath);

        PlayerData data = new PlayerData();
        data.bestScore = gameObject.GetComponent<ScoreManager>().score;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            gameObject.GetComponent<ScoreManager>().bestScore = data.bestScore;
        }
        else
        {
            Debug.Log("Load file does not exist");
        }
    }
}