using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerPath : MonoBehaviour
{
    public bool isCorrect = false;
    public StageManager quizManager;
    public EnemyHP bossHp;
    public Health playerHp;


    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.correct();
            bossHp.takedamage(10);
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager.wrong();
            playerHp.takedamage(35);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Answer();
        }
       
    }
}
