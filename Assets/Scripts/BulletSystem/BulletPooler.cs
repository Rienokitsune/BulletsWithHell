using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BulletPooler : MonoBehaviour
{


public static BulletPooler pooler;
[SerializeField] public Transform _Dynamic;
[SerializeField] BulletPools poolLists;


public bool expandable;
[ShowInInspector][ReadOnly]List<Pool> pools;
public Dictionary<string, Queue<GameObject>> poolDictionary;

private void Awake()
{
    pools = poolLists.getPools();
    pooler = this;
}

void Start()
{

    poolDictionary = new Dictionary<string, Queue<GameObject>>();
    foreach (Pool pool in pools)
    {
        Queue<GameObject> objectPool = new Queue<GameObject>();
        for (int i = 0; i < pool.size; i++)
        {
            GameObject obj = (GameObject)Instantiate(pool.prefab);
            obj.transform.SetParent(_Dynamic);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }

        poolDictionary.Add(pool.ID, objectPool);
        Debug.Log("Pool ID" + pool.ID + "has been added");
    }


}

public GameObject getPooledObject(string ID)
{
    if (poolDictionary[ID].Count == 0 && expandable == true)
    {
        foreach (Pool pool in pools)
        {
            if (pool.ID == ID)
            {
                GameObject bulletObj = (GameObject)Instantiate(pool.prefab);
                bulletObj.transform.SetParent(_Dynamic);
                bulletObj.SetActive(false);
                return bulletObj;
            }

        }

    }
    GameObject obj = poolDictionary[ID].Dequeue();
    return obj;


}

   
}
