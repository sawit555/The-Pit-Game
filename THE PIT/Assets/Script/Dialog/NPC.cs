using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC : MonoBehaviour
{
    public Dialogues trigger;
    public CanvasGroup dialogBox;
    public GameObject TestDialogue;
    private bool playerRange = false;
    private bool isActive = false;

    public static NPC instance { get => _instance; set => instance = value; }
    private static NPC _instance;



    void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        //dialogBox.alpha = 0;
        TestDialogue.SetActive(false);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && playerRange == true)
        {
            isActive = true;
            if(isActive)
            {
                TestDialogue.SetActive(true);
                trigger.StartDialogue();
                return;
            }
            else
            {
                TestDialogue.SetActive(false);
            }
          
           
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerRange = true;
        print("Enter");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerRange = false;
        isActive = false;

    }



    public void alphaSet()
    {
        TestDialogue.SetActive(false);
    }

}
