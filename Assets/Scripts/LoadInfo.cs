using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadInfo : MonoBehaviour
{
    [SerializeField] Text level;

    private FloatingHealthBar healthBar;
    private FloatingHealthBar xpBar;
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

        //delete this after, its for testing
        PlayerInfo.level += 1;


        healthBar = GameObject.Find("PlayerHealthBar").GetComponent<FloatingHealthBar>();
        xpBar = GameObject.Find("PlayerXPBar").GetComponent<FloatingHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        //update the healthbar and the XP bar
        healthBar.UpdateHealthBar(PlayerInfo.CurrentHealth, PlayerInfo.MaxHealth);
        xpBar.UpdateHealthBar(PlayerInfo.CurrentXP, PlayerInfo.MaxXP);
    }
}
