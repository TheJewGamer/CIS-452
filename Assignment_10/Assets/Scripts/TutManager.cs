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
    public GameObject tutEnemy;
    public GameObject arrow;
    public GameObject pickup;

    public bool prompt1Done;
    public bool prompt2Done;
    public bool prompt3Done;
    public bool prompt4Done;
    public bool prompt5Done;
    public bool prompt6Done;

    // Start is called before the first frame update
    void Start()
    {
        prompt1.SetActive(false);
        prompt2.SetActive(false);
        prompt3.SetActive(false);
        prompt4.SetActive(false);
        prompt5.SetActive(false);
        prompt6.SetActive(false);
        prompt7.SetActive(false);
        tutEnemy.SetActive(false);
        arrow.SetActive(false);
        pickup.SetActive(false);

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
        //prompt1
        if(!prompt1Done)
        {
            //active
            prompt1.SetActive(true);

            //check
            if(Input.GetKeyDown(KeyCode.W) == true || Input.GetKeyDown(KeyCode.S) == true || Input.GetKeyDown(KeyCode.A) == true || Input.GetKeyDown(KeyCode.D) == true)
            {
                //done
                prompt1Done = true;

                //de activate
                prompt1.SetActive(false);
            }
        }
        //prompt2
        else if(prompt1Done && !prompt2Done)
        {
            //active
            prompt2.SetActive(true);

            //check
            if(Input.GetAxis("Mouse X") < 0 || Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse Y") > 0 || Input.GetAxis("Mouse Y") < 0)
            {
                //done
                prompt2Done = true;

                //turn off
                prompt2.SetActive(false);
            }
        }
        //prompt 3
        else if(prompt2Done && !prompt3Done)
        {
            //active
            prompt3.SetActive(true);

            //check
            if(Input.GetKeyDown(KeyCode.Mouse0) == true)
            {
                //done
                prompt3Done = true;

                //turn off
                prompt3.SetActive(false);
            }
        }
        //prompt 4
        else if(prompt3Done && !prompt4Done)
        {
            //active
            prompt4.SetActive(true);

            //activate enemy
            tutEnemy.SetActive(true);

            //check
            if(tutEnemy == null)
            {
                //done
                prompt4Done = true;

                //turn off
                prompt4.SetActive(false);
            }
        }
        //prompt 5
        else if(prompt4Done && !prompt5Done)
        {
            //active
            prompt5.SetActive(true);

            //call
            StartCoroutine(prompt5Wait());
        }
        //prompt 6
        else if(prompt5Done && !prompt6Done)
        {
            //active
            prompt6.SetActive(true);

             //turn on arrow
            arrow.SetActive(true);

            //check
            if(pickup == null)
            {
                //done
                prompt6Done = true;

                //turn off
                prompt6.SetActive(false);
                arrow.SetActive(false);
            }
        }
        //prompt 7
        else if(prompt6Done)
        {
            //active
            prompt7.SetActive(true);

            StartCoroutine(prompt5Wait());
        }
    }

    private IEnumerator prompt5Wait()
    {
        yield return new WaitForSeconds(5);

        //done
        prompt5Done = true;

        //turn off
        prompt5.SetActive(false);
    }

    private IEnumerator prompt7Wait()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("Game");
    }
}
