using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<GameObject> pooledObjectsFood;
    public GameObject objectToPoolFood;
    public int amountToPool;
    public List<GameObject> pooledObjectsBomb;
    public GameObject objectToPoolBomb;


    void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
                // Loop through list of pooled objects,deactivating them and adding them to the list 
        pooledObjectsFood = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPoolFood);
            obj.SetActive(false);
            pooledObjectsFood.Add(obj);
            obj.transform.SetParent(this.transform); // set as children of Spawn Manager
        }

               // Loop through list of pooled objects,deactivating them and adding them to the list 
        pooledObjectsBomb = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPoolBomb);
            obj.SetActive(false);
            pooledObjectsBomb.Add(obj);
            obj.transform.SetParent(this.transform); // set as children of Spawn Manager
        }
    }

        public GameObject GetPooledObjectFood()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < pooledObjectsFood.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!pooledObjectsFood[i].activeInHierarchy)
            {
                return pooledObjectsFood[i];
            }
        }
        // otherwise, return null   
        return null;
    }

        public GameObject GetPooledObjectBomb()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < pooledObjectsBomb.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!pooledObjectsBomb[i].activeInHierarchy)
            {
                return pooledObjectsBomb[i];
            }
        }
        // otherwise, return null   
        return null;
    }
}
