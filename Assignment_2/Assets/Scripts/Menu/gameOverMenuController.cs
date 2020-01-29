using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.SceneManagement;

public class gameOverMenuController : MonoBehaviour
{
    public void Retry()
    {
        //unpause game
        Time.timeScale = 1;

        //reload level
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        //unpause game
        Time.timeScale = 1;

        //back to mainMenu
        SceneManager.LoadScene("Menu");
    }
}
