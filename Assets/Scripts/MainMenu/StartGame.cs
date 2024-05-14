using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void GoToGame()
    {
        //for now it goes to the first scene
        SceneManager.LoadScene("Scene 1");
    }

}
