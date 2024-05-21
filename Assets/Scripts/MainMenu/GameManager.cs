using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject startButton;
    public GameObject gameOver;
    public Canvas showCredits;
    public Canvas showTeam;
    public GameObject hexaAstrum;
    public GameObject credits;
    public GameObject settings;
    public GameObject exitButton;
    public GameObject pause;
    public GameObject resume;
    public GameObject showPrompt;
    public Button yes;
    public Button no;
    //public Button showPrompt;
    private int score;
    public string[] enteredScenes;
    public int sceneIndex = 0;
    private void Awake(){
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        showCredits.gameObject.SetActive(false);
        showTeam.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Play(){
        Debug.Log("Play!");
        score = 0;
        //scoreText.text = score.ToString();

        SceneManager.LoadScene(1);
        //enteredScenes[0] = "Scene 1";
    }
    public void Exit(){
        Debug.Log("Exit button has been clicked!");
        Application.Quit();

        // for debugging purposes only, delete when building
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void Pause(){
        Time.timeScale = 0f;
        pause.SetActive(false);
    }
    public void Resume(){
        Time.timeScale = 1f;
        pause.SetActive(true);
    }
    public void ShowCredits(){
        showCredits.gameObject.SetActive(true);
        

    }
    public void HideCredits(){
        showCredits.gameObject.SetActive(false);
        
    }
    public void ShowCreators(){
        showTeam.gameObject.SetActive(true);
    }
    public void HideCreators(){
        showTeam.gameObject.SetActive(false);
    }
}
