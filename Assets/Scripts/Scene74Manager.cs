using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene74Manager : MonoBehaviour
{
    public DialogueTrigger Tristan;
    public GameObject Saleghdu;
    public GameObject Dhelu;
    public CharacterController Rosa;
    public DialogueTrigger Monty;
    public DialogueManager dialogueManager;
    public GameObject Dragon;
    bool doonce = true;
    public Scene1Manager scene1Manager;
    int speed = 5;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (scene1Manager.cur> 0 && doonce)
        {
            doonce = false;
            StartCoroutine(StartSequence());
        }
    }

    private IEnumerator StartSequence()
    {
        Rosa.canMove = false;
        Dragon.GetComponent<Animator>().SetBool("isMoving", true);
        Dragon.GetComponent<Animator>().SetFloat("horizontal", -1);
        Dragon.GetComponent<Animator>().SetFloat("vertical", 0);
        while (Vector3.Distance(Dhelu.transform.position, new Vector2(6, -10)) > 0.1f && Vector3.Distance(Saleghdu.transform.position, new Vector2(6, -10)) > 0.1f && Vector3.Distance(Dragon.transform.position, new Vector2(-15, 0)) > 0.1f)
        {
            Dhelu.transform.position = Vector3.MoveTowards(
                Dhelu.transform.position,
                new Vector2(6, -10),
                speed * Time.deltaTime
            );
            
            Saleghdu.transform.position = Vector3.MoveTowards(
               Saleghdu.transform.position,
               new Vector2(6, -10),
               speed * Time.deltaTime
           );
           
            Dragon.transform.position = Vector3.MoveTowards(
                Dragon.transform.position,
                new Vector2(-15, 0),
                speed * Time.deltaTime
            );
            yield return null;
        }
        Dhelu.SetActive(false);
        Saleghdu.SetActive(false);
        Dragon.SetActive(false);

        dialogueManager.StartDialogue(Tristan.dialogueLines);
        yield return new WaitUntil(() => scene1Manager.cur > 1);

        Tristan.GetComponent<Animator>().SetBool("isMoving", true);
        Tristan.GetComponent<Animator>().SetFloat("horizontal", 1);
        Tristan.GetComponent<Animator>().SetFloat("vertical", 0);
        while (Vector3.Distance(Tristan.transform.position, new Vector2(15, 0)) > 0.1f)
        {
            Tristan.transform.position = Vector3.MoveTowards(
                Tristan.transform.position,
                new Vector2(15, 0),
                speed * Time.deltaTime
            );
            yield return null;
        }
        Tristan.gameObject.SetActive( false );

        dialogueManager.StartDialogue(Monty.dialogueLines);
        yield return new WaitUntil(() => scene1Manager.cur > 2);
    }

}
