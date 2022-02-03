using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healtBar;
    public float healtAmount = 100;
    public bool hp0 = false;

    //public Slider healthslider;
    //public float Maxhealth;
    //public static float currenthealth;
    // Start is called before the first frame update
    ReSpawn respawn;
    Health instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //currenthealth = Maxhealth;
    }

    // Update is called once per framek
    void Update()
    {
      
            if (healtAmount == 0)
            {
                ReSpawn.readyDie = true;
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
