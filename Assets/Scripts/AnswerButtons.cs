using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerButtons : MonoBehaviour
{
    public QuestionGenerator questionGenerator;

    public GameObject answerAbackBlue; //blue is hovering
    public GameObject answerAbackGreen; // green is correct
    public GameObject answerAbackRed; // Red is wrong
    public GameObject answerBbackBlue;
    public GameObject answerBbackGreen;
    public GameObject answerBbackRed;
    public GameObject answerCbackGreen;
    public GameObject answerCbackBlue;
    public GameObject answerCbackRed;
    public GameObject answerDbackGreen;
    public GameObject answerDbackBlue;
    public GameObject answerDbackRed;    
    public GameObject answerA;
    public GameObject answerb;
    public GameObject answerc;
    public GameObject answerd;
    public GameObject amountcorrectText;
    public GameObject bankrollText;
    public GameObject potAmountText;
    public GameObject currentBetText;

    public AudioSource correctFX;
    public AudioSource wrongFX;

    [SerializeField]
    public int currentBet = 10;
    public int currentBankRoll = 1000;
    public int potAmount;    
    public int amountCorrect = 0;
    public int amountlost;

    public bool addedFirstBet = false;
    public bool addedFlopBet = false;
    public bool addedTurnBet = false;
    public bool addedRiverBet = false;
    public bool addedFinalBet = false;

    private void Start()
    {
        
    }

    void Update()
    {
        amountcorrectText.GetComponent<TMP_Text>().text = "Amount Correct: " + amountCorrect;     
    }


    public void AnswerA()
    {
        if(QuestionGenerator.actualAnswer == "A")
        {
            answerAbackGreen.SetActive(true);
            answerAbackBlue.SetActive(false);
            correctFX.Play();            
            amountCorrect++;                   
     
        }
        else
        {
            answerAbackRed.SetActive(true);
            answerAbackBlue.SetActive(false);
            wrongFX.Play();
        }
        questionGenerator.PocketCardQuestions++;
        questionGenerator.flopQuestions++;
        DisableButtones();      
        StartCoroutine(NextQuestion());
    }
    public void AnswerB()
    {
        if (QuestionGenerator.actualAnswer == "B")
        {
            answerBbackGreen.SetActive(true);            
            answerBbackBlue.SetActive(false);
            correctFX.Play();
            amountCorrect++;
        }
        else
        {
            answerBbackBlue.SetActive(false);           
            answerBbackRed.SetActive(true);
            wrongFX.Play();
        }
        questionGenerator.PocketCardQuestions++;
        questionGenerator.flopQuestions++;
        DisableButtones();
      //  StartCoroutine(WaitForAnswer());
        StartCoroutine(NextQuestion());
    }
    public void AnswerC()
    {
        if (QuestionGenerator.actualAnswer == "C")
        {
            answerCbackGreen.SetActive(true);
            answerCbackBlue.SetActive(false);
            correctFX.Play();
            amountCorrect++;
        }
        else
        {
            answerCbackRed.SetActive(true);
            answerCbackBlue.SetActive(false);
            wrongFX.Play();
        }
        
        DisableButtones();
        questionGenerator.PocketCardQuestions++;
        questionGenerator.flopQuestions++;
        StartCoroutine(NextQuestion());

         
    }
    public void AnswerD()
    {
        if (QuestionGenerator.actualAnswer == "D")
        {
            answerDbackGreen.SetActive(true);
            answerDbackBlue.SetActive(false);
            correctFX.Play();
            amountCorrect++;
        }
        else
        {
            answerDbackRed.SetActive(true);
            answerDbackBlue.SetActive(false);
            wrongFX.Play();
        }
        questionGenerator.PocketCardQuestions++;
        questionGenerator.flopQuestions++;
        DisableButtones();       
        StartCoroutine(NextQuestion());
    }

    public void DisableButtones()
    {
        answerA.GetComponent<Button>().enabled = false;
        answerb.GetComponent<Button>().enabled = false;
        answerc.GetComponent<Button>().enabled = false;
        answerd.GetComponent<Button>().enabled = false;
    }
    public void EnableButtons()
    {
        answerA.GetComponent<Button>().enabled = true;
        answerb.GetComponent<Button>().enabled = true;
        answerc.GetComponent<Button>().enabled = true;
        answerd.GetComponent<Button>().enabled = true;
    }
    IEnumerator WaitForAnswer()
    {
        yield return new WaitForSeconds(2);
    }

    IEnumerator NextQuestion()
    {
        yield return new WaitForSeconds(2);
        SetAllBacksToFalse();
        EnableButtons();
    }
    public void SetAllBacksToFalse()
    {
        answerAbackGreen.SetActive(false);
        answerBbackGreen.SetActive(false);
        answerCbackGreen.SetActive(false);
        answerDbackGreen.SetActive(false);
        answerAbackRed.SetActive(false);
        answerBbackRed.SetActive(false);
        answerCbackRed.SetActive(false);
        answerDbackRed.SetActive(false);
        answerAbackBlue.SetActive(true);
        answerBbackBlue.SetActive(true);
        answerCbackBlue.SetActive(true);
        answerDbackBlue.SetActive(true);
        QuestionGenerator.displayingQuestion = false;
    }
    public void AddBetToPot()
    {
        if (!addedFirstBet)
        {
            potAmount = potAmount + currentBet;
            currentBankRoll = currentBankRoll - currentBet;
        }
    }
    public void AddFlopBetToPot()
    {
        if (!addedFlopBet)
        {
            potAmount = potAmount + currentBet;
            currentBankRoll = currentBankRoll - currentBet;
        }
    }
    public void AddTurnBetToPot()
    {
        if (!addedTurnBet)
        {
            potAmount = potAmount + currentBet;
            currentBankRoll = currentBankRoll - currentBet;
        }
    }public void AddedRiverBet()
    {
        if (!addedRiverBet)
        {
            potAmount = potAmount + currentBet;
            currentBankRoll = currentBankRoll - currentBet;
        }
    }
    public void AddFinalBet()
    {
        if (!addedFinalBet)
        {
            potAmount = potAmount + currentBet;
            currentBankRoll = currentBankRoll - currentBet;
        }
        }
   
}
