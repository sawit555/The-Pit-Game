using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CanvasGroup dialogBox;
    public static GameManager instance { get => _instance; set => instance = value; }
    private static GameManager _instance;

    

    void Awake()
    {
        _instance = this;
    }
    public void alphaSet()
    {
        dialogBox.alpha = 0;
    }
}
