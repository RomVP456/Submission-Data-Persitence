using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;


public class DataManager : MonoBehaviour
{
    public class BestPlayer{
        public string playerName;
        public int score = 0;
    }
    // Start is called before the first frame update
    public static DataManager DataInstance;
    public string playerName = "No player";
    public BestPlayer bestPlayer = new BestPlayer();
    
    [SerializeField] TMP_InputField nameField;
    void Start()
    {
        if (DataInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        DataInstance = this;
        DontDestroyOnLoad(gameObject);

    }
    public void setPlayerName(){
        playerName = nameField.text;
        print(playerName);
    }

    // Update is called once per frame
    public void ChangeBestPlayer(string newBestPlyr,int newBestScore){
        bestPlayer.playerName = newBestPlyr;
        bestPlayer.score = newBestScore;
    }
    public void ChangeLevel(){
        SceneManager.LoadScene(1);
    }
    public void SaveBest()
    {
        BestPlayer data = bestPlayer;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadBest()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestPlayer data = JsonUtility.FromJson<BestPlayer>(json);

            bestPlayer = data;
            print($"aquired best data {data}");
        }
    }
}
