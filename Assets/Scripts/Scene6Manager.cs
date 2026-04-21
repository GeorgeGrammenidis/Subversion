using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene6Manager : MonoBehaviour
{
    public DialogueTrigger Tristan;
    public DialogueTrigger Monty;
    public CharacterController Rosa;
    public DialogueManager dialogueManager;
    public Scene1Manager scene1Manager;
    int speed = 5;
    bool do_once = true;
    void Start()
    {
        
    }

    void Update()
    {
        if (do_once)
        {
            do_once = false;
            StartCoroutine(StartSequence());
        }

        if ((Monty.hasSpoken && scene1Manager.cur==2) || scene1Manager.cur==3 )
        {
            Initiate.Fade("Chapter6.2", Color.black, 0.5f);
        }
    }
    private IEnumerator StartSequence()
    {
        dialogueManager.StartDialogue(Tristan.dialogueLines);
        
        yield return new WaitUntil(() => scene1Manager.cur > 0);
        Rosa.canMove = false;
        Tristan.GetComponent<Animator>().SetBool("isMoving", true);
        Tristan.GetComponent<Animator>().SetFloat("horizontal", 0);
        Tristan.GetComponent<Animator>().SetFloat("vertical", -1);
        while (Vector3.Distance(Tristan.transform.position, new Vector2(14, 0)) > 0.1f)
        {
            Tristan.transform.position = Vector3.MoveTowards(
                Tristan.transform.position,
                new Vector2(14, 0),
                speed * Time.deltaTime
            );
            yield return null;
        }
        Rosa.canMove = true;
        Tristan.gameObject.SetActive(false);
    }
}
