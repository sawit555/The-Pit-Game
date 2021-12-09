using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveText : MonoBehaviour
{
    
    //public GameObject txtObject;

    bool playerinrange = false;
    // Start is called before the first frame update
    void Start()
    {
        //txtObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(CollisionCheckForPlayer.signActive && Input.GetKeyDown(KeyCode.Z))
        {
            PlayerMovement.instance.ShowNote();
            Debug.Log("2");
        }
        if(CollisionCheckForPlayer.signActive == false)
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
    
            playerinrange = true;
            Debug.Log("INRANGE");
        
    }
}
