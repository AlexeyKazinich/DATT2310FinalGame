using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{   
    private int numberOfScene;
    private int currentScene;
    // Start is called before the first frame update

    void Awake()
    {
        
    }

    void Start()
    {  
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
        if (player.gameObject.CompareTag("Player"))
        {
            int nextScene = currentScene;
            while (nextScene == currentScene)
            {
                nextScene = Random.Range(0, numberOfScene);
            }
            SceneManager.LoadScene(nextScene);
        }
    }
}