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

    public float thrust;
    public float knockTime;
    Rigidbody2D rd;
    Timer timer;
    private Transform player;

    private void Start()
    {
       
    }
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

        if(other.gameObject.tag == "Enemy")
        {
            Rigidbody2D enemy = GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                enemy.isKinematic = false;
                Vector2 difference = transform.position - other.transform.position;
                difference = difference.normalized * thrust;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemy));  
            }

        }

    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if(enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.isKinematic = true;
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
