/*
    * Jacob Cohen
    * BadGuyFactory.cs
    * Assignment #5
    * sets which type of badGuy to use
*/

using UnityEngine;

public class BadGuyFactory : MonoBehaviour 
{
    //main function that choose which badguy to make
    public GameObject CreateBadGuy(string badGuyType, GameObject badGuy)
    {

        //check
        switch(badGuyType)
        {
            case "walker":
                badGuy.AddComponent<Walker>();
                break;

            case "runner":
                badGuy.AddComponent<Runner>();
                break;
            case "heavy":
                badGuy.AddComponent<Heavy>();
                break;

            default:
            Debug.Log("no bad guy type found for: " + badGuyType);
            break;
        }

        //done
        return badGuy;
    }
}