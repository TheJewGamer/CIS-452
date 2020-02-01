/*
    * Jacob Cohen
    * menuMangager.cs
    * Assignment #2
    * Controls the main menu
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    //variables
    public GameObject mainMenu;
    public GameObject tutorialMenu;

    // Start is called before the first frame update
    void Start()
    {
        //set menus up
        mainMenu.SetActive(true);
        tutorialMenu.SetActive(false);
    }

    //start button is pushed
   public void StartPressed()
   {
       mainMenu.SetActive(false);
       tutorialMenu.SetActive(true);
   }

   //quit button is pushed
   public void QuitPressed()
   {
       Debug.Log("Quit only works on a build");

       Application.Quit();
   }

    //user wants to learn how to play
   public void TutorialYes()
   {
       //load tutorial level
       SceneManager.LoadScene("Tutorial");
   }

    //user does not want to learn how to play
   public void TutorialNo()
   {
       //load main level
       SceneManager.LoadScene("Game");

   }

    //go back to mainMenu
   public void backButton()
   {
       tutorialMenu.SetActive(false);
       mainMenu.SetActive(true);
   }
}
