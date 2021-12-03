using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float thrust;
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
       

            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                StartCoroutine(KnockCo(enemy));
            }

            
        

    }
    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            Vector2 forceDirection = enemy.transform.position - transform.position;
            Vector2 force = forceDirection.normalized * thrust;

            enemy.velocity = force;
            yield return new WaitForSeconds(.3f);

            enemy.velocity = new Vector2();
        }

    }



}

