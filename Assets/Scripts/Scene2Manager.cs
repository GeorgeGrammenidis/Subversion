using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene2Manager : Scene1Manager 
{
    public string[] dialogueLines;
    // public string[][] test;
    public DialogueManager dialogueManager;
    public GameObject Image;
    bool isPaused = false;
    bool cancontinue = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cur==1 && !cancontinue)
        {
            Time.timeScale = 0f; 
            isPaused = true;
            Image.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.J) && isPaused ) {
            Time.timeScale = 1f;
            isPaused = false;
            cancontinue = true;
            Image.SetActive(false);
            dialogueManager.StartDialogue(dialogueLines);
        }
        if (cur==2){
            
            Initiate.Fade("Boat", Color.black, 0.5f);
        }
    }
}
