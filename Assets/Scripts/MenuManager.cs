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
    
        if (Input.GetKeyDown(KeyCode.T)){
            PlayerPrefs.SetInt("StagesCompleted", 5);
            PlayerPrefs.Save();
            stagesCompleted = 5;
            SceneManager.LoadScene("Main Menu");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetProgress();
        }

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
        SceneManager.LoadScene("Map");
    }

    void ResetProgress()
    {
        PlayerPrefs.SetInt("StagesCompleted", 0);
        PlayerPrefs.SetInt("Chapter4Key", 0);
        for (int i = 1; i < 26; i++)
        {
            PlayerPrefs.SetInt($"Stone_{i}", 0);
        }
        PlayerPrefs.SetInt("deaths", 0);
        PlayerPrefs.Save();
        stagesCompleted = 0;
        SceneManager.LoadScene("Main Menu");
    }
}
