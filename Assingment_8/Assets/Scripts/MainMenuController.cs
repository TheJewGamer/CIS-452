/*
    * Jacob Cohen
    * MainMenuController.cs
    * Assignment #7
    * controls the main menu
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject tutMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        tutMenu.SetActive(false);
    }

    public void StartPushed()
    {
        mainMenu.SetActive(false);
        tutMenu.SetActive(true);
    }

    public void YesPushed()
    {
        SceneManager.LoadScene("Tut");
    }

    public void NoPushed()
    {
        SceneManager.LoadScene("Game");
    }


    public void BackPushed()
    {
        mainMenu.SetActive(true);
        tutMenu.SetActive(false);
    }

    public void QuitPushed()
    {
        Application.Quit();
        Debug.Log("Quit only works on build");
    }
}
