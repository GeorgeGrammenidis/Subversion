using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene7Manager : MonoBehaviour
{
    public DialogueTrigger Tristan;
    public CharacterController Rosa;
    public bool doonce = true;
    public bool doonce2 = true;
    public Scene1Manager scene1Manager;
    public DialogueManager dialogueManager;
    public DialogueTrigger Monty;
    int speed = 5;

    void Start()
    {
        
    }

    void Update()
    {
        if (scene1Manager.cur > 0 && doonce)
        {
            doonce = false;
            StartCoroutine(StartSequence());
        }
        if (scene1Manager.cur == 5 && doonce2)
        {
            doonce2 = false;
            dialogueManager.StartDialogue(Monty.dialogueLines);
        }
    }

    private IEnumerator StartSequence()
    {
        Rosa.canMove = false;
        Tristan.GetComponent<Animator>().SetBool("isMoving", true);
        Tristan.GetComponent<Animator>().SetFloat("horizontal", 0);
        Tristan.GetComponent<Animator>().SetFloat("vertical", 1);
        while (Vector3.Distance(Tristan.transform.position, new Vector2(0, -1)) > 0.1f)
        {
            Tristan.transform.position = Vector3.MoveTowards(
                Tristan.transform.position,
                new Vector2(0, -1),
                speed * Time.deltaTime
            );
            yield return null;
        }
        Tristan.GetComponent<Animator>().SetBool("isMoving", false);
        dialogueManager.StartDialogue(Tristan.dialogueLines);
        yield return new WaitUntil(() => scene1Manager.cur > 1);
        Tristan.GetComponent<Animator>().SetBool("isMoving", true);
        Tristan.GetComponent<Animator>().SetFloat("horizontal", 0);
        Tristan.GetComponent<Animator>().SetFloat("vertical", -1);
        while (Vector3.Distance(Tristan.transform.position, new Vector2(0, -6)) > 0.1f)
        {
            Tristan.transform.position = Vector3.MoveTowards(
                Tristan.transform.position,
                new Vector2(0, -6),
                speed * Time.deltaTime
            );
            yield return null;
        }
        Tristan.gameObject.SetActive(false);
        Rosa.canMove = true;
    }
}
