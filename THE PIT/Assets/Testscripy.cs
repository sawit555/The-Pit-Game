using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testscripy : MonoBehaviour
{
    public GameObject[] test;
    public GameObject[] dummy;
    public GameObject some;
    public GameObject player;
    public int enemyCount;
    public int dummyCount;
    public int dummyCountUpdate;
    bool isCount = false;


    private ReSpawn respawn;
    void Start()
    {
        test = GameObject.FindGameObjectsWithTag("EnemyQ1");
        dummy = GameObject.FindGameObjectsWithTag("Enemy");
        some.SetActive(true);
        dummyCount = dummy.Length;


    }
    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        test = GameObject.FindGameObjectsWithTag("EnemyQ1");
        dummy = GameObject.FindGameObjectsWithTag("Enemy");
        dummyCountUpdate = dummy.Length;
        enemyCount = test.Length;

        if (enemyCount <= 0)
        {
            Debug.Log("Congrat1");
            isCount = true;
            if (isCount)
            {
                some.SetActive(false);
                Debug.Log("Congrat");
            }
        }
        if(dummyCountUpdate < dummyCount)
        {
            ReSpawn.readyDie = true;
            Debug.Log("Wrong Enemy");
            player.SetActive(false);
        }
        else
        {
            ReSpawn.readyDie = false;
            isCount = true;
        }
    }
}
