using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Quiztaxdeduction : MonoBehaviour
{
    public GameObject player;
    public bool isCorrect;
    public static bool playerDie;

    [SerializeField] public GameObject overtime;


    private void Start()
    {
       

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (CollisionCheckForPlayer.taxdeducquiz)
        {
            if (isCorrect)
            {
                Debug.Log("Correct");
                CollisionCheckForPlayer.taxdeducquiz = false;
            }
            else
            {
                ReSpawn.readyDie = true;
                Destroy(player);

            }
        }
        if (CollisionCheckForPlayer.overtimeActive)
        {
            overtime.GetComponent<BoxCollider2D>().enabled = false;
        }






    }

}

