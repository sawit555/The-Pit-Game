using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangSprite : MonoBehaviour
{
    public Sprite sp1,sp2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().sprite = sp1;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().sprite = sp2;
    }
}
