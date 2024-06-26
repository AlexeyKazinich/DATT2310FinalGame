using System.Collections;
using System;
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


    private Color cdColor = new Color(0.1f, 0.1f, 0.1f, 1);


    //Abilities
    public List<Ability> abilities = new() { };


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
            ability1.sprite = PlayerInfo.ability1.AbilityIcon;

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
            ability2.sprite = PlayerInfo.ability2.AbilityIcon;

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
            ability3.sprite = PlayerInfo.ability3.AbilityIcon;

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


        if(PlayerInfo.ability1 != null)
        {
            PlayerInfo.ability1.CooldownUpdate(Time.deltaTime);
        }
        if (PlayerInfo.ability2 != null)
        {
            PlayerInfo.ability2.CooldownUpdate(Time.deltaTime);
        }
        if (PlayerInfo.ability3 != null)
        {
            PlayerInfo.ability3.CooldownUpdate(Time.deltaTime);
        }

        

        //grey out the ability if cant use
        if (PlayerInfo.ability1 != null && !PlayerInfo.ability1.IsReady())
        {
            GameObject.Find("Ability1").GetComponent<Image>().color = cdColor;
        }
        else
        {
            GameObject.Find("Ability1").GetComponent<Image>().color = Color.white;
        }

        if(PlayerInfo.ability2 != null && !PlayerInfo.ability2.IsReady())
        {
            GameObject.Find("Ability2").GetComponent<Image>().color= cdColor;
        }
        else
        {
            GameObject.Find("Ability2").GetComponent<Image>().color = Color.white;
        }

        if (PlayerInfo.ability3 != null && !PlayerInfo.ability3.IsReady())
        {
            GameObject.Find("Ability3").GetComponent<Image>().color = cdColor;
        }
        else
        {
            GameObject.Find("Ability3").GetComponent<Image>().color = Color.white;
        }
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
        //if player has 3 abilities dont show upgrade screen
        if (PlayerInfo.ability1 != null && PlayerInfo.ability2 != null && PlayerInfo.ability3 != null)
            GameObject.Find("Door").GetComponent<Door>().SwitchScene();
        else
        {
            UpgradeWindow.SetActive(true);


            //displays random abilities that the player does not have

            //window 1
            GameObject.Find("Upgrade1Window").GetComponent<UpgradeWindow>().SetAbility(abilities[GetRandomAbilityIndex()]); //get random ability
            GameObject.Find("Upgrade1Image").GetComponent<Image>().sprite = GameObject.Find("Upgrade1Window").GetComponent<UpgradeWindow>().GetAbility().AbilityIcon; //get ability icon
            GameObject.Find("SpellName1").GetComponent<Text>().text = GameObject.Find("Upgrade1Window").GetComponent<UpgradeWindow>().GetAbility().AbilityName; //get ability name
            GameObject.Find("SpellDescription1").GetComponent<Text>().text = GameObject.Find("Upgrade1Window").GetComponent<UpgradeWindow>().GetAbility().AbilityDescription; //get ability desc

            //window 2
            GameObject.Find("Upgrade2Window").GetComponent<UpgradeWindow>().SetAbility(abilities[GetRandomAbilityIndex()]);
            GameObject.Find("Upgrade2Image").GetComponent<Image>().sprite = GameObject.Find("Upgrade2Window").GetComponent<UpgradeWindow>().GetAbility().AbilityIcon;
            GameObject.Find("SpellName2").GetComponent<Text>().text = GameObject.Find("Upgrade2Window").GetComponent<UpgradeWindow>().GetAbility().AbilityName; //get ability name
            GameObject.Find("SpellDescription2").GetComponent<Text>().text = GameObject.Find("Upgrade2Window").GetComponent<UpgradeWindow>().GetAbility().AbilityDescription; //get ability desc

            //window 3
            GameObject.Find("Upgrade3Window").GetComponent<UpgradeWindow>().SetAbility(abilities[GetRandomAbilityIndex()]);
            GameObject.Find("Upgrade3Image").GetComponent<Image>().sprite = GameObject.Find("Upgrade3Window").GetComponent<UpgradeWindow>().GetAbility().AbilityIcon;
            GameObject.Find("SpellName3").GetComponent<Text>().text = GameObject.Find("Upgrade3Window").GetComponent<UpgradeWindow>().GetAbility().AbilityName; //get ability name
            GameObject.Find("SpellDescription3").GetComponent<Text>().text = GameObject.Find("Upgrade3Window").GetComponent<UpgradeWindow>().GetAbility().AbilityDescription; //get ability desc
        }
    }

    private int GetRandomAbilityIndex()
    {
        //gets a random ability that the player does not have
        System.Random rnd = new System.Random();
        bool looping = true;
        int choice = 0;
        while (looping)
        {
            choice = rnd.Next(0, abilities.Count);

            if (abilities[choice] != PlayerInfo.ability1 &&
                abilities[choice] != PlayerInfo.ability2 &&
                abilities[choice] != PlayerInfo.ability3)
            {
                looping = false;
            }
        }

        return choice;
    }

    public void OnButtonClick(int type)
    {
        switch (type)
        {
            case 1:
            case 2:
            case 3:
                AddAbility(type);
                break;
            case 4:
                print("skip button pressed");
                break;
        }



        GameObject.Find("Door").GetComponent<Door>().SwitchScene();
    }


    private void AddAbility(int type)
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();

        

        switch (type) {
            case 1:
                if (PlayerInfo.Ability1 == null)
                {
                    PlayerInfo.Ability1 = type.ToString();
                    player.AssignAbility(0, GameObject.Find("Upgrade1Window").GetComponent<UpgradeWindow>().GetAbility());
                }
                else if (PlayerInfo.Ability2 == null)
                {
                    PlayerInfo.Ability2 = type.ToString();
                    player.AssignAbility(1, GameObject.Find("Upgrade1Window").GetComponent<UpgradeWindow>().GetAbility());
                }
                else if (PlayerInfo.Ability3 == null)
                {
                    PlayerInfo.Ability3 = type.ToString();
                    player.AssignAbility(2, GameObject.Find("Upgrade1Window").GetComponent<UpgradeWindow>().GetAbility());
                }
                break;

            case 2:
                if (PlayerInfo.Ability1 == null)
                {
                    PlayerInfo.Ability1 = type.ToString();
                    player.AssignAbility(0, GameObject.Find("Upgrade2Window").GetComponent<UpgradeWindow>().GetAbility());
                }
                else if (PlayerInfo.Ability2 == null)
                {
                    PlayerInfo.Ability2 = type.ToString();
                    player.AssignAbility(1, GameObject.Find("Upgrade2Window").GetComponent<UpgradeWindow>().GetAbility());
                }
                else if (PlayerInfo.Ability3 == null)
                {
                    PlayerInfo.Ability3 = type.ToString();
                    player.AssignAbility(2, GameObject.Find("Upgrade2Window").GetComponent<UpgradeWindow>().GetAbility());
                }
                break;
            case 3:
                if (PlayerInfo.Ability1 == null)
                {
                    PlayerInfo.Ability1 = type.ToString();
                    player.AssignAbility(0, GameObject.Find("Upgrade3Window").GetComponent<UpgradeWindow>().GetAbility());
                }
                else if (PlayerInfo.Ability2 == null)
                {
                    PlayerInfo.Ability2 = type.ToString();
                    player.AssignAbility(1, GameObject.Find("Upgrade3Window").GetComponent<UpgradeWindow>().GetAbility());
                }
                else if (PlayerInfo.Ability3 == null)
                {
                    PlayerInfo.Ability3 = type.ToString();
                    player.AssignAbility(2, GameObject.Find("Upgrade3Window").GetComponent<UpgradeWindow>().GetAbility());
                }
                break;
                }
    }



}
