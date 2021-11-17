using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuestionS> QnA;
    public GameObject[] options;
    public int currectQuestion;

  
    public GameObject Quizpanel;
    public GameObject GoPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;

    int total = 0;
    public int score;

    private void Start()
    {
        total = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
        
    }
    public void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + total;
    }
    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currectQuestion);
        generateQuestion();
    }
    public void wrong()
    {
        QnA.RemoveAt(currectQuestion);
        generateQuestion();
    }
    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currectQuestion].Answers[i];
            if(QnA[currectQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count>0)
        {
            currectQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currectQuestion].Question;
            SetAnswers();
        }

        else
        {
            Debug.Log("Out OF Question");
            GameOver();
        }
       

        
    }


}
