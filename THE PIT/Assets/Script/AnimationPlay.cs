using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationPlay : MonoBehaviour
{
    [SerializeField] GameObject Cutscene;


    private void Start()
    {
        Cutscene.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cutscene.SetActive(true);
    }
}
