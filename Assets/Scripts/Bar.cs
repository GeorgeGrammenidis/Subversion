using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : Scene1Manager
{
    public DialogueManager dialogueManager;
    public string [] dialogueLines;
    public GameObject Exit;
    bool hasspoken = false;
    void Start()
    {
        
    }
    void Update()
    {
        if (cur==3 && !hasspoken)
        {
            dialogueManager.StartDialogue(dialogueLines);
            hasspoken=true;
            Exit.SetActive(true);
        }
    }
}
