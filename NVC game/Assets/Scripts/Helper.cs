using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour
{
    [TextArea]
    public string guideText;
    public Text placholder;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        placholder.text = guideText;
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        placholder.text = "";
    }
}
