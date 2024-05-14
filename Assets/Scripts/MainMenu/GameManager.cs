using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject startButton;
    public GameObject gameOver;
    public GameObject showCreators;
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
        /*
        yes = GameObject.Find("Yes").GetComponent<Button>();
        yes.onClick.AddListener(Yes);

        no = GameObject.Find("No").GetComponent<Button>();
        no.onClick.AddListener(No);


        showPrompt.SetActive(false);
        */
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
        settings.SetActive(false);
        exitButton.SetActive(false);
        
        
        
        Application.Quit();
    }
    public void Yes(){
        Application.Quit();
    }
    public void No(){
        settings.SetActive(true);
        exitButton.SetActive(true);

    }
    public void Pause(){
        Time.timeScale = 0f;
        player.enabled = false;

        resume.SetActive(true);
        exitButton.SetActive(true);
        settings.SetActive(true);
        credits.SetActive(true);
        showCreators.SetActive(true);
        pause.SetActive(false);
    }
    public void Resume(){
        Time.timeScale = 1f;
        player.enabled = true;
        resume.SetActive(false);
        exitButton.SetActive(false);
        settings.SetActive(false);
        credits.SetActive(false);
        showCreators.SetActive(false);
        pause.SetActive(true);
    }
    public void ShowCredits(){

    }
    public void ShowCreators(){

    }
}
