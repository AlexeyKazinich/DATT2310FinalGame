using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndScreen : MonoBehaviour
{

    private void Start()
    {
        MusicManager.Instance.StopAndDestroy();

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
        PlayerInfo.ResetToDefault();
        SceneManager.LoadScene(0);
    }

    public void OnClickRestart()
    {
        PlayerInfo.ResetToDefault();
        SceneManager.LoadScene(1);
    }
}
