using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadInfo : MonoBehaviour
{
    [SerializeField] Text level;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            level.text = "Level: " + PlayerInfo.level;
        }
        catch
        {
            level.text = "Unable to set";
        }
        PlayerInfo.level += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
