using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionDisplay : MonoBehaviour
{
    public GameObject screenQuestion;
    public GameObject answerA;
    public GameObject answerB;
    public GameObject answerC;
    public GameObject answerD;

    public static string newQuestion;
    public static string newAnswerA;
    public static string newAnswerB;
    public static string newAnswerC;
    public static string newAnswerD;

    public static bool pleaseUpdate = false;


    

    void Update()
    {
        if (pleaseUpdate == false)
        {
            pleaseUpdate = true;
            StartCoroutine(PushtextOnScreen());
        }
    }

    IEnumerator PushtextOnScreen()
    {
        yield return new WaitForSeconds(.5f);
        screenQuestion.GetComponent<TMP_Text>().text = newQuestion;
        answerA.GetComponent<TMP_Text>().text = newAnswerA;
        answerB.GetComponent<TMP_Text>().text = newAnswerB;
        answerC.GetComponent<TMP_Text>().text = newAnswerC;
        answerD.GetComponent<TMP_Text>().text = newAnswerD;
    }
}
