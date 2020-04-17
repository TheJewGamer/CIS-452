/*
    * Jacob Cohen
    * TuTManager.cs
    * Final Project
    * controls the tutorial level
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutManager : MonoBehaviour
{
    //variables
    public GameObject prompt1;
    public GameObject prompt2;
    public GameObject prompt3;
    public GameObject prompt4;
    public GameObject prompt5;
    public GameObject prompt6;
    public GameObject prompt7;

    private bool prompt1Done;
    private bool prompt2Done;
    private bool prompt3Done;
    private bool prompt4Done;
    private bool prompt5Done;
    private bool prompt6Done;

    public GameObject greenShip;
    public GameObject yellow;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        //set up
        prompt1.SetActive(false);
        prompt2.SetActive(false);
        prompt3.SetActive(false);
        prompt4.SetActive(false);
        prompt5.SetActive(false);
        prompt6.SetActive(false);
        prompt7.SetActive(false);

        //vars
        prompt1Done = false;
        prompt2Done = false;
        prompt3Done = false;
        prompt4Done = false;
        prompt5Done = false;
        prompt6Done = false;

    }

    // Update is called once per frame
    void Update()
    {
        //promp1
        if(!prompt1Done)
        {
            //active
            prompt1.SetActive(true);

            //check
            if(Input.GetKeyDown(KeyCode.A) == true || Input.GetKeyDown(KeyCode.S) == true || Input.GetKeyDown(KeyCode.D) == true || Input.GetKeyDown(KeyCode.W) == true)
            {
                //done
                prompt1.SetActive(false);
                prompt1Done = true;
            }
        }
        //prompt 2
        else if(prompt1Done && !prompt2Done)
        {
            //check
            if(greenShip != null)
            {
                //active
                prompt2.SetActive(true);
                greenShip.SetActive(true);
            }
            else
            {
                //done
                prompt2.SetActive(false);
                prompt2Done = true;
            }
        }
        //prompt 3
        else if(prompt2Done && !prompt3Done)
        {
            //wait
            StartCoroutine(Wait3());
        }
        //prompt 4
        else if(prompt3Done && !prompt4Done)
        {
            //active
            prompt4.SetActive(true);

            //check
            if(yellow != null)
            {
                yellow.SetActive(true);
            }
            else
            {
                //done
                prompt4.SetActive(false);
                prompt4Done = true;
            }
        }
        //prompt 5
        else if(prompt4Done && !prompt5Done)
        {
            //active
            prompt5.SetActive(true);

            //check
            if(player.stunned == false)
            {
                //done
                prompt5.SetActive(false);
                prompt5Done = true;
            }
        }
        //prompt 6
        else if(prompt5Done && !prompt6Done)
        {
            //active
            prompt6.SetActive(true);

            //wait
            StartCoroutine(Wait6());
        }
        //prompt 7
        else if(prompt6Done)
        {
            //active
            prompt7.SetActive(true);

            //wait
            StartCoroutine(Wait7());
        }
    }

    private IEnumerator Wait3()
    {
        //active
        prompt3.SetActive(true);

        yield return new WaitForSecondsRealtime(5);

        //done
        prompt3.SetActive(false);
        prompt3Done = true;
    }

    private IEnumerator Wait6()
    {
        yield return new WaitForSecondsRealtime(5);

        //done
        prompt6.SetActive(false);
        prompt6Done = true;
    }

    private IEnumerator Wait7()
    {
        yield return new WaitForSecondsRealtime(5);

        //done
        SceneManager.LoadScene("Game");
    } 
}
