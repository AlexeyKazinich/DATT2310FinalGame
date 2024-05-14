using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndScreen : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("RoundsWonText").GetComponent<Text>().text = "Levels Gone Through: " + PlayerInfo.levelsGoneThrough;
    }
    public void OnClick()
    {
        //reset playerinfo stuff and move to main menu
        PlayerInfo.ResetToDefault();
        SceneManager.LoadScene(0);
    }
}
