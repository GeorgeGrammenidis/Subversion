using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene83Manager : MonoBehaviour
{
    public CharacterController Rosa;
    public DialogueTrigger Tristan;
    public DialogueTrigger Monty;
    bool doonce = true;
    public Scene1Manager scene1Manager;
    public DialogueManager dialogueManager;
    int speed =5;
    void Start()
    {

    }

    void Update()
    {
        if (doonce)
        {
            doonce = false;
            StartCoroutine(StartSequence());
        }
    }

    private IEnumerator StartSequence()
    {

        Monty.GetComponent<Animator>().SetBool("isMoving", true);
        Monty.GetComponent<Animator>().SetFloat("horizontal", 1);
        Monty.GetComponent<Animator>().SetFloat("vertical", 0);
        while (Vector3.Distance(Monty.transform.position, new Vector2(0, 0)) > 0.1f)
        {
            Monty.transform.position = Vector3.MoveTowards(
                Monty.transform.position,
                new Vector2(0, 0),
                speed * Time.deltaTime
            );
            yield return null;
        }

        Monty.GetComponent<Animator>().SetBool("isMoving", false);

        dialogueManager.StartDialogue(Monty.dialogueLines);
        yield return new WaitUntil(() => scene1Manager.cur > 0);

        Monty.GetComponent<Animator>().SetBool("isMoving", true);
        Monty.GetComponent<Animator>().SetFloat("horizontal", -1);
        Monty.GetComponent<Animator>().SetFloat("vertical", 0);

        while (Vector3.Distance(Monty.transform.position, new Vector2(-15, 0)) > 0.1f)
        {
            Monty.transform.position = Vector3.MoveTowards(
                Monty.transform.position,
                new Vector2(-15, 0),
                speed * Time.deltaTime
            );
            yield return null;
        }

        Tristan.GetComponent<Animator>().SetBool("isMoving", true);
        Tristan.GetComponent<Animator>().SetFloat("horizontal", 1);
        Tristan.GetComponent<Animator>().SetFloat("vertical", 0);


        while (Vector3.Distance(Tristan.transform.position, new Vector2(0, 0)) > 0.1f)
        {
            Tristan.transform.position = Vector3.MoveTowards(
                Tristan.transform.position,
                new Vector2(0, 0),
                speed * Time.deltaTime
            );
            yield return null;
        }

        Tristan.GetComponent<Animator>().SetBool("isMoving", false);
        dialogueManager.StartDialogue(Tristan.dialogueLines);
        yield return new WaitUntil(() => scene1Manager.cur > 1);

        Tristan.GetComponent<Animator>().SetBool("isMoving", true);
        Tristan.GetComponent<Animator>().SetFloat("horizontal", -1);
        Tristan.GetComponent<Animator>().SetFloat("vertical", 0);


        while (Vector3.Distance(Tristan.transform.position, new Vector2(-15, 0)) > 0.1f)
        {
            Tristan.transform.position = Vector3.MoveTowards(
                Tristan.transform.position,
                new Vector2(-15, 0),
                speed * Time.deltaTime
            );
            yield return null;
        }





    }
}