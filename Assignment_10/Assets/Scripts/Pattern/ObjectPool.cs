/*
    * Jacob Cohen
    * MenuController.cs
    * Assignment #10
    * controls the objectpool for the pattern
*/

using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //variables
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    //singleton code
    #region 
    public static ObjectPool instance;
    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }    
    }
    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        Fill();
    }

    private void Fill()
    {
        //fill all pools with items
        foreach (Pool item in pools)
        {
            //holder
            Queue<GameObject> objectPool = new Queue<GameObject>();

            //prefabs
            for(int i = 0; i < item.size; i++)
            {
                //spawn
                GameObject current = Instantiate(item.enemy);

                //set inactive
                current.SetActive(false);

                //add to queue
                objectPool.Enqueue(current);
            }
            //add to dictionary
            poolDictionary.Add(item.type, objectPool);
        }
    }

    public GameObject Spawn(string inputType, Vector3 spawnPoint)
    {
        //check
        if(!poolDictionary.ContainsKey(inputType))
        {
            return null;
        }

        //remove from queue
        GameObject holder = poolDictionary[inputType].Dequeue();

        //activate
        holder.SetActive(true);

        //move to spawn location
        holder.transform.position = spawnPoint;

        //done
        return holder;
    }

    public void Dead(string inputType, GameObject inputObject)
    {
        //turn off
        inputObject.SetActive(false);

        //add to queue
        poolDictionary[inputType].Enqueue(inputObject);
    }
}
