using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{   
    [SerializeField]
    Text codeText;
    string codeTextValue = "";
    


    private void Start()
    {
        
    }

    void Update()
    {
        codeText.text = codeTextValue;

        if (codeTextValue == "60000")
        { 
            //Password.barrierOpen = true;
        }


        if (codeTextValue.Length >= 5)
        {
            codeTextValue = "";
        }

    }

    public void AddDigit (string digit)
    {
        codeTextValue += digit;
    }

   
}
