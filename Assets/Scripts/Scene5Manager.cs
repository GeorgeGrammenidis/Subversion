using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Scene5Manager : MonoBehaviour
{
    public CharacterController Rosa;
    public DialogueTrigger Tristan;
    public GameObject Isota;
    public GameObject Dabstra;
    public DialogueTrigger Monty;
    public DialogueManager dialogueManager;
    public DialogueTrigger Continue;
    public GameObject door;
    public Scene1Manager scene1Manager;
    public int speed = 2;
    bool do_once = true;
    void Start()
    {
        
    }

    void Update()
    {
        if (scene1Manager.cur >0 && do_once==true)
        {
            do_once = false;
            StartCoroutine(StartSequence());
        }
        if (scene1Manager.cur >= 3)
        {
            door.SetActive(false);
        }
    }

    private IEnumerator StartSequence()
    {
        
        Tristan.transform.position = new Vector2(-5, 0);
        Tristan.GetComponent<Animator>().SetBool("isMoving", true);
        Tristan.GetComponent<Animator>().SetFloat("horizontal" , -1);
        Tristan.GetComponent<Animator>().SetFloat("vertical", 0);
        

        while (Vector3.Distance(Tristan.transform.position, new Vector2(-12, 0)) > 0.1f)
        {
            Tristan.transform.position = Vector3.MoveTowards(
                Tristan.transform.position,
                new Vector2(-12, 0),
                speed * Time.deltaTime
            );
            yield return null; 
        }
        Tristan.transform.position = new Vector2(-12, 0);
        Tristan.GetComponent<Animator>().SetBool("isMoving", false);
        dialogueManager.StartDialogue(Tristan.dialogueLines);
        yield return new WaitUntil(() => scene1Manager.cur>1);
        Monty.GetComponent<Animator>().SetBool("isMoving", true);
        Monty.GetComponent<Animator>().SetFloat("horizontal", 0);
        Monty.GetComponent<Animator>().SetFloat("vertical", -1);
        while (Vector3.Distance(Monty.transform.position, new Vector2(-16, 0)) > 0.1f)
        {
            Monty.transform.position = Vector3.MoveTowards(
                Monty.transform.position,
                new Vector2(-16, 0),
                speed * Time.deltaTime
            );
            yield return null; 
        }
        Monty.GetComponent<Animator>().SetFloat("horizontal", 1);
        Monty.GetComponent<Animator>().SetFloat("vertical", 0);
        while (Vector3.Distance(Monty.transform.position, new Vector2(2, 0)) > 0.1f)
        {
            Monty.transform.position = Vector3.MoveTowards(
                Monty.transform.position,
                new Vector2(2, 0),
                speed * Time.deltaTime
            );
            yield return null;
        }
        Tristan.GetComponent<Animator>().SetBool("isMoving", false);
        Monty.gameObject.SetActive(false);
        Isota.SetActive(true);
        Dabstra.SetActive(true);
        Continue.gameObject.SetActive(true);
    }

}
