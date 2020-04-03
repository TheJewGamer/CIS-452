/*
    * Jacob Cohen
    * TutorialController.cs
    * Assignment #9
    * controls the tutorial level
*/

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour 
{
    //variables
    public GameObject prompt1;
    public GameObject prompt2;
    public GameObject prompt3;
    public GameObject prompt4;
    public GameObject prompt5;
    public GameObject prompt6;
    public GameObject prompt7;
    public GameObject prompt8;
    public GameObject prompt9;
    public GameObject prompt10;
    public FollowerController follower;
    public GameObject enemy;

    private bool prompt1Done;
    private bool prompt2Done;
    private bool prompt3Done;
    private bool prompt4Done;
    private bool prompt5Done;
    private bool prompt6Done;
    private bool prompt7Done;
    private bool prompt8Done;
    private bool prompt9Done;

    private void Update()
    {
        //prompt 1
        if(!prompt1Done)
        {
            //set active
            prompt1.SetActive(true);

            //check
            if(Input.GetKeyDown(KeyCode.W) == true)
            {
                //done
                prompt1.SetActive(false);
                prompt1Done = true; 
            }
            else if(Input.GetKeyDown(KeyCode.S) == true)
            {
                //done
                prompt1.SetActive(false);
                prompt1Done = true; 
            }
            else if(Input.GetKeyDown(KeyCode.A) == true)
            {
                //done
                prompt1.SetActive(false);
                prompt1Done = true; 
            }
            else if(Input.GetKeyDown(KeyCode.D) == true)
            {
                //done
                prompt1.SetActive(false);
                prompt1Done = true;
            }
        }   
        //prompt 2
        else if(prompt1Done && !prompt2Done)
        {
            //set active
            prompt2.SetActive(true);

            //check
            if(follower.currentState == follower.followState)
            {
                //done
                prompt2.SetActive(false);
                prompt2Done = true;
            }            
        } 
        //prompt 3
        else if(prompt2Done && !prompt3Done)
        {
            //set active
            prompt3.SetActive(true);
            
            if(follower.currentState == follower.idleState)
            {
                //done
                prompt3.SetActive(false);
                prompt3Done = true;
            }
        }
        //prompt 4
        else if(prompt3Done && !prompt4Done)
        {
            //set active
            prompt4.SetActive(true);

            //check
            if(follower.currentState == follower.followState)
            {
                //done
                prompt4.SetActive(false);
                prompt4Done = true; 
            }
        }
        //prompt 5
        else if(prompt4Done && !prompt5Done)
        {
            //set active
            prompt5.SetActive(true);
            
            //check
            if(follower.currentState == follower.tiredState)
            {
                //done
                prompt5.SetActive(false);
                prompt5Done = true;
            }
        }
        //prompt 6
        else if(prompt5Done && !prompt6Done)
        {
            //set active
            prompt6.SetActive(true);
            
            if(follower.currentState == follower.idleState)
            {
                //done
                prompt6.SetActive(false);
                prompt6Done = true;
            }
        }
        //prompt 7
        else if(prompt6Done && !prompt7Done)
        {
            //set active
            prompt7.SetActive(true);

            //check
            if(enemy == null)
            {
                //done
                prompt7.SetActive(false);
                prompt7Done = true;
            }
            else
            {
                enemy.SetActive(true);
            }
        }
        //prompt 8
        else if(prompt7Done && !prompt8Done)
        {
            //set active
            prompt8.SetActive(true);

            //check
            if(follower.currentState == follower.idleState)
            {
                //done
                prompt8.SetActive(false);
                prompt8Done = true;
            }
        }
        //prompt 9
        else if(prompt8Done && !prompt9Done)
        {
            //set active
            prompt9.SetActive(true);

            //wait
            StartCoroutine(Prompt9Wait());
            
        }
        //prompt 10
        else if(prompt9Done)
        {
            //set active
            prompt10.SetActive(true);

            //wait
            StartCoroutine(Prompt10Wait());
        }

    }

    private IEnumerator Prompt9Wait()
    {
        yield return new WaitForSeconds(5);

        //done
        prompt9.SetActive(false);
        prompt9Done = true;
    }

    private IEnumerator Prompt10Wait()
    {
        yield return new WaitForSeconds(5);

        //done
        SceneManager.LoadScene("Game");
    }
}