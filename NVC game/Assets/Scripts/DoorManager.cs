using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject goPanel;
    private void OnTriggerEnter2D(Collider2D other) {
        goPanel.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other) {
        goPanel.SetActive(false);
    }
}
