using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class QuestionnaireManager : MonoBehaviour
{
    public  GameObject[] menue_questions;
    public static int i = 0;

    public static int Counter_Right_Answers = 0;
    public Text correct_txt;

    public static int Counter_wrong_Answers = 0;
    public Text wrong_txt;

    public GameObject menuScore;
    public Animator emotesAnimator;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        Counter_Right_Answers = 0;
        Counter_wrong_Answers = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public  void Right_Answer()
    {
        Counter_Right_Answers++;
        emotesAnimator.SetTrigger("Happy");
        menue_questions[i].SetActive (false);
        if(i!=9)
        {
            i++;
            menue_questions[i].SetActive (true);
        }
        else
        {
            stop();
        }
       //Debug.Log(i);
    }
    public  void Wrong_Answer()
    {
        Counter_wrong_Answers++;
        emotesAnimator.SetTrigger("Sad");
        menue_questions[i].SetActive (false);
        if(i!=9)
        {
            i++;
            menue_questions[i].SetActive (true);
        }
        else
        {
            stop();
        }
    }

    void stop()
    {
        if (menuScore == null)
            return;
        menue_questions[i].SetActive (false);
        correct_txt.text = Counter_Right_Answers.ToString();
        wrong_txt.text = Counter_wrong_Answers.ToString();

        menuScore.SetActive (true);
    }
}
