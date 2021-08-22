using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArabicSupport;
using UnityEngine.UI;

public class ArabFix : MonoBehaviour
{
    // Start is called before the first frame update
    Text _text;
    void Start()
    {
        _text = GetComponent<Text>();
        _text.text = ArabicFixer.Fix(_text.text);
    }
    

}