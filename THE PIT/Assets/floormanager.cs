using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floormanager : MonoBehaviour
{
    Switch sw;
    Switch2 sw2;
    public GameObject tree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Switch.turnonsw && Switch2.turnonsw2)
        {
            Debug.Log("Open");
            tree.SetActive(false);
        }
    }
}
