using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene8Manager : MonoBehaviour
{
    public DialogueTrigger Tristan;
    public DialogueTrigger Monty;
    public CharacterController Rosa;
    int speed = 5;
    bool doonce=true;
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
        Rosa.canMove = false;
        Monty.GetComponent<Animator>().SetBool("isMoving", true);
        Monty.GetComponent<Animator>().SetFloat("horizontal", 0);
        Monty.GetComponent<Animator>().SetFloat("vertical", 1);
        while (Vector3.Distance(Monty.transform.position, new Vector2(25, 45)) > 0.1f)
        {
            Monty.transform.position = Vector3.MoveTowards(
                Monty.transform.position,
                new Vector2(25, 45),
                speed * Time.deltaTime
            );
            yield return null;
        }
        Tristan.GetComponent<Animator>().SetBool("isMoving", true);
        Tristan.GetComponent<Animator>().SetFloat("horizontal", 0);
        Tristan.GetComponent<Animator>().SetFloat("vertical", 1);
        while (Vector3.Distance(Tristan.transform.position, new Vector2(25, 16)) > 0.1f)
        {
            Tristan.transform.position = Vector3.MoveTowards(
                Tristan.transform.position,
                new Vector2(25, 16),
                speed * Time.deltaTime
            );
            yield return null;
        }
        Tristan.GetComponent<Animator>().SetBool("isMoving", false);
        Rosa.spriteRenderer.sprite = Rosa.spriteDown;
        dialogueManager.StartDialogue(Tristan.dialogueLines);
        yield return new WaitUntil(() => scene1Manager.cur > 1);
        
    }
}
