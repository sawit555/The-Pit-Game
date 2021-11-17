using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plusnumber : MonoBehaviour
{
    int number = 10;
    int show;
    public bool isAcive;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(show);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        for (int i = 0; i < number; i++)
        {
            show += 1;
        }


    }

    IEnumerator Plusup()
    {
        yield return new WaitForSeconds(1);
     
        

    }
}
