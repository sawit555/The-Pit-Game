using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    walk,   attack, interact
}
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public bool isActive;

    public PlayerState currectstate;
    public Animator animator;
    private Rigidbody2D rd;
    private Vector3 change;

    public VectorValue startPosition;
    public GameObject Note;

    

    public static PlayerMovement instance;

    SavePosPlayer playerPosData;
    private void Awake()
    {
        instance = this;
        //playerPosData = FindObjectOfType<SavePosPlayer>();
        //playerPosData.PlayerPosLoad();

    }

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        transform.position = startPosition.initialValue;
    }

    void Update()
    {
        if (DialogueManager.isActive == true)
            return;

        //change.x = Input.GetAxisRaw("Horizontal");
        //change.y = Input.GetAxisRaw("Vertical");

        //animator.SetFloat("Horizontal", change.x);
        //animator.SetFloat("Vertical", change.y);
        //animator.SetFloat("Speed", change.sqrMagnitude);

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.F) && currectstate != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
        if(currectstate == PlayerState.walk)
        {
            UpdateAnimationAndMove();

        }

    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currectstate = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.33f);
        currectstate = PlayerState.walk;

        
    }

    //void FixedUpdate()
    //{
    //    rd.MovePosition(rd.position + change * speed * Time.fixedDeltaTime
    //        );
    //}

    public void ShowNote()  
    {
        Note.SetActive(true);
        isActive = true;
    }
    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("Horizontal", change.x);
            animator.SetFloat("Vertical", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        rd.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }
}

