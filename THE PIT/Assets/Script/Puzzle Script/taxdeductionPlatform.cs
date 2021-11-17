using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taxdeductionPlatform : MonoBehaviour
{
    public GameObject txtQ;
    //public GameObject lefttxtAns;
    //public GameObject righttxtAns;
    // Start is called before the first frame update
    void Start()
    {
        txtQ.SetActive(false);
        //lefttxtAns.SetActive(false);
        //righttxtAns.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!CollisionCheckForPlayer.txtquiz)
        {
            txtQ.SetActive(false);
            //lefttxtAns.SetActive(false);
            //righttxtAns.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CollisionCheckForPlayer.txtquiz)
        {
            //lefttxtAns.SetActive(true);
            //righttxtAns.SetActive(true);
            txtQ.SetActive(true);
            print("This is txtShow");
        }
    }
}
