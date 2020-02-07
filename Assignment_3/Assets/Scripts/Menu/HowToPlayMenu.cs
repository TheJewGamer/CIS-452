/*
    * Jacob Cohen
    * HowToPlayMenu.cs
    * Assignment #3
    * Controls the Menu Level
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayMenu : MonoBehaviour
{
    //variables
    public GameObject WMenu;
    public GameObject SMenu;
    public GameObject AMenu;
    public GameObject DMenu;
    public GameObject SpaceMenu;
    public GameObject FMenu;
    public GameObject PlayerMenu;
    public GameObject GruntMenu;
    public GameObject WatcherMenu;
    public GameObject GoalMenu;
    public GameObject controlMenu;
    public GameObject mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        //turn all sub menus off
        mainMenu.SetActive(true);
        controlMenu.SetActive(false);
        WMenu.SetActive(false);
        SMenu.SetActive(false);
        AMenu.SetActive(false);
        DMenu.SetActive(false);
        SpaceMenu.SetActive(false);
        FMenu.SetActive(false);
        PlayerMenu.SetActive(false);
        GruntMenu.SetActive(false);
        WatcherMenu.SetActive(false);
        GoalMenu.SetActive(false);
    }

    public void StartPushed()
    {
        SceneManager.LoadScene("Game");
    }

    public void ControlsPushed()
    {
        mainMenu.SetActive(false);
        controlMenu.SetActive(true);
    }

    public void QuitPushed()
    {
        Debug.Log("This only works on build");
        Application.Quit();
    }

    public void WMenuPushed()
    {
        //turn off control menu
        controlMenu.SetActive(false);

        //turn on sub menu
        WMenu.SetActive(true);
    }

    public void SMenuPushed()
    {
        //turn off control menu
        controlMenu.SetActive(false);

        //turn on sub menu
        SMenu.SetActive(true);
    }

    public void AMenuPushed()
    {
       //turn off control menu
        controlMenu.SetActive(false);

        //turn on sub menu
        AMenu.SetActive(true);
    }

    public void DMenuPushed()
    {
        //turn off control menu
        controlMenu.SetActive(false);

        //turn on sub menu
        DMenu.SetActive(true);
    }

    public void SpaceMenuPushed()
    {
        //turn off control menu
        controlMenu.SetActive(false);

        //turn on sub menu
        SpaceMenu.SetActive(true);
    }

    public void FMenuPushed()
    {
        //turn off control menu
        controlMenu.SetActive(false);

        //turn on sub menu
        FMenu.SetActive(true);
    }

    public void PlayerMenuPushed()
    {
        //turn off control menu
        controlMenu.SetActive(false);

        //turn on sub menu
        PlayerMenu.SetActive(true);
    }

    public void WatcherMenuPushed()
    {
        //turn off control menu
        controlMenu.SetActive(false);

        //turn on sub menu
        WatcherMenu.SetActive(true);
    }


    public void GruntMenuPushed()
    {
        //turn off control menu
        controlMenu.SetActive(false);

        //turn on sub menu
        GruntMenu.SetActive(true);
    }

    public void GoalMenuPushed()
    {
        //turn off control menu
        controlMenu.SetActive(false);

        //turn on sub menu
        GoalMenu.SetActive(true);
    }

    public void BackToControlMenu()
    {
        //turn off all sub menus
        WMenu.SetActive(false);
        SMenu.SetActive(false);
        AMenu.SetActive(false);
        DMenu.SetActive(false);
        SpaceMenu.SetActive(false);
        FMenu.SetActive(false);
        PlayerMenu.SetActive(false);
        GruntMenu.SetActive(false);
        WatcherMenu.SetActive(false);
        GoalMenu.SetActive(false);

        //turn on control menu
        controlMenu.SetActive(true);
    }

    public void backToMainMenu()
    {
        controlMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    
}
