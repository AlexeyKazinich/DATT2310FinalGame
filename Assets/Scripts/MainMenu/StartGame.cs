using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void GoToGame()
    {
        //for now it goes to the first scene
        initPlayerInfo();
        SceneManager.LoadScene("Scene 1");
    }


    //initialize player info
    private void initPlayerInfo()
    {
        //health
        PlayerInfo.MaxHealth = 100;
        PlayerInfo.CurrentHealth = PlayerInfo.MaxHealth;

        //experience
        PlayerInfo.CurrentXP = 0;
        PlayerInfo.MaxXP = 100;
        PlayerInfo.level = 1;

    }
}
