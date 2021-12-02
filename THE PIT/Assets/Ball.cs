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

    public float thrust;
    public float knockTime;

    public float attackSpeed;
    public float attackDamage;
    float canAttack;

    public Rigidbody2D rd;
    public Animator anima;
    //public Animator anima;

    // Start is called before the first frame update
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
                changeAnim(temp - transform.position);
                ChangState(EnemyState.walk);
                anima.SetBool("walk", true);
            }
        
            else
        {
                ChangState(EnemyState.idle);
                anima.SetBool("walk", false);
        }
    }


    }

    private void ChangState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
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


        if (other.gameObject.tag == "Player")
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                StartCoroutine(KnockCo(enemy));
            }

        }

    }
   
    private void SetAnimFloat(Vector2 setVector)
    {
        anima.SetFloat("moveX", setVector.x);
        anima.SetFloat("moveY", setVector.y);
    }
    private void changeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
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
