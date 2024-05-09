using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadInfo : MonoBehaviour
{
    [SerializeField] Text levelText;

    private FloatingHealthBar healthBar;
    private FloatingHealthBar xpBar;

    [SerializeField] Image ability1;
    [SerializeField] Image ability2;
    [SerializeField] Image ability3;


    [SerializeField] Image Upgrade1Image;
    [SerializeField] Button Upgrade1Button;

    [SerializeField] GameObject UpgradeWindow;

    // Start is called before the first frame update
    void Start()
    {
        //disable the upgrade window
        

        try
        {
            levelText.text = "Level: " + PlayerInfo.level;
        }
        catch
        {
            levelText.text = "Unable to set";
        }

        //get UI components
        healthBar = GameObject.Find("PlayerHealthBar").GetComponent<FloatingHealthBar>();
        xpBar = GameObject.Find("PlayerXPBar").GetComponent<FloatingHealthBar>();

        //check if player has any abiltites
        //ability 1
        if(PlayerInfo.Ability1 != null)
        {
            //Draw the ability the player has
            ability1.GetComponent<Image>().enabled = true;

        }
        else
        {
            ability1.GetComponent<Image>().enabled = false;
        }

        //ability 2
        if (PlayerInfo.Ability2 != null)
        {
            //Draw the ability the player has
            ability2.GetComponent<Image>().enabled = true;

        }
        else
        {
            ability2.GetComponent<Image>().enabled = false;
        }

        //ability 3
        if (PlayerInfo.Ability3 != null)
        {
            //Draw the ability the player has
            ability3.GetComponent<Image>().enabled = true;

        }
        else
        {
            ability3.GetComponent<Image>().enabled = false;
        }


        UpgradeWindow.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //update the healthbar and the XP bar, prob better to call this somewhere else
        healthBar.UpdateHealthBar(PlayerInfo.CurrentHealth, PlayerInfo.MaxHealth);
        xpBar.UpdateHealthBar(PlayerInfo.CurrentXP, PlayerInfo.MaxXP);
        levelText.text = "Level: " + PlayerInfo.level;
    }


    public void SelectedOption(string type)
    {
        print("Button clicked");
        
        if(PlayerInfo.Ability1 == null)
            PlayerInfo.Ability1 = type;
        else if(PlayerInfo.Ability2 == null)
            PlayerInfo.Ability2 = type;
        else if(PlayerInfo.Ability3 == null)
            PlayerInfo.Ability3 = type;

        GameObject.Find("Door").GetComponent<Door>().SwitchScene();


    }


    public void EnableUpgradeWindow()
    {
        /*
        Upgrade1Image.enabled = true;
        Upgrade1Button.enabled = true;
        Upgrade1Button.image.enabled = true;

        */

        /*

        Upgrade1Button.gameObject.SetActive(true);
        Upgrade1Button.interactable = false;
        Upgrade1Button.interactable = true;
        Upgrade1Button.gameObject.GetComponent<Image>().raycastTarget = true;

        */

        UpgradeWindow.SetActive(true);
    }

    public void OnButtonClick(string type)
    {
        print("BUtton clicked");
        
        AddAbility(type);
        //find door script and change rooms
        GameObject.Find("Door").GetComponent<Door>().SwitchScene();

    }


    private void AddAbility(string type)
    {
        if(PlayerInfo.Ability1 == null)
        {
            PlayerInfo.Ability1 = type;
        }
        else if (PlayerInfo.Ability2 == null)
        {
            PlayerInfo.Ability2 = type;
        }
        else if (PlayerInfo.Ability3 == null)
        {
            PlayerInfo.Ability3 = type;
        }
    }



}
