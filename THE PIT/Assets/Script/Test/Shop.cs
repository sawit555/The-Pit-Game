using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject player;
    public bool playerinrange;

    void Start()
    {
        shopUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && playerinrange)
        {
            if (shopUI.activeInHierarchy)
            {
                shopUI.SetActive(false);
                Time.timeScale = 1;


            }
            else
            {
                shopUI.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            print("Test Enter");
            playerinrange = true;


        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            print("Test Enter");
            playerinrange = false;



        }
    }
    

}
