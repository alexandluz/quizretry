using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Database : MonoBehaviour
{
    private static Database instance;
    public QuestionDatabase Questionsdb;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static QuestionHolder GetQuestionByNumber(int questnum)
    {
        return instance.Questionsdb.allQuestion.FirstOrDefault(i => i.questionNumber == questnum);
    }
    public static QuestionHolder GetRandomQuestion()
    {
        return instance.Questionsdb.allQuestion[Random.Range(0, instance.Questionsdb.allQuestion.Count())];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
