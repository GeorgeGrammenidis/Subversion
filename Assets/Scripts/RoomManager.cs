using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public DialogueManager DialogueManager;
    string [] string1 = { "Rosa: (Today I am meeting Tristan at the park)" };
    string [] string2 = { "Rosa: (Today I have a date with Tristan at the forest)" };
    string [] string3 = { "Rosa: (Today is my six month anniversary with Tristan at the art gallery)" };
    int progress;
    bool haspoken;

    void Start()
    {
       progress = PlayerPrefs.GetInt("Chapter4Key", 0);
        haspoken = false;
    }


    void Update()
    {
        if (!haspoken)
        {
            if (progress == 0)
            {
                DialogueManager.StartDialogue(string1);
            }
            else if (progress == 1)
            {
                DialogueManager.StartDialogue(string2);
            }
            else if (progress == 2)
            {
                DialogueManager.StartDialogue(string3);
            }
            haspoken = true;
        }
        
    }
}
