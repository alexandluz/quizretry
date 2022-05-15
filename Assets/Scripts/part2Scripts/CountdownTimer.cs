using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public ShowBet showbet;
    public TextMeshProUGUI quuestText;
    public TextMeshProUGUI answerATxt;
    public TextMeshProUGUI answerBTxt;
    public TextMeshProUGUI answerCTxt;
    public TextMeshProUGUI answerDTxt;

    public bool shownFirstQuestion = false;
    public bool shownSecondQuestion = false;
    public bool shownPocketAnimation = false;
    public bool shownFlopAnimation = false;
    public bool shownThirdCard = false;
    public bool shownFourthCard = false;
    public bool shownFifthCard = false;
    public bool shownTurnAnimation = false;
    public bool shownSixthCard = false;
    public bool shownRiverAnimation = false;
    public bool shownSeventhCard = false;
    public bool QueTheTurn = false;
    public bool AllQuestionsAnswered = false;


    public string actualAnswer;
    public GameObject inputObj;
    public GameObject cardCanvas;
    public GameObject QuestionUI;
    public GameObject Answer1UI;
    public GameObject Answer2UI;
    public GameObject Answer3UI;
    public GameObject Answer4UI;


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
    
    public AudioSource correctFX;
    public AudioSource wrongFX;
    public GameObject AmountCorrectDisplay;

    public int PocketCardNumber = 0;
    public int amountCorrect = 0;
    private AnswerButtons ansButtons;
    private ShowQuestions showques;
    public TMP_Text countdowntxt;
    float currentTime = 0f;
    float startingTime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;

    }

    // Update is called once per frame
    void Update()
    {
        AmountCorrectDisplay.GetComponent<TMP_Text>().text = "Amount Correct: " + amountCorrect;
        if (PocketCardNumber == 1)
        {
            if (shownFirstQuestion)
            {                
                SecondCard();
            }
        }
        currentTime -= 1 * Time.deltaTime;
        countdowntxt.text = "Time Remaining: " + currentTime.ToString("0");
        if(currentTime <= 0)
        {
            currentTime = 0;
            showbet.NoBet();
            DisplayFistQuestion();
        }
        if(PocketCardNumber==2 & shownFirstQuestion & shownSecondQuestion & !shownPocketAnimation)
        {
            StartCoroutine(AfterPockerAnim());
        }
        if (PocketCardNumber ==3 & !shownThirdCard)
        {            
            ThirdCard();
            shownThirdCard = true;
        }
        if(PocketCardNumber == 4 & !shownFourthCard)
        {
            FourthCard();
            shownFourthCard = true;
        }
        if(PocketCardNumber ==5 & !shownFifthCard)
        {
            FifthCard();
        }
        if (QueTheTurn & PocketCardNumber ==6 & !shownFlopAnimation)
        {
            StartCoroutine(AfterFlopAnim());
        }
        if(PocketCardNumber ==7 & !shownSixthCard)
        {
            SixthCard();
        }
        if (PocketCardNumber ==8 & !shownSeventhCard  )
        {
            StartCoroutine(AfterTurnAnim());
        }
        if(PocketCardNumber == 9)
        {
            SeventhCard();
        }
        if (AllQuestionsAnswered)
        {
            Debug.Log("Finnaly");
        }
        
    }
    public void GetNewRandomQuestion()
    {
        SetUI(Database.GetRandomQuestion());
        
    }
    public void SetUI(QuestionHolder i)
    {
        quuestText.text = i.question;
        answerATxt.text = i.answerA;
        answerBTxt.text = i.answerB;
        answerCTxt.text = i.answerC;
        answerDTxt.text = i.answerD;        
        actualAnswer = i.actualAnswer;
        Debug.Log(actualAnswer);        
    }
    
    public void AnswerA()
    {
        if(actualAnswer == "A")
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
           // questionGenerator.PocketCardQuestions++;
           // questionGenerator.flopQuestions++;
            DisableButtones();
           StartCoroutine(WaitForResults());        
    }
    public void AnswerB()
    {
        if (actualAnswer == "B")
        {
            answerBbackGreen.SetActive(true);
            answerBbackBlue.SetActive(false);
            correctFX.Play();
            amountCorrect++;

        }
        else
        {
            answerBbackRed.SetActive(true);
            answerBbackBlue.SetActive(false);
            wrongFX.Play();
        }
        // questionGenerator.PocketCardQuestions++;
        // questionGenerator.flopQuestions++;
        DisableButtones();
        StartCoroutine(WaitForResults());
    
}
    public void AnswerC()
    {
        if (actualAnswer == "C")
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
        // questionGenerator.PocketCardQuestions++;
        // questionGenerator.flopQuestions++;
        DisableButtones();
        StartCoroutine(WaitForResults());
    }
    public void AnswerD()
    {
        if (actualAnswer == "D")
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
        // questionGenerator.PocketCardQuestions++;
        // questionGenerator.flopQuestions++;
        DisableButtones();
        StartCoroutine(WaitForResults());
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

    IEnumerator WaitForResults()
    {
        yield return new WaitForSeconds(2.6f);        
        PocketCardNumber++;
    }
    void DisplayFistQuestion()
    {
        if (!shownFirstQuestion)
        {
            GetNewRandomQuestion();
            shownFirstQuestion = true;
            currentTime = 30f;
            inputObj.SetActive(false);            
        }
    }
    public void SecondCard()
    {
        if (!shownSecondQuestion)
        {
            SetAllBacksToFalse();
            EnableButtons();
            Debug.Log("2bd");
            GetNewRandomQuestion();
            shownSecondQuestion = true;
            currentTime = 30f;
            inputObj.SetActive(false);
        }
    }
    
    public void ThirdCard()
    {
        ReopenUI();
        SetAllBacksToFalse();
        EnableButtons();
        Debug.Log("third card");
        GetNewRandomQuestion();
        shownThirdCard = true;
        currentTime = 30f;
        //PocketCardNumber++;
        inputObj.SetActive(false);
    }
    public void FourthCard()
    {
        SetAllBacksToFalse();
        EnableButtons();
        Debug.Log("Fourth card");
        GetNewRandomQuestion();
        shownFourthCard = true;
        currentTime = 30f;
        //PocketCardNumber++;
        inputObj.SetActive(false);
    }
    public void FifthCard()
    {
        SetAllBacksToFalse();
        EnableButtons();
        Debug.Log("Fifth card");
        GetNewRandomQuestion();
        shownFifthCard = true;
        currentTime = 30f;
      //  PocketCardNumber++;
        inputObj.SetActive(false);
        QueTheTurn = true;
    }
    
    public void SixthCard()
    {        
        SetAllBacksToFalse();
        EnableButtons();
        Debug.Log("6th card");
        GetNewRandomQuestion();
        shownSixthCard = true;
        currentTime = 30f;
        inputObj.SetActive(false);
        shownTurnAnimation = true;
    }
    public void SeventhCard()
    {
        SetAllBacksToFalse();
        EnableButtons();
        Debug.Log("7 card");
        GetNewRandomQuestion();
        shownSeventhCard = true;
        currentTime = 30f;
        inputObj.SetActive(false);
        shownTurnAnimation = true;
        StartCoroutine(WaitForEnd());
    }
    IEnumerator AfterPockerAnim()
    {
        CloseAllUIExceptBet();
        currentTime = 10f;
        showbet.AddbetToPot();
        shownPocketAnimation = true;
        showbet.AddbetToPot();
        Debug.Log("Que the flop");
        // cardCanvas.SetActive(false);
        yield return new WaitForSeconds(10f);
        cardCanvas.SetActive(true);
        PocketCardNumber++;
    }
    IEnumerator AfterTurnAnim()
    {
        Debug.Log("Que the Turn");
        
        showbet.AddedSecondBet();
        CloseAllUIExceptBet();       
        currentTime = 5f;
        cardCanvas.SetActive(false);
        shownTurnAnimation = true;
        yield return new WaitForSeconds(5f);            
        cardCanvas.SetActive(true);
        PocketCardNumber++;
        shownSeventhCard = true;
        ReopenUI();
        }
    
    IEnumerator AfterFlopAnim()
    {
        CloseAllUIExceptBet();
        currentTime = 10f;
        shownFlopAnimation = true;
        showbet.AddbetToPot();
        Debug.Log("Que the River");
        //cardCanvas.SetActive(false);
        yield return new WaitForSeconds(10f);
        cardCanvas.SetActive(true);
        PocketCardNumber++;
        ReopenUI();
    }
    IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(30f);
        AllQuestionsAnswered = true;
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
    public void CloseAllUIExceptBet()
    {
     inputObj.SetActive(true);
     //cardCanvas.SetActive(false);
     QuestionUI.SetActive(false);
     Answer1UI.SetActive(false);
     Answer2UI.SetActive(false);
     Answer3UI.SetActive(false);
     Answer4UI.SetActive(false);
}
    public void ReopenUI()
    {
        QuestionUI.SetActive(true);
        Answer1UI.SetActive(true);
        Answer2UI.SetActive(true);
        Answer3UI.SetActive(true);
        Answer4UI.SetActive(true);
    }
}

