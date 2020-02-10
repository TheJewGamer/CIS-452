using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    //variables
    public GameObject mainMenu;
    public GameObject tutMenu;

    void Start()
    {
        //set up
        mainMenu.SetActive(true);
        tutMenu.SetActive(false);
    }

    //start button pushed
    public void StartPushed()
    {
        //load level
        SceneManager.LoadScene("Game");
    }

    //How to play button is pushed
    public void TutPushed()
    {
        //load menu
        mainMenu.SetActive(false);
        tutMenu.SetActive(true);
    }

    public void BackToMainMenu()
    {
        //load menu
        mainMenu.SetActive(true);
        tutMenu.SetActive(false);
    }

    public void BackToTutMenu()
    {
        //disable tut sub menus

        //load tut menu
        tutMenu.SetActive(true);
    }

    //quit button pushed
    public void QuitPushed()
    {
        //testing
        Debug.Log("Quitting only works on build.");

        //quit
        Application.Quit();
    }
}
