using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class GameManager : MonoBehaviour
{
    public static GameManager instanceGameManager;

    public string playerName = "";
    public string previousPlayerName = "";
    public string bestPlayer;
    public int bestScore = 0;


    // Start is called before the first frame update

    private void Awake()
    {
        if (instanceGameManager != null)
        {
        Destroy(gameObject);
            return;
        }
        instanceGameManager = this;
        DontDestroyOnLoad(gameObject);

        Debug.Log("Awake");

        LoadInfo();
    }

    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BestScore(int score)
    {
        if (score > bestScore)
        {
            bestScore = score;
            bestPlayer = playerName;
            SaveInfo();
        } 
        Debug.Log("Best score : " + bestScore);
    }


    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
        public string bestPlayer;
    }

    public void SaveInfo()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.bestScore = bestScore;
        data.bestPlayer = bestPlayer;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("SAVE. Current player : " + playerName + "; best score : " + bestScore + "; best player : " + bestPlayer + ".");
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
        string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            bestScore = data.bestScore;
            bestPlayer = data.bestPlayer;
        }
        Debug.Log("LOAD. Current player : " + playerName + "; best score : " + bestScore + "; best player : " + bestPlayer + ".");
    }

}
