using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene11Manager : MonoBehaviour
{

    public CharacterController Rosa;
    public DialogueTrigger Tristan;
    public DialogueTrigger Jakob;
    int speed = 5;
    public Scene1Manager scene1Manager;
    public DialogueManager dialogueManager;
    bool doonce =true;
    public DialogueTrigger Death;
    public GameObject Blood;
    void Start()
    {
        
    }

    void Update()
    {
        if (scene1Manager.cur>0 && doonce)
        {
            doonce = false;
            StartCoroutine(StartSequence());
        }
    }

    private IEnumerator StartSequence()
    {
        Rosa.canMove = false;
        Jakob.GetComponent<Animator>().SetBool("isMoving", true);
        Jakob.GetComponent<Animator>().SetFloat("horizontal", -1);
        Jakob.GetComponent<Animator>().SetFloat("vertical", 0);
        while (Vector3.Distance(Jakob.transform.position, new Vector2(37, 38)) > 0.1f)
        {
            Jakob.transform.position = Vector3.MoveTowards(
                Jakob.transform.position,
                new Vector2(37, 38),
                speed * Time.deltaTime
            );
            yield return null;
        }
        Jakob.GetComponent<Animator>().SetBool("isMoving", false);
        dialogueManager.StartDialogue(Death.dialogueLines);
        yield return new WaitUntil(() => scene1Manager.cur > 1);
        Blood.SetActive(true);
        Tristan.transform.rotation = Quaternion.Euler(0, 0, 90);
        dialogueManager.StartDialogue(Jakob.dialogueLines);
        yield return new WaitUntil(() => scene1Manager.cur > 2);
    }
}
