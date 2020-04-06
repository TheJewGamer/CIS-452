/*
    * Jacob Cohen
    * TutManager.cs
    * Assignment #8
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
    public GameObject player;
    public GameObject customer;

    private bool prompt1Done;
    private bool prompt2Done;
    private bool prompt3Done;
    private bool prompt4Done;
    private bool prompt5Called;


    // Start is called before the first frame update
    void Start()
    {
        //set up
        prompt1.SetActive(true);
        prompt2.SetActive(false);
        prompt3.SetActive(false);
        prompt4.SetActive(false);
        prompt5.SetActive(false);
        customer.SetActive(false);

        //set vars
        prompt1Done = false;
        prompt2Done = false;
        prompt3Done = false;
        prompt4Done = false;
        prompt5Called = false;
    }

    private void Update() 
    {
        //prompt 1
        if(!prompt1Done)
        {
            Prompt1();
        }
        else if(prompt1Done && !prompt2Done)
        {
            Prompt2();
        }    
        else if(prompt2Done && !prompt3Done)
        {
            Prompt3();
        }
        else if(prompt3Done &&!prompt4Done)
        {
            Prompt4();
        }
        else if(prompt4Done && !prompt5Called)
        {
            Prompt5();
        }
    }

    private void Prompt1()
    {
        //check
        if(Input.GetKeyDown(KeyCode.W) == true)
        {
            prompt1.SetActive(false);
            prompt1Done = true;
            Prompt2();
        }
        else if (Input.GetKeyDown(KeyCode.D) == true)
        {
            prompt1.SetActive(false);
            prompt1Done = true;
            Prompt2();
        }
        else if (Input.GetKeyDown(KeyCode.S) == true)
        {
            prompt1.SetActive(false);
            prompt1Done = true;
            Prompt2();
        }
        else if (Input.GetKeyDown(KeyCode.A) == true)
        {
            prompt1.SetActive(false);
            prompt1Done = true;
            Prompt2();
        }
    }
    private void Prompt2()
    {
        //active
        prompt2.SetActive(true);

        //check
        if(player.transform.GetChild(0).gameObject.activeSelf == true)
        {
            prompt2.SetActive(false);
            prompt2Done = true;
            Prompt3();
        }
        else if(player.transform.GetChild(1).gameObject.activeSelf == true)
        {
            prompt2.SetActive(false);
            prompt2Done = true;
            Prompt3();
        }
        else if(player.transform.GetChild(2).gameObject.activeSelf == true)
        {
            prompt2.SetActive(false);
            prompt2Done = true;
            Prompt3();
        }
        
    }
    private void Prompt3()
    {
        //active
        prompt3.SetActive(true);
        customer.SetActive(true);

        //check
        if(customer.GetComponent<Customer>().seated == true)
        {
            //done
            prompt3.SetActive(false);
            prompt3Done = true;
            Prompt4();
        }
    }
    private void Prompt4()
    {
        //active
        prompt4.SetActive(true);

        //check
        if(customer.GetComponent<Customer>().served == true)
        {
            //done
            prompt4.SetActive(false);
            prompt4Done = true;
            Prompt5();
        }
        
    }
    private void Prompt5()
    {
        //update var
        prompt5Called = true;

        //active
        prompt5.SetActive(true);

        //call
        StartCoroutine(Prompt5Wait());
    }

    private IEnumerator Prompt5Wait()
    {
        //wait
        yield return new WaitForSeconds(5);

        //load
        SceneManager.LoadScene("Game");
    }
}
