using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcadeManager : MonoBehaviour
{
    public DialogueTrigger Dragon;
    public Scene1Manager scene1Manager;
    int completed_stages;
    public string[] lines;
    void Start()
    {
        completed_stages = PlayerPrefs.GetInt("StagesCompleted", 0);
        if (completed_stages == 11)
        {
            SceneManager.LoadScene("Fork");
        }
        else
        {
            scene1Manager.next_scene = "Stage" + (completed_stages + 1).ToString();
            Dragon.dialogueLines[0] = lines[completed_stages];
        }
    }

    void Update()
    {
        
    }
}
