using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlassesButton : MonoBehaviour
{
    //variable
    private GameObject defaultText;
    private GameObject statText;

    // Start is called before the first frame update
    void Start()
    {
        //set vars
        defaultText = this.gameObject.transform.Find("Text").gameObject;
        statText = this.gameObject.transform.Find("Stats").gameObject;

        //set up button
        defaultText.SetActive(true);
        statText.SetActive(false);
    }

    public void ButtonOver()
    {
        Debug.Log("hell");

        //change text
        defaultText.SetActive(false);
        statText.SetActive(true);
    }

    public void ButtonLeft()
    {
        //change text
        defaultText.SetActive(true);
        statText.SetActive(false);
    }

    
}
