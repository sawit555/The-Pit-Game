using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    public Transform homePosition;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;

    public float attackSpeed;
    public float attackDamage;
    public float timer;

    public Rigidbody2D rd;
    public Animator anima;

    private bool cooling;
    private bool attack;
    private float intimer;


    private void Awake()
    {
        intimer = timer;
        anima = GetComponent<Animator>();
    }
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        currentState = EnemyState.idle;
        rd = GetComponent<Rigidbody2D>();
     
        attack = false;
        
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
            ChangState(EnemyState.idle);
            anima.SetBool("walk", false);
        }
        
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;
        Debug.Log("COOLDOWN");
        if (timer <= 0 && cooling && attack)
        {
            cooling = false;
            timer = intimer;
            Debug.Log("cooling = " + cooling);
        }
    }

    void Attack()
    {
        timer = intimer;
        attack = true;
        anima.SetBool("attack", true);
        anima.SetBool("walk", false);
        Debug.Log("BOOOOM");
        Debug.Log("Attack = " + attack);
  

    }

    public void attackDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= attackRadius)
        {
            Debug.Log("Test");
            ChangState(EnemyState.attack);
            if (currentState == EnemyState.attack && cooling == false)
            {
                Attack();

                Debug.Log("cooling = " + cooling);
                Debug.Log("Attack = " + attack);
                //TriggerCooling();
            }
            if (cooling)
            {
                Cooldown();
                anima.SetBool("attack", false);
            }
        }
        //canAttack = 0f;
        //anima.SetBool("walk", false);
        else
        {
            ChangState(EnemyState.walk);
            anima.SetBool("attack", false);
        }

    }

    //Change enemy state to newstate
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

    public void TriggerCooling()
    {
        cooling = true;
    }



}
