using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Stage3Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject text;
    public GameObject door;
    public GameObject stage3Group;
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SlotScript.check && SlotScript2.check && SlotScript3.check && SlotScript4.check && SlotScript5.check && SlotScript6.check)
        {
            text.SetActive(true);
            StartCoroutine(Delay());
         
        }
        else
        {
            text.SetActive(false);
        }
    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        door.SetActive(false);
        stage3Group.SetActive(false);

    }
}
