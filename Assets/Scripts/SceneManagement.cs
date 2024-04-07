using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    // public string playerName;
    [SerializeField] TMP_InputField nameField;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void ChangeLevel(){
        SceneManager.LoadScene(1);
    }
    public void setPlayerName(){
        string playerName = nameField.text;
        // print(playerName);
        DataManager.DataInstance.playerName = playerName;
    }
}
