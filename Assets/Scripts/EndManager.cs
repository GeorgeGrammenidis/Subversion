using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public GameObject pressJPrompt;

    public int stagesCompleted;
    public string[] stageMessages;
    public float textSpeed = 0.05f;

    private string fullText;
    private bool isTextComplete = false;


    void Start()
    {
        stagesCompleted = PlayerPrefs.GetInt("StagesCompleted", 0);
        stagesCompleted++;
        PlayerPrefs.SetInt("StagesCompleted", stagesCompleted);
        fullText = "Chapter " + stagesCompleted.ToString() + " completed. Your progress has been saved.";

        StartCoroutine(DisplayText());
    }


    void Update()
    {
        if (isTextComplete && Input.GetKeyDown(KeyCode.J))
        {
            //SceneManager.LoadScene("Chapter" + (stagesCompleted + 1).ToString());
            Initiate.Fade("Chapter" + (stagesCompleted + 1), Color.black, 0.5f);
        }
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
}
