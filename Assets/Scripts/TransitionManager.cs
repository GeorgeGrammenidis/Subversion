using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
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

        fullText = stageMessages[stagesCompleted];

        StartCoroutine(DisplayText());
    }

    
    void Update()
    {
        if (isTextComplete && Input.GetKeyDown(KeyCode.J))
        {

            //SceneManager.LoadScene("Stage" + (stagesCompleted+1).ToString());
            Initiate.Fade("Stage" + (stagesCompleted + 1), Color.black, 0.5f);
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
