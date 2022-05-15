using UnityEngine;
[CreateAssetMenu(fileName = "Questions", menuName = "Assets/Questions")]

public class QuestionHolder : ScriptableObject
{
    public int questionNumber;
    [TextArea]
    public string question;
    public string answerA;
    public string answerB;
    public string answerC;
    public string answerD;
    public string actualAnswer;
}
