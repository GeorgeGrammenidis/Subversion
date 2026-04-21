using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene82Manager : MonoBehaviour
{
    public CharacterController Rosa;
    public GameObject Light;
    public GameObject Gladoru;
    public GameObject Knife;
    public GameObject Blood;
    public DialogueTrigger Officer;
    public DialogueTrigger Selm;
    bool doonce = true;
    public Scene1Manager scene1Manager;
    public DialogueManager dialogueManager;
    void Start()
    {
        
    }

    void Update()
    {
        if (doonce && scene1Manager.cur > 0)
        {
            doonce = false;
            StartCoroutine(StartSequence());
        }
    }

    private IEnumerator StartSequence()
    {
        Light.SetActive(true);
        dialogueManager.StartDialogue(Officer.dialogueLines);
        yield return new WaitUntil(() => scene1Manager.cur > 1);
        Gladoru.transform.rotation = Quaternion.Euler(0, 0, 270);
        Knife.SetActive(true);
        Blood.SetActive(true);
        Light.SetActive(false);
        dialogueManager.StartDialogue(Selm.dialogueLines);
        yield return new WaitUntil(() => scene1Manager.cur > 2);


    }
}
