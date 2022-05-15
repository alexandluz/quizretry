using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BetTransfer : MonoBehaviour
{
    public AnswerButtons ansbutt;
    private int playerBet;
    public TMP_InputField betInput;    
    public GameObject BetDisplay;
    public bool hasBetCounted = false;

    public void Start()
    {
        
    }

    public void Update()
    {
       if (!hasBetCounted)
        {
            StoreBet();
        }
    }

    public void StoreBet()
    {
        Debug.Log(betInput.text);
        hasBetCounted = true;
        BetDisplay.GetComponent<TMP_Text>().text = "CurrentBet: " + betInput.text;
        
    }

    
}
