using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class SpawnPrompt : MonoBehaviour
{
    public TMP_Text TxtArea;
    public string PromptText;
    public bool Done = false; 
    public float deltat = 1f; //time threshold for text 
    public float tt = 0f; //time counter

    // Start is called before the first frame update
    void Start()
    {
        TxtArea = GetComponentInChildren<TMP_Text>();
        if (PromptText == null)
            PromptText = TxtArea.text;
        TxtArea.SetText("");

    }

    // Update is called once per frame
    void Update()
    {
        if (!Done && TxtArea != null)
            WriteText();

    }

    void WriteText()
    {
        
        if (PromptText.Length > TxtArea.text.Length)
        {
            if (tt > deltat)
            {
                int i = TxtArea.text.Length;
                TxtArea.SetText(TxtArea.text.Insert(i, PromptText[i].ToString()));
                tt = 0;
            }
            else
                tt += Time.deltaTime;
        }
        else
            Done = true;
    }

    public void ResetText()
    {
        TxtArea.SetText("");
    }
}
