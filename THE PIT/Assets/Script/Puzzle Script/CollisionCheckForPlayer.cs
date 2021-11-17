using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionCheckForPlayer : MonoBehaviour
{
    public static bool taxdeducquiz = false;
    public static bool txtquiz = false;
    public static bool timerActive = false;
    public static bool overtimeActive = false;
    public static bool stage3Active = false;

    Timer timer;
 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "txtShow")
        {
            txtquiz = true;
            print("This is txtShow");

        }

        if (other.gameObject.tag == "Platform")
        {
            taxdeducquiz = true;
            print("This is Platform");

        }

        if (other.gameObject.tag == "Timer")
        {
            timerActive = true;

        }

        if (other.gameObject.tag == "OvertimePlatform")
        {
            overtimeActive = true;
        }

        if(other.gameObject.tag == "Door")
        {
            stage3Active = true;
            print("Stage3 Enter");
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "txtShow")
        {
            txtquiz = false;
            print("This is txtShow");

        }
        if (other.gameObject.tag == "Door")
        {
            stage3Active = false;
            print("Stage3 Out");
        }

    }
}
