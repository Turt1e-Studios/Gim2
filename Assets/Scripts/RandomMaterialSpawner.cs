using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterialSpawner : MonoBehaviour
{
    // not going to mess with this since it isn't working yet
    public GameObject matV1;
   
    public int r;
    


    // Start is called before the first frame update
    public void Start()
    {
        GameObject[] listOfPos = GameObject.FindGameObjectsWithTag("mspawn");

        for (int i = 0; i < 3; i++)
        {
            r = Random.Range(0, 10);
            var position = listOfPos[r].transform.position;
            Instantiate(matV1, position, Quaternion.identity);
            
        }

       
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
