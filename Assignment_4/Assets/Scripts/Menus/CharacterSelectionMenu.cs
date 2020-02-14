using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionMenu : MonoBehaviour
{
    //variables
    public GameObject mainMenu;
    public GameObject classMenu;
    public GameObject gearMenu;
    public Character character;
    private bool rangerClassSelected = false;
    private const int MAX_NUMBER_OF_GEAR = 3;
    private int currentGearCount;

    //gear counts
    private int glassesCount;
    private int heavyArmorCount;
    private int lightArmorCount;
    private int ScopeCount;

    //elements
    public Text healthText;
    public Text speedText;
    public Text damageText;
    public Text glassesCountText;
    public Text heavyArmorCountText;
    public Text lightArmorCountText;
    public Text ScopeCountText;

    //buttons
    public Button SpyButton;
    public Button RangerButton;
    public GameObject nextButton;
    public PlayerController playerScript;

    public void Start()
    {
        //prevent input
        Time.timeScale = 0;

        mainMenu.SetActive(true);
        classMenu.SetActive(true);
        gearMenu.SetActive(false);
        nextButton.SetActive(false);

        //set vars
        currentGearCount = 0;
        glassesCount = 0;
        heavyArmorCount = 0;
        lightArmorCount = 0;
        ScopeCount = 0;

        //prevent errors
        this.character = new ClassRanger();
        playerScript.SetCharacter(this.character);
    }

    //ranger class selected
    public void SetClassRanger()
    {
        //update
        this.character = new ClassRanger();
        rangerClassSelected = true;
        nextButton.SetActive(true);
        UpdateStats();

        //feedback
        RangerButton.GetComponent<Image>().color = Color.green;
        SpyButton.GetComponent<Image>().color = Color.grey;
    }

    //spy class selected
    public void SetClassSpy()
    {
        this.character = new ClassSpy();
        rangerClassSelected = false;
        nextButton.SetActive(true);
        UpdateStats();

        //feedback
        RangerButton.GetComponent<Image>().color = Color.grey;
        SpyButton.GetComponent<Image>().color = Color.green;

    }

    public void GlassesPushed()
    {
        //check
        if(currentGearCount < 3)
        {
            //inc
            currentGearCount++;
            glassesCount++;

            //call
            this.character = new GearGlasses(character);

            //call
            UpdateStats();
        }
    }

    public void HeavyArmorPushed()
    {
        //check
        if(currentGearCount < 3)
        {
            //inc
            currentGearCount++;
            heavyArmorCount++;

            //call
            this.character = new GearHeavyArmor(character);

            //call
            UpdateStats();
        }
    }

    public void LightArmorPushed()
    {
        //check
        if(currentGearCount < 3)
        {
            //inc
            currentGearCount++;
            lightArmorCount++;

            //call
            this.character = new GearLightArmor(character);

            //call
            UpdateStats();
        }
    }

    public void ScopePushed()
    {
        //check
        if(currentGearCount < 3)
        {
            //inc
            currentGearCount++;
            ScopeCount++;

            //call
            this.character = new GearGlasses(character);

            //call
            UpdateStats();
        }
    }

    //reset button pushed
    public void resetGear()
    {
        //check class
        if(rangerClassSelected)
        {
            this.character = new ClassRanger();
        }
        else
        {
            this.character = new ClassSpy();
        }

        //reset vars
        currentGearCount = 0;
        glassesCount = 0;
        heavyArmorCount = 0;
        lightArmorCount = 0;
        ScopeCount = 0;

        //call
        UpdateStats();
    }

    //confirm button pushed
    public void ConfirmPushed()
    {
        //start game
        Time.timeScale = 1;
        mainMenu.SetActive(false);

        playerScript.SetCharacter(this.character);
    }

    //next button pushed
    public void NextPushed()
    {
        //menu update
        gearMenu.SetActive(true);
        classMenu.SetActive(false);
    }

    //back button pushed
    public void BackPushed()
    {
        //menu update
        classMenu.SetActive(true);
        gearMenu.SetActive(false);
    }

    private void UpdateStats()
    {
        healthText.text = (this.character.GetHealth()).ToString();
        speedText.text = (this.character.GetSpeed()).ToString();
        damageText.text = (this.character.GetDamage()).ToString();
        glassesCountText.text = glassesCount.ToString();
        heavyArmorCountText.text = heavyArmorCount.ToString();
        lightArmorCountText.text = lightArmorCount.ToString();
        ScopeCountText.text = ScopeCount.ToString();
    }
    
}
