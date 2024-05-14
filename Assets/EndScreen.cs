using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScreen : MonoBehaviour
{
    public void OnClick()
    {
        //reset playerinfo stuff and move to main menu
        PlayerInfo.ResetToDefault();
        SceneManager.LoadScene(0);
    }
}
