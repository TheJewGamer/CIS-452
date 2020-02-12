using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionMenu : MonoBehaviour
{
    //variables
    public GameObject menu;
    public Character character;
    private bool rangerClassSelected = false;

    //elements
    public Text healthText;
    public Text speedText;
    public Text damageText;

    //buttons
    public Button KnifeButton;
    public Button RifleButton;
    public Button SpyButton;
    public Button RangerButton;

    public void Start()
    {
        //make sure select class first
        KnifeButton.interactable = false;
        RifleButton.interactable = false;

        //set color
        KnifeButton.GetComponent<Image>().color = Color.red;
        RifleButton.GetComponent<Image>().color = Color.red;
    }

    //ranger class selected
    public void SetClassRanger()
    {
        //update
        this.character = new ClassRanger();
        rangerClassSelected = true;
        UpdateStats();

        //feedback
        RangerButton.GetComponent<Image>().color = Color.green;
        SpyButton.GetComponent<Image>().color = Color.grey;

        //enable weapon selection 
        KnifeButton.interactable = true;
        RifleButton.interactable = true;
        KnifeButton.GetComponent<Image>().color = Color.grey;
        RifleButton.GetComponent<Image>().color = Color.grey;
    }

    //spy class selected
    public void SetClassSpy()
    {
        this.character = new ClassSpy();
        rangerClassSelected = false;
        UpdateStats();

        //feedback
        RangerButton.GetComponent<Image>().color = Color.grey;
        SpyButton.GetComponent<Image>().color = Color.green;

        //enable weapon selection 
        KnifeButton.interactable = true;
        RifleButton.interactable = true;
        KnifeButton.GetComponent<Image>().color = Color.grey;
        RifleButton.GetComponent<Image>().color = Color.grey;
    }

    public void SetWeaponRifle()
    {
        if(rangerClassSelected)
        {
            this.character = new ClassRanger();
        }
        else
        {
            this.character = new ClassSpy();
        }

        this.character = new WeaponRifle(character);
        UpdateStats();

        //feedback
        RifleButton.GetComponent<Image>().color = Color.green;
        KnifeButton.GetComponent<Image>().color = Color.grey;

        //prevent clicking
        KnifeButton.interactable = true;
        RifleButton.interactable = false;
    }

    public void SetWeaponKnife()
    {
        if (rangerClassSelected)
        {
            this.character = new ClassRanger();
        }
        else
        {
            this.character = new ClassSpy();
        }

        this.character = new WeaponKnife(character);
        UpdateStats();

        //feedback
        RifleButton.GetComponent<Image>().color = Color.grey;
        KnifeButton.GetComponent<Image>().color = Color.green;

        //prevent clicking
        KnifeButton.interactable = false;
        RifleButton.interactable = true;
    }

    private void UpdateStats()
    {
        healthText.text = (this.character.GetHealth()).ToString();
        speedText.text = (this.character.GetSpeed()).ToString();
        damageText.text = (this.character.GetDamage()).ToString();
    }

    
}
