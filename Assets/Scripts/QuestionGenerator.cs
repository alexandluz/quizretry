using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionGenerator : MonoBehaviour
{
    public AnswerButtons answerbuttons;
    public static string actualAnswer;
    public static bool displayingQuestion = false;
    public bool readyForFlop = false;
    public bool readyForTurn = false;
    public bool readyForRiver = false;
    public bool readyforFinal = false;
    public int questionNumber;
    public int PocketCardQuestions = 0;
    public int TurnQuestions = 0;
    public int riverQuestions = 0;
    public int flopQuestions = 0;

    public GameObject uiCanvas;
    public bool isCanvasShowing = true;

    public int question1;
    public int question2;
    public int question3;
    public int question4;
    public int question5;
    public int question6;
    public int question7;

    void Start()
    {
        QuestionRandomizer();
    }
    IEnumerator WaitForResults()
    {
        yield return new WaitForSeconds(20f);
        Debug.Log("WAITING");
    }


    void Update()
    {
        
        if (PocketCardQuestions ==7)
        {            
            answerbuttons.AddFinalBet();
            answerbuttons.addedFinalBet = true;
            uiCanvas.gameObject.SetActive(false);
        }        
        else if (flopQuestions == 6 & !readyforFinal & !readyForRiver)
        {            
            StartCoroutine(AfterTurnAnimation());
            readyForRiver = true;
        }
        else if (readyForTurn){            
            ReadyforTurn();
        }
        else if (PocketCardQuestions <=1 & !readyForFlop ){            
            QuestionPush();
        }
        else if (flopQuestions == 5)
        {            
            StartCoroutine(AfterFlopAnimation());
            readyForTurn = true;
        }
        else if (readyForFlop & !readyForRiver) 
        {            
            ReadyForFlop();            
        }     
        else 
        {            
            StartCoroutine(AfterPocketCardsAnim());            
        }        
    }
    IEnumerator AfterPocketCardsAnim()
    {        
        uiCanvas.SetActive(false);
        yield return new WaitForSeconds(2.6f);        
        uiCanvas.SetActive(true);
        readyForFlop = true;
        answerbuttons.AddBetToPot();
        answerbuttons.addedFirstBet = true;          
    }
    IEnumerator AfterFlopAnimation()
    {        
        uiCanvas.SetActive(false);        
        yield return new WaitForSeconds(2.6f);
        uiCanvas.SetActive(true);        
        QuestionPush();        
        answerbuttons.AddFlopBetToPot();
        answerbuttons.addedFlopBet = true;
    }
    
    IEnumerator AfterTurnAnimation()
    {       
        uiCanvas.SetActive(false);
        yield return new WaitForSeconds(2.6f);      
        uiCanvas.SetActive(true);      
        answerbuttons.AddTurnBetToPot();
        answerbuttons.addedTurnBet = true;
    }
    IEnumerator AfterRiverAnimation()
    {        
        uiCanvas.SetActive(false);
        yield return new WaitForSeconds(2.6f);                
        uiCanvas.SetActive(true);       
        Debug.Log("No!");
        answerbuttons.AddedRiverBet();
        answerbuttons.addedRiverBet = true;
    }
    
    public void ReadyForFlop()
    {        
           QuestionPush();               
    }
    public void ReadyforTurn()
    {
        QuestionPush();               
       }
    public void QuestionRandomizer()
    {        
        question1 = Random.Range(1, 37);
        question2 = Random.Range(1, 37);        
        question3 = Random.Range(1, 37);
        question4 = Random.Range(1, 37);
        question5 = Random.Range(1, 37);
        question6 = Random.Range(1, 37);
        question7 = Random.Range(1, 37);

    }
        public void QuestionPush()
    { 
            if (displayingQuestion == false )    //if there is no current question
            {
                displayingQuestion = true;      // 
                questionNumber = Random.Range(1, 37);


                if (questionNumber == 1)
                {
                    QuestionDisplay.newQuestion = "This Bethesda series takes place in a post apocalyptic world in which" +
                    " your character is released from a vault into a dystopian wasteland?";
                    QuestionDisplay.newAnswerA = "Starfield";
                    QuestionDisplay.newAnswerB = "Skyrim";
                    QuestionDisplay.newAnswerC = "Fallout";
                    QuestionDisplay.newAnswerD = "Elder Scrolls Online";
                    actualAnswer = "C";
                }

                else if (questionNumber == 2)
                {
                    QuestionDisplay.newQuestion = "This 1984 game by Nintendo had players take aim at the screen with their dog, " +
                    "Rockford and required the use of the 'Nintendo Zapper'?";
                    QuestionDisplay.newAnswerA = "Duck Hunt";
                    QuestionDisplay.newAnswerB = "Gone Hunting";
                    QuestionDisplay.newAnswerC = "Safari Adventure";
                    QuestionDisplay.newAnswerD = "Skeet Shooter";
                    actualAnswer = "A";
                }

                else if (questionNumber == 3)
                {
                    QuestionDisplay.newQuestion = "The 'Gold' version of this fighting game franchise release on Nintendo 64 in 1996.";
                    QuestionDisplay.newAnswerA = "Tekken Tag team";
                    QuestionDisplay.newAnswerB = "Street Fighter";
                    QuestionDisplay.newAnswerC = "Virtual Fighter";
                    QuestionDisplay.newAnswerD = "Killer Instict";
                    actualAnswer = "D";
                }
                else if (questionNumber == 4)
                {
                    QuestionDisplay.newQuestion = "This deceivingly raunchy video game by Rare released in 2001 on " +
                    "Nintendo64 was not for kids.";
                    QuestionDisplay.newAnswerA = "Gex 64";
                    QuestionDisplay.newAnswerB = "Conker's Bad Fur Day";
                    QuestionDisplay.newAnswerC = "Perfect Dark";
                    QuestionDisplay.newAnswerD = "Duke Nukem";
                    actualAnswer = "B";
                }
                else if (questionNumber == 5)
                {
                    QuestionDisplay.newQuestion = "This Italian plumber is the face of Nintendo?";
                    QuestionDisplay.newAnswerA = "Sonic";
                    QuestionDisplay.newAnswerB = "Wreck-it-Ralph";
                    QuestionDisplay.newAnswerC = "Mario";
                    QuestionDisplay.newAnswerD = "Yoshi";
                    actualAnswer = "C";
                }
                else if (questionNumber == 6)
                {
                    QuestionDisplay.newQuestion = "The Very first Madden game 'John Madden Football' was released in what year?";
                    QuestionDisplay.newAnswerA = "1989";
                    QuestionDisplay.newAnswerB = "1993";
                    QuestionDisplay.newAnswerC = "1998";
                    QuestionDisplay.newAnswerD = "2001";
                    actualAnswer = "A";
                }
                else if (questionNumber == 7)
                {
                    QuestionDisplay.newQuestion = "Excluding off-shoot novelty consoles, which of these systems was last released by Sega?";
                    QuestionDisplay.newAnswerA = "Genesis";
                    QuestionDisplay.newAnswerB = "Gamecube";
                    QuestionDisplay.newAnswerC = "Game Gear";
                    QuestionDisplay.newAnswerD = "Dreamcast";
                    actualAnswer = "A";
                }
                else if (questionNumber == 8)
                {
                    QuestionDisplay.newQuestion = "The 1997 first person shooter game released on Nintendo 64 is still regarded by many as groundbreaking for the genre?";
                    QuestionDisplay.newAnswerA = "Quake";
                    QuestionDisplay.newAnswerB = "Duke Nukem";
                    QuestionDisplay.newAnswerC = "007 GoldenEye";
                    QuestionDisplay.newAnswerD = "Doom";
                    actualAnswer = "C";
                }
                else if (questionNumber == 9)
                {
                    QuestionDisplay.newQuestion = "How many worlds were there in Super Mario Bros. on Nes?";
                    QuestionDisplay.newAnswerA = "8";
                    QuestionDisplay.newAnswerB = "12";
                    QuestionDisplay.newAnswerC = "9";
                    QuestionDisplay.newAnswerD = "10";
                    actualAnswer = "A";
                }
                else if (questionNumber == 10)
                {
                    QuestionDisplay.newQuestion = "Throughout the 90's this character was the face of Sony's Playstation?";
                    QuestionDisplay.newAnswerA = "Sonic The Hedgehog";
                    QuestionDisplay.newAnswerB = "Samus";
                    QuestionDisplay.newAnswerC = "Megaman";
                    QuestionDisplay.newAnswerD = "Crash Bandicoot";
                    actualAnswer = "D";
                }
                else if (questionNumber == 11)
                {
                    QuestionDisplay.newQuestion = "While playing the original Mortal Kombat, " +
                        "a code had to be entered at the title screen to enable what feature?";
                    QuestionDisplay.newAnswerA = "Nudity";
                    QuestionDisplay.newAnswerB = "Blood";
                    QuestionDisplay.newAnswerC = "Sound";
                    QuestionDisplay.newAnswerD = "Big Head Mode";
                    actualAnswer = "B";
                }
                else if (questionNumber == 12)
                {
                    QuestionDisplay.newQuestion = "This racing simulator series premiered on Playstation on " +
                        "December 23, 1997 is is still going strong today?";
                    QuestionDisplay.newAnswerA = "Nascar";
                    QuestionDisplay.newAnswerB = "Forza";
                    QuestionDisplay.newAnswerC = "Gran Turismo";
                    QuestionDisplay.newAnswerD = "Jet Moto";
                    actualAnswer = "C";
                }
                else if (questionNumber == 13)
                {
                    QuestionDisplay.newQuestion = "The long running fighting franchise features characters " +
                        "like Ryu, M. Bison and Chun-Li";
                    QuestionDisplay.newAnswerA = "Street Fighter";
                    QuestionDisplay.newAnswerB = "Mortal Kombat";
                    QuestionDisplay.newAnswerC = "Tekken";
                    QuestionDisplay.newAnswerD = "Dead or Aliver";
                    actualAnswer = "A";
                }
                else if (questionNumber == 14)
                {
                    QuestionDisplay.newQuestion = "This adventure francise by Sony features Lara Croft?";
                    QuestionDisplay.newAnswerA = "Uncharted";
                    QuestionDisplay.newAnswerB = "Final Fantasy";
                    QuestionDisplay.newAnswerC = "The last of us";
                    QuestionDisplay.newAnswerD = "Tomb Raider";
                    actualAnswer = "D";
                }
                else if (questionNumber == 15)
                {
                    QuestionDisplay.newQuestion = "The first Zelda game released on Nintendo 64 of this " +
                        "name split the series into multiple timelines?";
                    QuestionDisplay.newAnswerA = "Majora's Mask";
                    QuestionDisplay.newAnswerB = "Ocarina of Time";
                    QuestionDisplay.newAnswerC = "Twilight Princess";
                    QuestionDisplay.newAnswerD = "A Link between Worlds";
                    actualAnswer = "B";
                }
                else if (questionNumber == 16)
                {
                    QuestionDisplay.newQuestion = "This Nes game released in 1987 saw Mario as a referee and " +
                        "originally featured Mike Tyson";
                    QuestionDisplay.newAnswerA = "Smash Brothers";
                    QuestionDisplay.newAnswerB = "Championship Boxing";
                    QuestionDisplay.newAnswerC = "Punch-Out";
                    QuestionDisplay.newAnswerD = "Heavy Weight Boxing";
                    actualAnswer = "C";
                }
                else if (questionNumber == 17)
                {
                    QuestionDisplay.newQuestion = "What was the name of Mario's dinosaur companion?";
                    QuestionDisplay.newAnswerA = "Yoshi";
                    QuestionDisplay.newAnswerB = "Bowser";
                    QuestionDisplay.newAnswerC = "Toad";
                    QuestionDisplay.newAnswerD = "Twamp";
                    actualAnswer = "A";
                }
                else if (questionNumber == 18)
            {
                QuestionDisplay.newQuestion = "This game was released in 1998 and was the first to " +
                    "feature Dwayne 'The Rock' Johnson?";
                QuestionDisplay.newAnswerA = "WWF Smackdown!";
                QuestionDisplay.newAnswerB = "WWF Attitude";
                QuestionDisplay.newAnswerC = "WWF Warzone";
                QuestionDisplay.newAnswerD = "WCW/NWO Revenge";
                actualAnswer = "C";
            }
            else if (questionNumber == 19)
            {
                QuestionDisplay.newQuestion = "Before Dance Dance Revolution and Guitar Hero brought" +
                    " a music genre to video games, this Sony title laid the ground work years before?";
                QuestionDisplay.newAnswerA = "MTV Music Creator";
                QuestionDisplay.newAnswerB = "Rocksmith";
                QuestionDisplay.newAnswerC = "Beat Saber";
                QuestionDisplay.newAnswerD = "PaRappa The Rapper";
                actualAnswer = "D";
            }
            else if (questionNumber == 20)
            {
                QuestionDisplay.newQuestion = "She is credited as being the very first female lead character in a video game";
                QuestionDisplay.newAnswerA = "Mrs. Pac-Man";
                QuestionDisplay.newAnswerB = "Samus";
                QuestionDisplay.newAnswerC = "Lara Croft";
                QuestionDisplay.newAnswerD = "Claire";
                actualAnswer = "A";
            }
            else if (questionNumber == 21)
            {
                QuestionDisplay.newQuestion = "This long running zombie franchise has released numerous titles over the years " +
                    "including Nemesis, Code Veronica, and Village";
                QuestionDisplay.newAnswerA = "Dying Light";
                QuestionDisplay.newAnswerB = "Days Gone";
                QuestionDisplay.newAnswerC = "Resident Evil";
                QuestionDisplay.newAnswerD = "House of the Dead";
                actualAnswer = "C";
            }
            else if (questionNumber == 22)
            {
                QuestionDisplay.newQuestion = "This SNES game received the very first 'mature' rating from the ESRB in 1994 for " +
                    "excessive blood, gore ";
                QuestionDisplay.newAnswerA = "Doom";
                QuestionDisplay.newAnswerB = "Quake";
                QuestionDisplay.newAnswerC = "Slaughterhouse 3";
                QuestionDisplay.newAnswerD = "Grand Theft Auto";
                actualAnswer = "A";
            }
            else if (questionNumber == 23)
            {
                QuestionDisplay.newQuestion = "This gaming studio has published franchises including Elder Scrolls, Fallout," +
                    " and The Evil Within?";
                QuestionDisplay.newAnswerA = "Naughty Dog";
                QuestionDisplay.newAnswerB = "Rockstar";
                QuestionDisplay.newAnswerC = "Bethesda";
                QuestionDisplay.newAnswerD = "Electronic Arts";
                actualAnswer = "C";
            }
            else if (questionNumber == 24)
            {
                QuestionDisplay.newQuestion = "This installment of Grand Theft Auto series took place in what resembles Miami" +
                    " Florida and made refrences to the Movie 'Scarface'";
                QuestionDisplay.newAnswerA = "GTA 4";
                QuestionDisplay.newAnswerB = "GTA 3";
                QuestionDisplay.newAnswerC = "GTA: San Andreas";
                QuestionDisplay.newAnswerD = "GTA Vice City";
                actualAnswer = "D";
            }
            else if (questionNumber == 25)
            {
                QuestionDisplay.newQuestion = "This Nintendo branded racing/battle series began on the SNES in 1992 and features " +
                    "a host of Nintendo characters such as Mario, Princess Peach, and Wario?";
                QuestionDisplay.newAnswerA = "Diddy Kong Racing";
                QuestionDisplay.newAnswerB = "Mario Kart";
                QuestionDisplay.newAnswerC = "Jet Moto";
                QuestionDisplay.newAnswerD = "Diddy Kong Racing";
                actualAnswer = "B";
            }
            else if (questionNumber == 26)
            {
                QuestionDisplay.newQuestion = "This fighting series became famous in the early 19990's for 'Fatalities'";
                QuestionDisplay.newAnswerA = "Mortal Kombat";
                QuestionDisplay.newAnswerB = "Killer Instict";
                QuestionDisplay.newAnswerC = "War Gods";
                QuestionDisplay.newAnswerD = "Clay Fighter";
                actualAnswer = "A";
            }
            else if (questionNumber == 27)
            {
                QuestionDisplay.newQuestion = "This vehicle battle game released exclusively on Playstation in 1995 and " +
                    "featured characters such as Needles Kane, Yellow Jacket and Sweet Tooth.";
                QuestionDisplay.newAnswerA = "Twisted Metal";
                QuestionDisplay.newAnswerB = "Destrustion Derby";
                QuestionDisplay.newAnswerC = "Mario Kart";
                QuestionDisplay.newAnswerD = "High Octane: Annihilation";
                actualAnswer = "A";
            }
            else if (questionNumber == 28)
            {
                QuestionDisplay.newQuestion = "This boxing series was produced annually by EA Sports from 1998-2003 " +
                    "and featured legends of the sport.";
                QuestionDisplay.newAnswerA = "Golden Gloves: Legends";
                QuestionDisplay.newAnswerB = "Punch-Out";
                QuestionDisplay.newAnswerC = "Knockout Kings";
                QuestionDisplay.newAnswerD = "12 Rounds";
                actualAnswer = "C";
            }
            else if (questionNumber == 29)
            {
                QuestionDisplay.newQuestion = "Released alongside the original XBOX in 2001, this series cemented MasterChief" +
                    " as the face of the Microsoft console.";
                QuestionDisplay.newAnswerA = "Halo";
                QuestionDisplay.newAnswerB = "Abe's Exudus";
                QuestionDisplay.newAnswerC = "Crimson Dragon";
                QuestionDisplay.newAnswerD = "Forza";
                actualAnswer = "A";
            }
            else if (questionNumber == 30)
            {
                QuestionDisplay.newQuestion = "Players take control of Edward Kenway in Assasins Creed IV:__";
                QuestionDisplay.newAnswerA = "Black Flag";
                QuestionDisplay.newAnswerB = "Brotherhood ";
                QuestionDisplay.newAnswerC = "Syndicate";
                QuestionDisplay.newAnswerD = "Unity";
                actualAnswer = "A";
            }
            else if (questionNumber == 31)
            {
                QuestionDisplay.newQuestion = "This 2009 release by Mojang Studios has gone on to become the top " +
                    "selling video game of all time.";
                QuestionDisplay.newAnswerA = "Half Life";
                QuestionDisplay.newAnswerB = "World of Warcraft";
                QuestionDisplay.newAnswerC = "Minecraft";
                QuestionDisplay.newAnswerD = "Tetris";
                actualAnswer = "C";
            }
            else if (questionNumber == 32)
            {
                QuestionDisplay.newQuestion = "This game is Nintendo's top selling game of all-time with 83 million" +
                    " copies sold";
                QuestionDisplay.newAnswerA = "Pokemon";
                QuestionDisplay.newAnswerB = "Super Mario Bros";
                QuestionDisplay.newAnswerC = "Super Mario Maker";
                QuestionDisplay.newAnswerD = "Luigi's Mansion";
                actualAnswer = "A";
            }
            else if (questionNumber == 33)
            {
                QuestionDisplay.newQuestion = "This gaming franchise holds the record for the most sales" +
                    " at $90 billion to date?";
                QuestionDisplay.newAnswerA = "Pokemon";
                QuestionDisplay.newAnswerB = "Mario";
                QuestionDisplay.newAnswerC = "Final Fantasy";
                QuestionDisplay.newAnswerD = "World of Warcraft";
                actualAnswer = "A";
            }
            else if (questionNumber == 34)
            {
                QuestionDisplay.newQuestion = "Despite this 1982 game being released alongside the highly successful film" +
                    ", this title is regarded as the worst games of all time";
                QuestionDisplay.newAnswerA = "Die Hard";
                QuestionDisplay.newAnswerB = "Blade Runner";
                QuestionDisplay.newAnswerC = "Terminator";
                QuestionDisplay.newAnswerD = "E.T.";
                actualAnswer = "D";
            }
            else if (questionNumber == 35)
            {
                QuestionDisplay.newQuestion = "This 1992 NES title was similar to a Microsoft application and featured a " +
                    "well known character?";
                QuestionDisplay.newAnswerA = "Final Fantasy";
                QuestionDisplay.newAnswerB = "Duck Hunt";
                QuestionDisplay.newAnswerC = "Mario Paint";
                QuestionDisplay.newAnswerD = "Dr. Mario";
                actualAnswer = "C";
            }
            else if (questionNumber == 36) // question 2
            {
                QuestionDisplay.newQuestion = "This 2004 flagship XBOX title is credited as bringing online gaming mainstream" +
                    "for consoles?";
                QuestionDisplay.newAnswerA = "Halo 2";
                QuestionDisplay.newAnswerB = "Perfect Dark";
                QuestionDisplay.newAnswerC = "Call of Duty: Modern Warefare";
                QuestionDisplay.newAnswerD = "Call of Duty: Black OPS";
                actualAnswer = "A";
            }
            else if (questionNumber == 999)
            {
                QuestionDisplay.newQuestion = "";
                QuestionDisplay.newAnswerA = "";
                QuestionDisplay.newAnswerB = "";
                QuestionDisplay.newAnswerC = "";
                QuestionDisplay.newAnswerD = "";
                actualAnswer = "A";
            }
                            
            QuestionDisplay.pleaseUpdate = false;           

            }
        }
    }

  /*       else if (questionNumber == 20)
         {
           QuestionDisplay.newQuestion = "";
           QuestionDisplay.newAnswerA = "";
          QuestionDisplay.newAnswerB = "";
           QuestionDisplay.newAnswerC = "";
          QuestionDisplay.newAnswerD = "";
          actualAnswer = "A";
         }
  */