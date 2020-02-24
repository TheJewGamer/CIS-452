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
        SceneManager.LoadScene("Game");
    }

    public void HowToPushed()
    {
        mainMenu.SetActive(false);
        tutMenu.SetActive(true);
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
