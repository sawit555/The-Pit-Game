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

    public Rigidbody2D rd;
    //public Animator anima;

    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.FindWithTag("Player").transform;
        currentState = EnemyState.idle;
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
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

                rd.MovePosition(temp);
                //changeAnim(temp - transform.position);
                //ChangState(EnemyState.walk);
                //anima.SetBool("walk", true);

            }

        }
        //else
        //{
        //    anima.SetBool("walk", false);
        //}

    }
}
