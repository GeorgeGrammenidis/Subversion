using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Scene73Manager : MonoBehaviour
{

    public CharacterController Rosa;
    public DialogueTrigger Tristan;
    public DialogueTrigger Phone;
    public DialogueTrigger Sea;
    public DialogueManager dialogueManager;
    public Scene1Manager scene1Manager;
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
        Rosa.canMove = false;
        Tristan.GetComponent<Animator>().SetBool("isMoving", true);
        Tristan.GetComponent<Animator>().SetFloat("horizontal", 1);
        Tristan.GetComponent<Animator>().SetFloat("vertical", 0);
        while (Vector3.Distance(Tristan.transform.position, new Vector2(10, 1)) > 0.1f)
        {
            Tristan.transform.position = Vector3.MoveTowards(
                Tristan.transform.position,
                new Vector2(10, 1),
                speed * Time.deltaTime
            );
            yield return null;
        }
        dialogueManager.StartDialogue(Phone.dialogueLines);
        yield return new WaitUntil(() => scene1Manager.cur > 1);
        Tristan.GetComponent<Animator>().SetBool("isMoving", true);
        Tristan.GetComponent<Animator>().SetFloat("horizontal", -1);
        Tristan.GetComponent<Animator>().SetFloat("vertical", 0);
        while (Vector3.Distance(Tristan.transform.position, new Vector2(1, 1)) > 0.1f)
        {
            Tristan.transform.position = Vector3.MoveTowards(
                Tristan.transform.position,
                new Vector2(1, 1),
                speed * Time.deltaTime
            );
            yield return null;
        }
        Tristan.GetComponent<Animator>().SetBool("isMoving", false);
        Tristan.GetComponent<Animator>().SetFloat("horizontal", -1);
        Tristan.GetComponent<Animator>().SetFloat("vertical", 0);
        dialogueManager.StartDialogue(Sea.dialogueLines);
        yield return new WaitUntil(() => scene1Manager.cur > 2);
    }

}
