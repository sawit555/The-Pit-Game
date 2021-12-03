using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testscripy : MonoBehaviour
{
    public GameObject[] test;
    public int enemyCount;
    public GameObject some;
    bool isCount = false;
    void Start()
    {
        some.SetActive(true);
       
    }

    // Update is called once per frame
    void Update()
    {
        test = GameObject.FindGameObjectsWithTag("EnemyQ1");
        enemyCount = test.Length;

        if(enemyCount <= 0)
        {
            Debug.Log("Congrat1");
            isCount = true;
            if (isCount)
            {
                some.SetActive(false);
                Debug.Log("Congrat");
            }
        }
        else
        {

            isCount = true;
        }
    }
}
