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
    GameManager gameManager;
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
            
            //show upgrade window
            GameObject.Find("UI").GetComponent<LoadInfo>().EnableUpgradeWindow();

            //stop all enemies for 5sec
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<Enemy>().WasStuned(5f);
            }

            tabKeyEnabled = false;
            controlKeysEnabled = false;
        }

        
    }


    public void SwitchScene()
    {
        //scene 0: MainMenu
        //scene 1-3 Rooms
        //scene 4: Boss
        //scene 5: endScreen
        if(currentScene == 4)
        {
            //switch to endscreen
            SceneManager.LoadScene(5);
        }
        else if (PlayerInfo.levelsGoneThrough == 6)
        {
            //switch to boss room
            SceneManager.LoadScene(4);
        }
        else
        {
            print("switch scene triggered");
            int nextScene = currentScene;

            while (nextScene == currentScene)
            {
                nextScene = Random.Range(1, numberOfScene - 2);
            }

            PlayerInfo.levelsGoneThrough += 1;
            SceneManager.LoadScene(nextScene);
        }
    }
}