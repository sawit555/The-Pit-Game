using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overtimer : MonoBehaviour
{
    public static bool isActive;
    public GameObject overTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isActive = true;
        overTime.GetComponent<BoxCollider2D>().enabled = false;
        
    }

}
