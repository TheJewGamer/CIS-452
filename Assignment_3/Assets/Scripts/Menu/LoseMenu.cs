using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public void RestartPushed()
    {
        //reset level
        SceneManager.LoadScene("Game");
    }

    public void MainMenuPushed()
    {
        //go to main menu
        SceneManager.LoadScene("Menu");
    }
}
