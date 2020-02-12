using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionMenu : MonoBehaviour
{
    //variables
    public GameObject menu;
    public Character character;

    //elements
    public Text healthText;
    public Text speedText;
    public Text damageText;

    //buttons
    public Button KnifeButton;
    public Button RifleButton;

    public void Start()
    {
        //make sure select class first
        KnifeButton.interactable = false;
        RifleButton.interactable = false;
    }

    //ranger class selected
    public void SetClassRanger()
    {
        this.character = new ClassRanger();
        UpdateStats();

        //enable weapon selection 
        KnifeButton.interactable = true;
        RifleButton.interactable = true;
    }

    //spy class selected
    public void SetClassSpy()
    {
        this.character = new ClassSpy();
        UpdateStats();

        //enable weapon selection 
        KnifeButton.interactable = true;
        RifleButton.interactable = true;
    }

    public void SetWeaponRifle()
    {
        this.character = new WeaponRifle(character);
        UpdateStats();
    }

    public void SetWeaponKnife()
    {
        this.character = new WeaponKnife(character);
        UpdateStats();
    }

    private void UpdateStats()
    {
        healthText.text = (this.character.GetHealth()).ToString();
        speedText.text = (this.character.GetSpeed()).ToString();
        damageText.text = (this.character.GetDamage()).ToString();
    }

    
}
