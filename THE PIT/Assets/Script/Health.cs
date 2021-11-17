using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healtBar;
    public float healtAmount = 100;

    //public Slider healthslider;
    //public float Maxhealth;
    //public static float currenthealth;
    // Start is called before the first frame update
    void Start()
    {
        //currenthealth = Maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (healtAmount == 0)
            {
                return;
            }
            else
            {
                takedamage(20);

            }

        }

        //healthslider.value = currenthealth / Maxhealth;
    }

    public void takedamage(float damage)
    {
        healtAmount -= damage;
        healtBar.fillAmount = healtAmount / 100;
        Debug.Log("Hit Player");
    }


}
