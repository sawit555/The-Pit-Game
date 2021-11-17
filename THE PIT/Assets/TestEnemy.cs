using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float stopRadius;
    public float attackRadius;
    private float canAttack;
    public Transform homePosition;


    public Rigidbody2D rd;
    public Animator anima;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        currentState = EnemyState.idle;
        rd = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        attackDistance();
        checkDistance();
    }

    void checkDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if(currentState == EnemyState.idle || currentState == EnemyState.walk)
            {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            rd.MovePosition(temp);
            changeAnim(temp - transform.position);
            ChangState(EnemyState.walk);
            anima.SetBool("walk", true);    

            }
            
  
        }

        else
        {
            anima.SetBool("walk", false);
        }
        
    }

    public void attackDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= attackRadius)
        {

            if (currentState == EnemyState.idle || currentState == EnemyState.walk)
            {
                if(attackSpeed <= canAttack)
                {
                    ChangState(EnemyState.attack);
                    if(currentState == EnemyState.attack)
                    {
                        anima.SetBool("attack", true);
                        currentState = EnemyState.idle;
                    }
               
                    canAttack = 0f;
                    anima.SetBool("walk", false);
                    
                }
                else
                {
                    canAttack += Time.deltaTime;
                }
            }
        }
        else
        {
            ChangState(EnemyState.walk);
            anima.SetBool("attack", false);
        }

    }
    private void ChangState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }

    private void SetAnimFloat(Vector2 setVector)
    {
        anima.SetFloat("moveX", setVector.x);
        anima.SetFloat("moveY", setVector.y);
    }
    private void changeAnim(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if(direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);
    }

  
}
