using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{

    public Stage1Puz[] bridge;
    private static List<Stage1Puz> bridgecheck;
    Stage1Puz Correct;
    int currect;
    public void correctChoice()
    {
      

    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < bridge.Length; i++)
        {
            print(bridge[i].isCorrect);
            if (bridge[currect].isCorrect == 1)
            {
                print("Correct");
            }
        }
        print("Kuy 1");
    }
}

