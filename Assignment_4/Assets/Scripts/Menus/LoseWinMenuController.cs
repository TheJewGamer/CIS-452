using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseWinMenuController : MonoBehaviour
{
   public void RestartPushed()
    {
        //reset level
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void MainMenuPushed()
    {
        //go to main menu
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
