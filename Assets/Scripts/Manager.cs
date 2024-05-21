using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject pause;
    public GameObject resume;
    public Canvas pauseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        pause.SetActive(true);
        resume.SetActive(false);
        pauseCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause(){
        Debug.Log("Pause button is pressed!");
        Time.timeScale = 0f;
        pause.SetActive(false);
        resume.SetActive(true);

        // show the canvas
        pauseCanvas.gameObject.SetActive(true);
    }
    public void Resume(){
        Debug.Log("Resume button is pressed!");
        Time.timeScale = 1f;
        pause.SetActive(true);
        resume.SetActive(false);
        // show the canvas
        pauseCanvas.gameObject.SetActive(false);

    }
    public void GoToMainMenu(){
        
    }
}
