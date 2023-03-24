using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
 * To be implemented
 */

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler sharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    [SerializeField] private int amountToPool;

    private void Awake()
    {
        sharedInstance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Loop through list of pooled objects,deactivating them and adding them to the list 
        pooledObjects = new List<GameObject>();
        for (var i = 0; i < amountToPool; i++)
        {
            var obj = Instantiate(objectToPool, transform, true);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        // For as many objects as are in the pooledObjects list, if the pooled objects is NOT active, return that object, otherwise return null
        return pooledObjects.FirstOrDefault(t => !t.activeInHierarchy);
    }
}
