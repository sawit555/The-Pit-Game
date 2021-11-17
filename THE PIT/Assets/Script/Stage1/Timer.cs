using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public class Timer : MonoBehaviour
{
    public int currectQuestion;
    public float timeLeft = 5f;
    public static bool loopCheck;
    public static bool activeCheck;


    public Text txtShow;
    public GameObject txtDisplay;
    public GameObject player;

    public List<txtGenerator> txtQ;


    public Timer instance;

    private void Awake(){
        instance = this;
    }
    private void Start()
    {
        txtDisplay.SetActive(false);
        txtDisplay.GetComponent<Text>().text = "" + timeLeft;
    }

    void Update()
    {
       
        if (CollisionCheckForPlayer.timerActive)
        {
            timeStart();
            if(CollisionCheckForPlayer.overtimeActive)
            {
                OverTime();
                CollisionCheckForPlayer.overtimeActive = false;
            }
        }

        if(timeLeft == 0)
        {
            ReSpawn.readyDie = true;
            Destroy(player);
            timeLeft = 5;
        }

    }

    IEnumerator takeTime() //ตัวจับเวลา
    {
        loopCheck = true;
        yield return new WaitForSeconds(1);
        timeLeft -= 1;
        txtDisplay.GetComponent<Text>().text = "" + timeLeft;
        print("Loop2");
        loopCheck = false;
    }

    public void timeStart() //เริ่มนับถอยหลังเวลา
    {
        txtDisplay.SetActive(true);
        if (timeLeft > 0 && loopCheck == false)
        {
            StartCoroutine(takeTime());
            print("Loop1");
        }
    }

    public void OverTime() //ต่อเวลา
    {
        timeLeft = 6f;
        return;

    }

 

 




}
