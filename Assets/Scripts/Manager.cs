using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject pause;
    public GameObject resume;
    public GameObject mainMenu;
    public GameObject background;
    public GameObject pauseText;
    public Canvas pauseCanvas;
    private bool isPaused = true;
    // Start is called before the first frame update
    void Start()
    {
        pause.SetActive(true);
        resume.SetActive(false);
        pauseCanvas.gameObject.SetActive(false);
        background.SetActive(false);
        mainMenu.SetActive(false);
        pauseText.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPaused == false){
            if(Input.GetKeyDown(KeyCode.Escape)){
                Pause();
                isPaused = true;
            }
        }
        else if(isPaused == true){
            if(Input.GetKeyDown(KeyCode.Escape)){
                Resume();
                isPaused = false;
            }
        }
        
    }
    public void Pause(){
        Debug.Log("Pause button is pressed!");
        Time.timeScale = 0f;
        pause.SetActive(false);
        resume.SetActive(true);
        background.SetActive(true);
        mainMenu.SetActive(true);
        pauseText.SetActive(true);
        // show the canvas
        pauseCanvas.gameObject.SetActive(true);
    }
    public void Resume(){
        Debug.Log("Resume button is pressed!");
        Time.timeScale = 1f;
        pause.SetActive(true);
        resume.SetActive(false);
        mainMenu.SetActive(false);
        background.SetActive(false);
        pauseText.SetActive(false);
        // hide the canvas
        pauseCanvas.gameObject.SetActive(false);

    }
    public void GoToMainMenu(){
        Time.timeScale = 1f; //reset this or its bugged
        SceneManager.LoadScene(0);
    }
}
