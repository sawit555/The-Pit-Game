using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialogs : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;


    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }
    public void ShowDialog(Dialogs dialog)
    {
        dialogBox.SetActive(true);

    }
    private void Update()
    {
        if (DialogManager.rangeCheck && Input.GetKeyDown(KeyCode.Z))
        {
            

            if (Input.GetKeyDown(KeyCode.Z))
            {

                if (textComponent.text == lines[index])
                {

                    NextLine();

                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }
        else if(!DialogManager.rangeCheck)
                {
            index = 0;
            print(index);
        }
           
        
    }
     void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
