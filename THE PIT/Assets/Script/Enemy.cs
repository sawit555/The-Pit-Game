using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
}
public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public string enemyName;
    public int maxHp;
    public float speed;

    public Transform attackPoint;
    public float attackSpeed;
    public float attackDamage;
    private float canAttack;
    int currentHP;

    private Vector3 startingPosition;
    private Vector3 roamPosition;
    

    // Start is called before the first frame update
    void Awake()
    {
        currentHP = maxHp;
        
    }


    public void takeDamage(int damage)
    {
        //Do Damage to Enemy
        currentHP -= damage;

        if(currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        Debug.Log("Die");
        this.gameObject.SetActive(false);
    }

   

    

}
