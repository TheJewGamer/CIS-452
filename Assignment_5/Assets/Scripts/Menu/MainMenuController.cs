/*
    * Jacob Cohen
    * MainMenuController.cs
    * Assignment #5
    * controls the main menu
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject TutMenu;

    // Start is called before the first frame update
    void Start()
    {
        //set up menus
        MainMenu.SetActive(true);
        TutMenu.SetActive(false);
    }

    //MAIN MENU

    public void StartPushed()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("Game");
    }

    public void HowToPushed()
    {
        //change menu
        MainMenu.SetActive(false);
        TutMenu.SetActive(true);
    }

    public void QuitPushed()
    {
        Debug.Log("Quit only works on build");

        Application.Quit();
    }

    //TUT MENU
    public void BackPushed()
    {
        //change menus
        MainMenu.SetActive(true);
        TutMenu.SetActive(false);
    }
}
