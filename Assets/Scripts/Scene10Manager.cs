using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene10Manager : MonoBehaviour
{

    public CharacterController Rosa;
    public DialogueTrigger Dragon;
    public DialogueManager dialogueManager;
    public DialogueTrigger Knife;
    public Scene1Manager scene1Manager;
    public GameObject blood;
    bool doonce = true;
    int speed = 5;
    void Start()
    {

    }

    void Update()
    {
        if (scene1Manager.cur == 1 && doonce)
        {
            doonce = false;
            StartCoroutine(StartSequence());
        }
    }

    private IEnumerator StartSequence()
    {
        
        dialogueManager.StartDialogue(Knife.dialogueLines);
        yield return new WaitUntil(() => scene1Manager.cur == 2);
        Dragon.transform.rotation = Quaternion.Euler(0, 0, 270);
        blood.SetActive(true);
        scene1Manager.cur = 3;
    }

}