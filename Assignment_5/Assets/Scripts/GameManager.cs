using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //variables
    public GameObject evacText;
    public GameObject evacZone;
    public GameObject evacArrow;

    // Start is called before the first frame update
    void Start()
    {
        //set up
        evacText.SetActive(false);
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
        evacText.SetActive(true);
        evacZone.SetActive(true);
        evacArrow.SetActive(true);
    }
}
