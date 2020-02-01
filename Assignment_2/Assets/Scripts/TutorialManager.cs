/*
    * Jacob Cohen
    * TutorialManager.cs
    * Assignment #2
    * Controls the tutorial level
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    //prompt 1
    public GameObject prompt1;
    private bool movedUp = false;
    private bool movedDown = false;
    private bool movedLeft = false;
    private bool movedRight = false;
    private bool prompt1Completed = false;
    //prompt 2
    public GameObject prompt2;
    private bool prompt2Completed = false;
    private bool prompt3Called = false;

    //prompt 3
    public GameObject prompt3;
    private bool prompt3Completed = false;
    private bool prompt4Called = false;

    //prompt 4
    public GameObject prompt4;
    private bool prompt4Completed = false;
    private bool prompt5Called = false;

    //prompt 5
    public GameObject prompt5;
    private bool prompt5Completed = false;
    private bool prompt6Called = false;

    //prompt 6
    public GameObject prompt6;
    private bool prompt6Completed = false;
    private bool prompt7Called = false;

    //prompt 7
    public GameObject prompt7;
    private bool prompt7Completed = false;
    private bool prompt8Called = false;

    //prompt 8
    public GameObject prompt8;
    private bool prompt8Completed = false;
    private bool prompt9Called = false;

    //prompt 9
    public GameObject prompt9;
    public GameObject enemy;
    private bool prompt9Completed = false;
    private bool prompt10Called = false;

    //prompt 10
    public GameObject prompt10;
    private bool prompt10Completed = false;
    private bool prompt11Called = false;

    //prompt 11
    public GameObject prompt11;

    //prompt 12
    public GameObject prompt12;

    //prompt 13
    public GameObject prompt13;

    void Start()
    {
        //setup
        prompt1.SetActive(true);
        prompt2.SetActive(false);
        prompt3.SetActive(false);
        prompt4.SetActive(false);
        prompt5.SetActive(false);
        prompt6.SetActive(false);
        prompt7.SetActive(false);
        prompt8.SetActive(false);
        prompt9.SetActive(false);
        prompt10.SetActive(false);
        prompt11.SetActive(false);
        prompt12.SetActive(false);
        prompt13.SetActive(false);
        enemy.SetActive(false);
    }

    //check for which prompt player is on
    void Update()
    {
        if(!prompt1Completed)
        {
            Prompt1();
        }
        else if(prompt1Completed && !prompt3Called)
        {
            Prompt2();
        }
        else if(prompt2Completed && !prompt4Called)
        {
            Prompt3();
        }
        else if(prompt3Completed && !prompt5Called)
        {
            Prompt4();
        }
        else if(prompt4Completed && !prompt6Called)
        {
            Prompt5(); 
        }
        else if(prompt5Completed && !prompt7Called)
        {
            Prompt6();
        }
        else if(prompt6Completed && !prompt8Called)
        {
            Prompt7();
        }
        else if(prompt7Completed && !prompt9Called)
        {
            Prompt8();
        }
        else if(prompt8Completed && !prompt10Called)
        {
            Prompt9();
        }
        else if(prompt9Completed && !prompt11Called)
        {
            Prompt10();
        }
    }

    void Prompt1()
    {
        //moved up
        if(Input.GetKeyDown(KeyCode.W) == true)
        {
            movedUp = true;
        }
        //moved down
        if(Input.GetKeyDown(KeyCode.S) == true)
        {
            movedDown = true;
        }
        //moved right
        if(Input.GetKeyDown(KeyCode.D) == true)
        {
            movedRight = true;
        }
        //moved left
        if(Input.GetKeyDown(KeyCode.A) == true)
        {
            movedLeft = true;
        }

        //done
        if(movedUp && movedDown && movedLeft && movedRight)
        {
            prompt1Completed = true;

            prompt1.SetActive(false);

            Prompt2();
        }
    }

    void Prompt2()
    {
        prompt2.SetActive(true);

        //check
        if(Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse Y") < 0 || Input.GetAxis("Mouse Y") > 0)
        {
            prompt2Completed = true;
            prompt3Called = true;

            prompt2.SetActive(false);

            //next
            Prompt3();
        }
    }

    void Prompt3()
    {
        prompt3.SetActive(true);

        if(Input.GetKeyDown(KeyCode.Alpha2) == true)
        {
            prompt3Completed = true;
            prompt4Called = true;

            prompt3.SetActive(false);

            //next
            Prompt4();
        }
    }

    void Prompt4()
    {
        prompt4.SetActive(true);

        if(Input.GetKeyDown(KeyCode.Alpha1) == true)
        {
            prompt4Completed = true;
            prompt5Called = true;

            prompt4.SetActive(false);

            //next
            Prompt5();
        }
    }

    void Prompt5()
    {
        prompt5.SetActive(true);

        if(Input.GetMouseButtonDown(0) == true)
        {
            prompt5Completed = true;
            prompt6Called = true;

            prompt5.SetActive(false);

            //next
            Prompt6();
        }
    }

    void Prompt6()
    {
        prompt6.SetActive(true);

        if(Input.GetKeyDown(KeyCode.R) == true)
        {
            prompt6Completed = true;
            prompt7Called = true;

            prompt6.SetActive(false);

            //next
            Prompt7();
        }
    }

    void Prompt7()
    {
        prompt7.SetActive(true);

        if(Input.GetKeyDown(KeyCode.Alpha2) == true)
        {
            prompt7Completed = true;
            prompt8Called = true;

            prompt7.SetActive(false);

            //next
            Prompt8();
        }
    }

    void Prompt8()
    {
        prompt8.SetActive(true);

        if(Input.GetMouseButtonDown(0) == true)
        {
            prompt8Completed = true;
            prompt9Called = true;

            prompt8.SetActive(false);

            //next
            Prompt9();
        }
    }

    void Prompt9()
    {
        prompt9.SetActive(true);
        enemy.SetActive(true);

        if(enemy.GetComponent<TutorialEnemy>().health == 2)
        {
            prompt9Completed = true;
            prompt10Called = true;

            prompt9.SetActive(false);

            //next
            Prompt10();
        }
    }

    void Prompt10()
    {
        prompt10.SetActive(true);

        if(enemy == null)
        {
            prompt10Completed = true;
            prompt11Called = true;

            prompt10.SetActive(false);

            //next
            Prompt11();
        }
    }

    void Prompt11()
    {
        //enable
        prompt11.SetActive(true);

        //wait
        StartCoroutine(wait());
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(10);

        //enable
        prompt11.SetActive(false);
        prompt12.SetActive(true);

        //wait
        StartCoroutine(wait2());
    }

    private IEnumerator wait2()
    {
        yield return new WaitForSeconds(10);

        //enable
        prompt12.SetActive(false);
        prompt13.SetActive(true);

        //wait
        StartCoroutine(wait3());
    }

    private IEnumerator wait3()
    {
        yield return new WaitForSeconds(5);

        //load 
        SceneManager.LoadScene("Game");
    }
}
