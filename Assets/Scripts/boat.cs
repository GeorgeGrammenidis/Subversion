using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boat : Scene1Manager
{
    public TextMeshProUGUI dialogueText;
    string text = "So this is how I found myself in this insane predicament. I was scared out of my mind. The stakes were abnormally high... If I failed, best case scenario Alyx dies in prison, betrayed and abandoned by me...Worst case scenario, the Raxlians invade and it's game over for my nation... But I did have some confidence. Besides my standard training in martial arts and weaponry, my deductive skills, my people reading skills, my pattern recognition skills and my gaslighting skills are second to none. My immediate priority was to settle in, make some local friends, speak to people, get informed on all the news and get a broader image of the country.";
    float textspeed = 0.02f;
    private bool isTextComplete = false;
    void Start()
    {
        dialogueText.text = "";
        StartCoroutine(DisplayText());
    }

    
    void Update()
    {
        if (isTextComplete && Input.GetKeyDown(KeyCode.J))
        {
            SceneManager.LoadScene("Chapter2.2");
        }
    }

    IEnumerator DisplayText()
    {

        foreach (char c in text)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textspeed);
        }
        isTextComplete = true;
    }
}
