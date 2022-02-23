using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2 : MonoBehaviour
{
    public Animator ani;
    bool playerinr;
    public static bool turnonsw2;


    Switch2 instance;

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

            if (playerinr && Input.GetKeyDown(KeyCode.Z))
            {
                    turnonsw2 = true;
                    Debug.Log("turnonsw2");
            }

        


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            playerinr = true;
            Debug.Log("Enyer2");
        }
    }
}
