using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float stopRadius;
    public float attackRadius;
    public Transform homePosition;

    public float attackSpeed;
    public float attackDamage;
    float canAttack;
    public Rigidbody2D rd;
    //public Animator anima;

    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.FindWithTag("Player").transform;
        rd = GetComponent<Rigidbody2D>();
        //anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        checkDistance();
    }

    void checkDistance()
    {
        if (Vector3.Distance(target.position, transform.position)  <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
      
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);                                    
        }
    

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canAttack = attackSpeed;
            if (attackSpeed <= canAttack)
            {

                other.gameObject.GetComponent<Health>().takedamage(attackDamage);
                canAttack = 0f;
                Debug.Log("Attack");
                
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
        
    }
  
}
