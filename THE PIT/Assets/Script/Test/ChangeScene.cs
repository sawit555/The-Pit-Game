using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    [SerializeField] bool range;
    [SerializeField] string sceneName;
    [SerializeField] private GameObject npc;
    [SerializeField] private GameObject Wall;
    [SerializeField]
    private GameObject text;
    private void Start()
    {
        npc.SetActive(false);
        text.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && range)
        {
            Time.timeScale = 0;
            npc.SetActive(true);
        }

        if (SlotScript.check && SlotScript2.check && SlotScript3.check && SlotScript4.check && SlotScript5.check && SlotScript6.check)
        {
            text.SetActive(true);
            Time.timeScale = 1;
            npc.SetActive(false);
            Wall.SetActive(false);

        }
        else
        {
            text.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            npc.SetActive(false);
        }


    }
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            print("Test Enter");
            range = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            print("Test Enter");
            range = false;
            npc.SetActive(false);
        }
    }
}
