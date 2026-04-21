using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene9Manager : MonoBehaviour
{
    public CharacterController Rosa;
    public DialogueTrigger Jakob;
    public DialogueTrigger Paul;
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
        Jakob.GetComponent<Animator>().SetBool("isMoving", true);
        Jakob.GetComponent<Animator>().SetFloat("horizontal", 0);
        Jakob.GetComponent<Animator>().SetFloat("vertical", -1);
        while (Vector3.Distance(Jakob.transform.position, new Vector2(20, -7)) > 0.1f)
        {
            Jakob.transform.position = Vector3.MoveTowards(
                Jakob.transform.position,
                new Vector2(20, -7),
                speed * Time.deltaTime
            );
            yield return null;
        }
        Jakob.GetComponent<Animator>().SetBool("isMoving", true);
        Jakob.GetComponent<Animator>().SetFloat("horizontal", 1);
        Jakob.GetComponent<Animator>().SetFloat("vertical", 0);
        while (Vector3.Distance(Jakob.transform.position, new Vector2(33, -7)) > 0.1f)
        {
            Jakob.transform.position = Vector3.MoveTowards(
                Jakob.transform.position,
                new Vector2(33, -7),
                speed * Time.deltaTime
            );
            yield return null;
        }
        Jakob.GetComponent<Animator>().SetBool("isMoving", false);
        Jakob.GetComponent<Animator>().SetFloat("horizontal", -1);
        Jakob.GetComponent<Animator>().SetFloat("vertical", 0);
        Paul.gameObject.SetActive( true );
       Rosa.canMove=true;
    }
}
