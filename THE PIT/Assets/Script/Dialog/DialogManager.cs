using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[SerializeField]
public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public static bool rangeCheck;
  
    private void Start()
    {
        rangeCheck = false;
        dialogBox.SetActive(false);
    }

    public void Update()
    {
        if (rangeCheck)
        {
            dialogBox.SetActive(true);
        }
        else
        {
            dialogBox.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        rangeCheck = true;
        Debug.Log("Player Enter");
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        rangeCheck = false;
    }



































































    Text dialogText;
    [SerializeField] int letterPerSecond;
    
    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public void ShowDialog(Dialog2 dialog)
    {
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    public IEnumerator TypeDialog(string lines)
    {
        dialogText.text = "";
        foreach(var letter in lines.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSecond);
        }
    }
}
