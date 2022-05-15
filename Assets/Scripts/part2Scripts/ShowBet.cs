using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShowBet : MonoBehaviour
{
    public TMP_Text betText;
    public AnswerButtons ansbuttons;
    public CountdownTimer cnttmr;
    public int amountBet;

    private int playerBet;
    public int PotAmount;

    public TMP_InputField betInput;

    public GameObject BankDisplay;
    public GameObject BetDisplay;
    public GameObject PotDisplay;
    

    public bool hasBetCounted = false;
    public int playerBankroll = 1000;
    public int NewBankroll;
    public bool hasAddedFirstBet = false;


    // Start is called before the first frame update
    void Start()
    {
        BankDisplay.GetComponent<TMP_Text>().text = "BankRoll: " + playerBankroll;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StoreBet()
    {
        hasBetCounted = true;
        BetDisplay.GetComponent<TMP_Text>().text = "CurrentBet: " + betInput.text;
        playerBet = int.Parse(betInput.text);
        ChargeBank();
    }
    public void NoBet()
    {
        if(betInput.text == null)
        {
            Debug.Log("ohno");
        }
        //hasBetCounted = true;
        //playerBet = 0;
        //BetDisplay.GetComponent<TMP_Text>().text = "CurrentBet: " + playerBet;      
    }
    public void ChargeBank()
    {
        NewBankroll = playerBankroll - playerBet;
        if (playerBet >= playerBankroll)
        {
            OverBet();
        }
        else
        {
            BankDisplay.GetComponent<TMP_Text>().text = "BankRoll: " + NewBankroll;
        }
    }
    public void OverBet()
    {
        playerBet = playerBankroll;
        playerBankroll = 0;
        BankDisplay.GetComponent<TMP_Text>().text = "BankRoll: " + playerBankroll;
        BetDisplay.GetComponent<TMP_Text>().text = "CurrentBet: " + playerBet;
        Debug.Log("got it");         
    }    
    public void AddbetToPot()
    {
        if (!hasAddedFirstBet)
        {
            PotAmount = PotAmount + playerBet;
            PotDisplay.GetComponent<TMP_Text>().text = "Pot Amount: " + PotAmount;
            playerBet = 0;
            BetDisplay.GetComponent<TMP_Text>().text = "CurrentBet: " + playerBet;
            hasAddedFirstBet = true;
        }
    }
}
