using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Close : MonoBehaviour
{
    public GameObject panel;

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
