using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[SerializeField]
public class ReSpawn : MonoBehaviour
{
    public CanvasGroup myGroup;
    public string sceneName;

    public static bool readyDie = false;
    public ReSpawn instance;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        PlayerRespawn();
        //if (Quiztaxdeduction.playerDie)
        //{
        //    if (myGroup.alpha < 1)
        //    {
        //        myGroup.alpha += Time.deltaTime;
        //        {
        //            if (myGroup.alpha >= 1)
        //            {
        //                Quiztaxdeduction.playerDie = false;
        //                CollisionCheckForPlayer.timerActive = false;
        //                CollisionCheckForPlayer.overtimeActive = false;
        //                CollisionCheckForPlayer.taxdeducquiz = false;
        //            }
        //        }
        //    }
        //}
    }

    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // loads current scene
        if (readyDie)
        {
            readyDie = false;
        }

    }

    public void PlayerRespawn()
    {
        if (readyDie)
        {
            Quiztaxdeduction.playerDie = false;
            CollisionCheckForPlayer.timerActive = false;
            CollisionCheckForPlayer.overtimeActive = false;
            CollisionCheckForPlayer.taxdeducquiz = false;
            if (myGroup.alpha < 1)
            {
                myGroup.alpha += Time.deltaTime;
                
                if (myGroup.alpha >= 1)
                {
                   

                }

            }
        }
    }
}
