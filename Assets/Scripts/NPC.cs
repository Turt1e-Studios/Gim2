using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private float radius = 5;
    [SerializeField] private string text;
    [SerializeField] private TextMeshProUGUI textMesh;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (Vector3.Distance(transform.position, player.transform.position) < radius)
            {
                textMesh.text = text;
            }
        }
        else
        {
            textMesh.text = "";
        }
    }
}
