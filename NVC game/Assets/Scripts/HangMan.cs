using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HangMan : MonoBehaviour
{
    public GameObject [] parts;
    public GameObject winPanel, losePanel;
    public int numberOfCorrect = 2;
    public Animator emotions;
    int currPart = 0;
    public void validateAsWrong()
    {
        EventSystem.current.currentSelectedGameObject.SetActive(false);

        parts[currPart++].SetActive(true);
        emotions.SetTrigger("Sad");

        if(currPart == 6)
        {
            losePanel.SetActive(true);
            Destroy(gameObject);
        }
    }
    public void validateAsRight()
    {
        EventSystem.current.currentSelectedGameObject.SetActive(false);
        numberOfCorrect -= 1;
        emotions.SetTrigger("Happy");

        if(numberOfCorrect == 0)
        {
            winPanel.SetActive(true);
        }
    }
}
