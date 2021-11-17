using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TaxpercentQuiz : MonoBehaviour
{

    public GameObject stage3Group;
    void Start()
    {
        stage3Group.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (CollisionCheckForPlayer.stage3Active && Input.GetKeyDown(KeyCode.Z))
        {
            if(stage3Group != null)
            {
                bool isAtive = stage3Group.activeSelf;
                stage3Group.SetActive(!isAtive);
            }
            
        }
        else if(!CollisionCheckForPlayer.stage3Active)
        {
            stage3Group.SetActive(false);
        }
    }

}

