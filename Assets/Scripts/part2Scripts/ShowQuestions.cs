using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowQuestions : MonoBehaviour
{
    public TextMeshProUGUI quuestText;
    public TextMeshProUGUI answerATxt;
    public TextMeshProUGUI answerBTxt;
    public TextMeshProUGUI answerCTxt;
    public TextMeshProUGUI answerDTxt;
    // Start is called before the first frame update
    private void SetUI(QuestionHolder i)
    {
        quuestText.text = i.question;
        answerATxt.text = i.answerA;
        answerBTxt.text = i.answerB;
        answerCTxt.text = i.answerC;
        answerDTxt.text = i.answerD;
    }
    public void GetNewRandomQuestion()
    {
        SetUI(Database.GetRandomQuestion());
    }

}
