using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CanvasUI : MonoBehaviour
{
    public InputField playerNameField;

    public Text bestPlayerText;
    public Text bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bestPlayerText.text = "Best player : " + GameManager.instanceGameManager.bestPlayer;
        bestScoreText.text = "Best score : " + GameManager.instanceGameManager.bestScore;

        if (playerNameField.text != "")
            {
                GameManager.instanceGameManager.playerName = playerNameField.text;
            }
        
    }
        public void StartNewGame()
    {
        if (playerNameField.text != "")
        {
            GameManager.instanceGameManager.SaveInfo();

            SceneManager.LoadScene(1);
        }
        else 
        {
            Debug.LogWarning("Please enter your name");
        }
    }
        public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
