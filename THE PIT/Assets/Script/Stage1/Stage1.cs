using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[SerializeField]
public class Stage1 : MonoBehaviour
{
    public GameObject player;
    public bool check;
    public static bool showRespawn;

    private ReSpawn respawn;

    private void Start(){
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (check)
        {
            Debug.Log("Correct");
        }
        else
        {
            ReSpawn.readyDie = true;
            Destroy(player);
        }

    } 

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("Out Stage 1");
 

    //}

   
}
