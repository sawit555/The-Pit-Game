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


        if (other.gameObject.tag == "Player")
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                //enemy.isKinematic = false;
                //Vector2 difference = transform.position - other.transform.position;
                //difference = difference.normalized * thrust;
                //enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemy));

            }

        }

    }
    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            //yield return new WaitForSeconds(knockTime);
            //enemy.velocity = Vector2.zero;
            //enemy.isKinematic = true;

            Vector2 forceDirection = enemy.transform.position - transform.position;
            Vector2 force = forceDirection.normalized * thrust;

            enemy.velocity = force;
            yield return new WaitForSeconds(.3f);

            enemy.velocity = new Vector2();
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
}
