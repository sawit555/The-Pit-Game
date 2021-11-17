using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundbox;

    Message[] currentMessage;
    Actor[] currentActor;
    int activeMessage = 0;
    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessage = messages;
        currentActor = actors;
        activeMessage = 0;
        isActive = true;
        Debug.Log("Loading" + messages.Length);
        DisplayMessage();
    }
    void DisplayMessage()
    {
        Message messageToDisplay = currentMessage[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActor[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

    }
    public void NextMessage()
    {
        activeMessage++;
        if(activeMessage < currentMessage.Length)
        {
            DisplayMessage();

        }
        else
        {
            isActive = false;
            NPC.instance.alphaSet();
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
            return;

        }
    }
}
