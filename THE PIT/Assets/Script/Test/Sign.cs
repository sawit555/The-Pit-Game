using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerinrange;
    [SerializeField] Dialogs dialogs;

 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerinrange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);

            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
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
        int layerId = LayerMask.NameToLayer("Player");

        if (other.gameObject.layer == layerId)
        {
            print("Test Out");
            playerinrange = false;
            dialogBox.SetActive(false);


        }
    }
}
