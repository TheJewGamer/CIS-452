/*
    * Jacob Cohen
    * TeleporterManager.cs
    * Assignment #7
    * controls placing down a teleporter
*/

using UnityEngine;

public class TeleporterManager : MonoBehaviour 
{
    public GameObject player;

    public GameObject PlaceTeleporter()
    {
        //var
        GameObject prefab = Resources.Load<GameObject>("teleporter");

        //spawn at players location
        prefab = Instantiate(prefab, player.transform.position, player.transform.rotation);

        //done
        return prefab;
    }    
}