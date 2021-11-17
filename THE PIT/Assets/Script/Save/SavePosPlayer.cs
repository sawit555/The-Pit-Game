using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class SavePosPlayer : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        if(PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
        {
            float playerX = player.transform.position.x;
            float playerY = player.transform.position.y;

            playerX = PlayerPrefs.GetFloat("pX");
            playerY = PlayerPrefs.GetFloat("pY");

            player.transform.position = new Vector2(playerX, playerY);

            PlayerPrefs.SetInt("TimeToLoad", 0);
            PlayerPrefs.Save();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerPosSave()
    {
        PlayerPrefs.SetFloat("pX", player.transform.position.x);
        PlayerPrefs.SetFloat("pY", player.transform.position.y);
        PlayerPrefs.SetInt("Saved", 1);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetFloat("pX"));
    }

    public void PlayerPosLoad()
    {
        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
    }
}
