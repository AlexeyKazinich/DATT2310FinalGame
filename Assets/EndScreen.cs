using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndScreen : MonoBehaviour
{

    private void Start()
    {
        if (PlayerInfo.victory)
        {
            GameObject.Find("WinUI").SetActive(true);
            GameObject.Find("LoseUI").SetActive(false);
        }
        else
        {
            GameObject.Find("WinUI").SetActive(false);
            GameObject.Find("LoseUI").SetActive(true);
        }
    }
    


    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(1);
    }
}
