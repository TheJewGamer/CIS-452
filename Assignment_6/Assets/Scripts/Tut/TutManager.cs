/*
    * Jacob Cohen
    * TutManager.cs
    * Assignment #6
    * controls the tutorial level
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutManager : MonoBehaviour
{
    //vars
    public GameObject prompt1;
    public GameObject prompt2;
    public GameObject prompt3;
    public GameObject prompt4;
    public GameObject prompt5;
    public GameObject prompt6;
    public GameObject prompt7;
    public GameObject prompt8;
    public GameObject prompt9;

    private bool prompt1Done;
    private bool prompt2Done;
    private bool prompt3Done;
    private bool prompt4Done;
    private bool prompt5Done;
    private bool prompt6Done;
    private bool prompt7Done;
    private bool prompt8Done;
    private bool firstRunPrompt4;

    private bool moved;
    private GameObject test; 
    private CharacterCreator characterCreator;
    public Transform spawner;
    public GameObject player;
    private GameObject currentCharacterSpawn;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        //set up
        prompt1.SetActive(true);
        prompt2.SetActive(false);
        prompt3.SetActive(false);
        prompt4.SetActive(false);
        prompt5.SetActive(false);
        prompt6.SetActive(false);
        prompt7.SetActive(false);
        prompt8.SetActive(false);
        prompt9.SetActive(false);

        //set vars
        prompt1Done = false;
        prompt2Done = false;
        prompt3Done = false;
        prompt4Done = false;
        prompt5Done = false;
        prompt6Done = false;
        prompt7Done = false;
        prompt8Done = false;

        //vars
        moved = false;
        firstRunPrompt4 = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //prompt 1
        if(!prompt1Done)
        {
            //prompt
            prompt1.SetActive(true);

            //check
            if(Input.GetKeyDown(KeyCode.W) == true)
            {
                moved = true;
            }
            else if(Input.GetKeyDown(KeyCode.S) == true)
            {
                moved = true;
            }
            else if(Input.GetKeyDown(KeyCode.D) == true)
            {
                moved = true;
            }
            else if(Input.GetKeyDown(KeyCode.A) == true)
            {
                moved = true;
            }

            //check
            if(moved)
            {
                //done
                prompt1.SetActive(false);
                prompt1Done = true;
            }
        }
        //prompt 2
        else if(prompt1Done && !prompt2Done)
        {
            //prompt
            prompt2.SetActive(true);

            //check
            if(Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse Y") < 0 || Input.GetAxis("Mouse Y") > 0)
            {
                //done
                prompt2Done = true;
                prompt2.SetActive(false);
            }
        }
        //prompt 3
        else if(prompt2Done && !prompt3Done) 
        {
            //prompt
            prompt3.SetActive(true);

            //check
            if(Input.GetMouseButtonDown(0) == true)
            {
                //done
                prompt3Done = true;
                prompt3.SetActive(false);
            }
        }
        //prompt 4
        else if(prompt3Done && !prompt4Done)
        {
            //prompt
            prompt4.SetActive(true);

            if(!firstRunPrompt4)
            {
                //spawn enemy
                characterCreator = new EnemyCharacter();
                currentCharacterSpawn = characterCreator.CreateCharacter("walker");
                currentCharacterSpawn = Instantiate(currentCharacterSpawn, spawner.position, spawner.rotation);
                currentCharacterSpawn.AddComponent<TutEnemyWalker>();

                //update
                firstRunPrompt4 = true;
            }
        
            //check to see if there are any enemies on the map
            if(currentCharacterSpawn == null)
            {
                //done
                prompt4Done = true;
                prompt4.SetActive(false);
            }    
        }
        //prompt 5
        else if(prompt4Done && !prompt5Done)
        {
            //prompt
            prompt5.SetActive(true);

            //wait
            StartCoroutine("WaitPrompt5");

        }
        //prompt 6
        else if(prompt5Done && !prompt6Done)
        {
            //prompt
            prompt6.SetActive(true);

            //check
            if(Input.GetKeyDown(KeyCode.Alpha1) == true)
            {
                //spawn walker
                characterCreator = new FriendlyCharacter();
                GameObject currentCharacterSpawn = characterCreator.CreateCharacter("walker");
                currentCharacterSpawn = Instantiate(currentCharacterSpawn, player.transform.position, player.transform.rotation);
                currentCharacterSpawn.AddComponent<TutWalkerFriendly>();

                //done
                prompt6.SetActive(false);
                prompt6Done = true;
            }
        }
        //prompt 7
        else if(prompt6Done && !prompt7Done)
        {
            //prompt
            prompt7.SetActive(true);

            //check
            if(Input.GetKeyDown(KeyCode.Alpha2) == true)
            {
                //spawn runner
                characterCreator = new FriendlyCharacter();
                GameObject currentCharacterSpawn = characterCreator.CreateCharacter("runner");
                currentCharacterSpawn = Instantiate(currentCharacterSpawn, player.transform.position, player.transform.rotation);
                currentCharacterSpawn.AddComponent<TutRunnerFriendly>();

                //done
                prompt7.SetActive(false);
                prompt7Done = true;
            }
        }
        //prompt 8
        else if(prompt7Done && !prompt8Done)
        {
            //prompt
            prompt8.SetActive(true);

            //wait
            StartCoroutine("WaitPrompt8");
        }
        //prompt 9
        else if(prompt8Done)
        {
            //prompt
            prompt9.SetActive(true);

            //wait
            StartCoroutine("WaitPrompt9");
        }
    }

    private IEnumerator WaitPrompt5()
    {
        //wait
        yield return new WaitForSeconds(5);

        //done
        prompt5.SetActive(false);
        prompt5Done = true;
    }

    private IEnumerator WaitPrompt8()
    {
        //wait
        yield return new WaitForSeconds(5);

        //done
        prompt8.SetActive(false);
        prompt8Done = true;
    }

    private IEnumerator WaitPrompt9()
    {
        //wait
        yield return new WaitForSeconds(5);

        //done
        SceneManager.LoadScene("Game");
    }
}
