using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpManager : MonoBehaviour
{
    //variables
    public int points;
    private const int POINTS_GOAL = 100;
    public int livesLeft;
    public GameObject winMenu;
    public GameObject loseMenu;
    public Text pointsText;
    public Text livesText;
    public RedPickup[] redPickup;
    public GreenPickup[] greenPickup;

    private void Start() 
    {
        //update hud
        points = 0;
        livesLeft = 3;
        UpdateHud();  
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //red pickup
        if(other.gameObject.GetComponent<RedPickup>() != null)
        {
            other.GetComponent<RedPickup>().PickedUp(this);
            UpdateHud();
            PointCheck();
        }   
        else if(other.gameObject.GetComponent<GreenPickup>() != null)
        {
            other.GetComponent<GreenPickup>().PickedUp(this);
            UpdateHud();
            PointCheck();
        } 
    }

    private void LateUpdate() 
    {
        foreach(RedPickup item in redPickup)
        {   
            //check
            if(item != null)
            {
                item.Action();
            }
        }    

        foreach(GreenPickup item in greenPickup)
        {
            //check
            if(item != null)
            {
                item.Action();
            }
        }
    }

    private void PointCheck()
    {
        if(points >= POINTS_GOAL)
        {
            //win
            Time.timeScale = 0;
            winMenu.SetActive(true);
        }
        else if(livesLeft <= 0)
        {
            //lose
            Time.timeScale = 0;
            loseMenu.SetActive(true);
        }
    }

    private void UpdateHud()
    {
        pointsText.text = points.ToString();
        livesText.text = livesLeft.ToString();
    }
}
