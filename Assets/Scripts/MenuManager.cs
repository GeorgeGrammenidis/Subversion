using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI startGameText;
    public TextMeshProUGUI continueText;
    public TextMeshProUGUI resetText;
    public Transform selector;

    private int selectedOption = 0; 
    private int stagesCompleted = 0;

    void Start()
    {
        
        stagesCompleted = PlayerPrefs.GetInt("StagesCompleted", 0);
        
        if (stagesCompleted == 0)
        {

            startGameText.gameObject.SetActive(true);
            continueText.gameObject.SetActive(false);
            resetText.gameObject.SetActive(false);
            selectedOption = 0;
            selector.position = startGameText.transform.position + new Vector3(-150f, 0, -5);
        }
        else
        {

            startGameText.gameObject.SetActive(false);
            continueText.gameObject.SetActive(true);
            resetText.gameObject.SetActive(true);
            

            selectedOption = 0;
            selector.position = continueText.transform.position + new Vector3(-100f, 0, -5);
        }
        UpdateSelector();
    }

    void Update() { 
    
        

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (selectedOption == 0)
            {
                selectedOption = 1;
            }
            else if (selectedOption == 1)
            {
                selectedOption = 0;
            }
            UpdateSelector();
        }
        

        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Space))
        {
            ExecuteOption();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    

    void UpdateSelector()
    {
        if (stagesCompleted != 0)
        {
            if (selectedOption == 0)
            {
                selector.position = continueText.transform.position + new Vector3(-100f, 0, -5);
            }
            else if (selectedOption == 1)
            {
                selector.position = resetText.transform.position + new Vector3(-100f, 0, -5);
            }
        }
        
    }

    void ExecuteOption()
    {
        if (stagesCompleted == 0)
        {
            LoadGame();
        }
        else
        {
            if (selectedOption == 0)
            {
                LoadGame();
            }
            else if (selectedOption == 1)
            {
                ResetProgress();
            }
        }
    }

    void LoadGame()
    {
        stagesCompleted = PlayerPrefs.GetInt("StagesCompleted", 0);
        SceneManager.LoadScene("Chapter" + (stagesCompleted + 1).ToString());
    }

    void ResetProgress()
    {
        PlayerPrefs.SetInt("StagesCompleted", 0);
        for (int i = 1; i <= 11; i++)
        {
            PlayerPrefs.SetInt($"Stone_{i}", 0);
        }
        PlayerPrefs.SetInt("deaths", 0);

        PlayerPrefs.SetInt("Key3.1", 0);
        PlayerPrefs.SetInt("Key3.2", 0);
        PlayerPrefs.SetInt("Key3.3", 0);
        PlayerPrefs.SetInt("Key3.4", 0);
        PlayerPrefs.SetInt("Key3.5", 0);

        PlayerPrefs.SetInt("Key6.1", 0);
        PlayerPrefs.SetInt("Key6.2", 0);
        PlayerPrefs.SetInt("Key6.3", 0);
        PlayerPrefs.SetInt("Key6.4", 0);

        PlayerPrefs.SetInt("Key7.1", 0);
        PlayerPrefs.SetInt("Key7.2", 0);
        PlayerPrefs.SetInt("Key7.3", 0);
        PlayerPrefs.SetInt("Key7.4", 0);
        PlayerPrefs.SetInt("Key7.5", 0);

        PlayerPrefs.SetInt("Check1", 0);
        PlayerPrefs.SetInt("Check2", 0);
        PlayerPrefs.SetInt("Check4", 0);
        PlayerPrefs.SetInt("Check5", 0);
        PlayerPrefs.SetInt("Check7", 0);
        PlayerPrefs.SetInt("Check8", 0);
        PlayerPrefs.SetInt("Check9", 0);
        PlayerPrefs.SetInt("Check10", 0);
        PlayerPrefs.SetInt("Check11", 0);

        PlayerPrefs.Save();
        stagesCompleted = 0;
        SceneManager.LoadScene("Main Menu");
    }
}
