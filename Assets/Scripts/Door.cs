using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{   
    private int numberOfScene;
    private int currentScene;

    // for tab key
    public bool tabKeyEnabled = true;
    public bool controlKeysEnabled = true;
    // Start is called before the first frame update

    void Awake()
    {
        
    }

    void Start()
    {  
        // MainMenu is scene 0
        numberOfScene = SceneManager.sceneCountInBuildSettings; // Total number of scene in the build
        currentScene =  SceneManager.GetActiveScene().buildIndex; // Index of the current scene
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Switch to a scene when collide with player
    void OnTriggerEnter2D(Collider2D player)
    {
        
        //hit door display upgrade UI
        if (player.gameObject.CompareTag("Player"))
        {
            print("Hit door trigger");
            GameObject.Find("UI").GetComponent<LoadInfo>().EnableUpgradeWindow();
            tabKeyEnabled = false;
            controlKeysEnabled = false;
        }

        
    }


    public void SwitchScene()
    {
        
        print("switch scene triggered");
        int nextScene = currentScene;
        while (nextScene == currentScene)
        {
            nextScene = Random.Range(1, numberOfScene);
        }
        SceneManager.LoadScene(nextScene);
        
        
    }
}