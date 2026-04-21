using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForkManager : MonoBehaviour
{
    
    public TextMeshProUGUI displayText;
    public GameObject pressJPrompt;

    public float textSpeed = 0.05f;

    private string fullText;
    private bool isTextComplete = false;
    int stones;

    void Start()
    {
        int stone;
        stones = 0;
        int deaths = PlayerPrefs.GetInt("deaths", 0);
        for (int i = 0; i < 11; i++)
        {
            stone = PlayerPrefs.GetInt($"Stone_{i + 1}", 0);
            if (stone == 1)
            {
                stones++;
            }
        }
        fullText = "Total Player Deaths: " + deaths + "\n Collectibles found: " + stones +"/11";
        StartCoroutine(DisplayText());

    }

    IEnumerator DisplayText()
    {
        displayText.text = "";
        pressJPrompt.SetActive(false);

        foreach (char c in fullText)
        {
            displayText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isTextComplete = true;
        pressJPrompt.SetActive(true);
    }
    void Update()
    {
        if (isTextComplete && Input.GetKeyDown(KeyCode.J))
        {
            if (stones == 11)
            {
                Initiate.Fade("Jakob", Color.black, 0.5f);
            }
            else
            {
                Initiate.Fade("Credits", Color.black, 0.5f);
            }


        }
    }
}
