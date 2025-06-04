using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForkManager : MonoBehaviour
{
    public DialogueTrigger Selm;
    public DialogueTrigger Angel;
    public Scene1Manager scene1Manager;

    void Start()
    {
        int stone;
        int stones = 0;
        int deaths = PlayerPrefs.GetInt("deaths", 0);
        Angel.dialogueLines = new string[] { "Angel: You died " + deaths.ToString() + " times" };
        for (int i = 0; i < 25; i++)
        {
            stone = PlayerPrefs.GetInt($"Stone_{i + 1}", 0);
            if (stone == 1)
            {
                stones++;
            }
        }
        if (stones != 25)
        {
            Selm.dialogueLines = null;
            Selm.dialogueLines= new string[]  { "Selm: Hello" , "Selm: I represent the \"powers that be\" ", "Selm: I hoped you liked this story", "Selm: However, there's more...",  "Selm: Unfortunately, you didn't collect all the stones..." } ;
            scene1Manager.next_scene = "Credits";
        }
        else
        {
            Selm.dialogueLines = null;
            Selm.dialogueLines = new string[] { "Selm: Hello", "Selm: I represent the \"powers that be\" ", "Selm: I hoped you liked this story", "Selm: However, there's more...", "Selm: I see you collected all the stones of wisdom" };
            scene1Manager.next_scene = "End1";
        }
    }


    void Update()
    {
        
    }
}
