/*
    * Jacob Cohen
    * GameManager.cs
    * Assignment #5
    * Controls the timer
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //variables
    public Text evacText;
    public GameObject evacZone;
    public GameObject evacArrow;

    // Start is called before the first frame update
    void Start()
    {
        //set up
        evacZone.SetActive(false);
        evacArrow.SetActive(false);

        //wait
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        //wait for 30 seconds
        yield return new WaitForSecondsRealtime(15);

        //evac
        evacText.text = "Evac Available";
        evacZone.SetActive(true);
        evacArrow.SetActive(true);
    }
}
