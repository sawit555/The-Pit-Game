using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Animator ani;

    bool playerinrange;
    public static bool turnonsw;


    Switch instance;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (playerinrange)
            {
                ani.SetBool("trigger", true);
                turnonsw = true;
                Debug.Log("turnonsw1");
            }
 
        }

     
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
           
                playerinrange = true;
                Debug.Log("Enyer1");


        }
    }
}
