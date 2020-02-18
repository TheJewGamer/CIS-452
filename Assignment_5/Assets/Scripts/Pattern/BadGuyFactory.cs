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
    public BadGuy CreateBadGuy(string type)
    {
        BadGuy badGuy = null;

        //check
        switch(type)
        {
            case "walker":
                badGuy = new Walker();
                break;

            case "runner":
                badGuy = new Runner(); 
                break;

            default:
            Debug.Log("no badguy type found for: " + type);
            break;
        }

        //done
        return badGuy;
    }
}