/*
    * Jacob Cohen
    * FriendlyCharacter.cs
    * Assignment #6
    * creates an friendly
*/

using UnityEngine;

public class FriendlyCharacter : CharacterCreator
{
    //var
    private GameObject prefab;

    public override GameObject CreateCharacter(string type)
    {
        switch (type)
        {
            case "runner":
                //spawn runner
                prefab = Resources.Load<GameObject>("Runner");
                break;
            case "walker":
                //spawn walker
                prefab = Resources.Load<GameObject>("Walker");
                break;
            default:
                Debug.Log("there is an issue");
                break;
        }

        //done
        return prefab;
    }
}