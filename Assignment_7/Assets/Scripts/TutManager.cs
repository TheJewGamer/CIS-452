/*
    * Jacob Cohen
    * TutManger.cs
    * Assignment #7
    * Controls the tutorial level
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutManager : MonoBehaviour
{
    public GameObject prompt1;
    public GameObject prompt2;
    public GameObject prompt3;
    public GameObject prompt4;
    public GameObject prompt5;
    public GameObject prompt6;
    public GameObject prompt7;
    public GameObject prompt8;
    public GameObject enemy;

    private bool prompt1C;
    private bool prompt2C;
    private bool prompt3C;
    private bool prompt4C;
    private bool prompt5C;
    private bool prompt6C;
    private bool prompt7C;
    private bool prompt7Called;


    // Start is called before the first frame update
    void Start()
    {
        prompt1.SetActive(true);
        prompt2.SetActive(false);
        prompt3.SetActive(false);
        prompt4.SetActive(false);
        prompt5.SetActive(false);
        prompt6.SetActive(false);
        prompt7.SetActive(false);
        prompt8.SetActive(false);
        enemy.SetActive(false);

        prompt1C = false;
        prompt2C = false;
        prompt3C = false;
        prompt4C = false;
        prompt5C = false;
        prompt6C = false;
        prompt7C = false;
        prompt7Called = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //prompt 1
        if(!prompt1C)
        {
            prompt1.SetActive(true);

            //check
            if(Input.GetKeyDown(KeyCode.W) == true)
            {
                prompt1C = true;
                prompt1.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.D) == true)
            {
                prompt1C = true;
                prompt1.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.S) == true)
            {
                prompt1C = true;
                prompt1.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.A) == true)
            {
                prompt1C = true;
                prompt1.SetActive(false);
            }
            
        }
        //prompt 2
        else if(prompt1C && !prompt2C)
        {
            prompt2.SetActive(true);

            //check
            if(Input.GetKeyDown(KeyCode.F) == true)
            {
                prompt2.SetActive(false);
                prompt2C = true;
            }
        }
        //prompt 3
        else if(prompt2C && !prompt3C)
        {
            prompt3.SetActive(true);

            //check
            if(Input.GetKeyDown(KeyCode.Space) == true)
            {
                prompt3.SetActive(false);
                prompt3C = true;
            }
        }
        //prompt 4
        else if(prompt3C && !prompt4C)
        {
            prompt4.SetActive(true);

            //check
            if(Input.GetKeyDown(KeyCode.R) == true)
            {
                prompt4.SetActive(false);
                prompt4C = true;
            }
        }
        //prompt 5
        else if(prompt4C && !prompt5C)
        {
            prompt5.SetActive(true);

            //check
            if(Input.GetKeyDown(KeyCode.Space) == true)
            {
                prompt5.SetActive(false);
                prompt5C = true;
            }
        }
        //prompt 6
        else if(prompt5C && !prompt6C)
        {
            prompt6.SetActive(true);

            //wait
            StartCoroutine(wait6());
        }
        //prompt 7
        else if(prompt6C && !prompt7C && !prompt7Called)
        {
            prompt7.SetActive(true);
            enemy.SetActive(true);
            prompt7Called = true;
        }
        //prompt 8
        else if(prompt7C)
        {
            prompt8.SetActive(true);

            //wait
            StartCoroutine(wait8());
        }
    }

    private IEnumerator wait6()
    {
        yield return new WaitForSeconds(5);

        prompt6.SetActive(false);
        prompt6C = true;
    }

    private IEnumerator wait8()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("Game");
    }

    public void EnemyKilled()
    {
        prompt7C = true;
        prompt7.SetActive(false);
    }
}
