using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCountDown : MonoBehaviour
{   
    public static bool isActive ;
    private Timer timer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        isActive = true;

    }   


}


