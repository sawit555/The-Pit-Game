using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    int playerDamage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag == "Enemy")
        {
            Enemy enemyHp;
            enemyHp = other.gameObject.GetComponent<Enemy>();
            enemyHp.takeDamage(playerDamage);
            Debug.Log("Hit!!");
        }
    }
}   
