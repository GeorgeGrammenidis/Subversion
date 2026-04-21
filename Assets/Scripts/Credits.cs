using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public TextMeshProUGUI displayText;

    float textSpeed = 0.03f;

    private string fullText;
    private bool isTextComplete = false;
    public string [] lines;
    string line;
    int index=0;

    void Start()
    {
        this.lines = lines;
        index = 0;
        NextLine();

    }

    void Update()
    {

        if ((isTextComplete) && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }
        if (!isTextComplete && (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Space)))
        {
            if (displayText.text == line)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                displayText.text = line;

            }
        }
        
    }

    void NextLine()
    {
        if (index < lines.Length)
        {
            line = lines[index];
            index++;
            displayText.text = string.Empty;

            StartCoroutine(DisplayText());
        }
        else
        {
            isTextComplete = true;
        }
    }

    IEnumerator DisplayText()
    {
        displayText.text = "";

        foreach (char c in line)
        {
            displayText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        
    }
}
