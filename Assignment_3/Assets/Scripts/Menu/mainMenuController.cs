using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{
    //variables
    public GameObject mainMenu;
    public GameObject tutMenu;

    // Start is called before the first frame update
    void Start()
    {
        //set up menus
        mainMenu.SetActive(true);
        tutMenu.SetActive(false);
    }

    public void QuitPushed()
    {
        Debug.Log("This only works on build");
        Application.Quit();
    }

    //start button is pushed
    public void StartPushed()
    {
        mainMenu.SetActive(false);
        tutMenu.SetActive(true);
    }

    //yes for tutorial is pushed
    public void YesPushed()
    {
        SceneManager.LoadScene("Tutorial");
    }

    //no for tutorial is pushed
    public void NoPushed()
    {
        SceneManager.LoadScene("Game");
    }
}
