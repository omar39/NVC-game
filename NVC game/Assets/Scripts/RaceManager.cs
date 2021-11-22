using System.Collections;
using UnityEngine;
using RTLTMPro;


public class RaceManager : MonoBehaviour
{
    public GameObject countdownPanel;
    public GameObject questionsPanel;
    public GameObject finishPanel;
    public RTLTextMeshPro countLabel;
    public RTLTextMeshPro rankTMP;
    private int rank = 1;
    public void startCountdown()
    {
        countdownPanel.SetActive(true);
        StartCoroutine( countdown() );
    }
    void initiateRace()
    {
        AutoRun[] players = FindObjectsOfType<AutoRun>();

        foreach( AutoRun player in players)
        {
            player.StartRace();
        }
    }
    IEnumerator countdown()
    {
        yield return new WaitForSeconds(1f);
        countLabel.text = "٢";

        yield return new WaitForSeconds(1f);
        countLabel.text = "١";

        yield return new WaitForSeconds(1f);
        countLabel.text = "انطلق!";

        yield return new WaitForSeconds(1f);
        countdownPanel.SetActive(false);
        questionsPanel.SetActive(true);

        initiateRace();

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Player")
        {
            finishPanel.SetActive(true);
            rankTMP.text += rank.ToString() + "!";
        }
        else
        {
            rank++;
        }
        col.gameObject.GetComponent<AutoRun>()?.EndRace();
    }
}
