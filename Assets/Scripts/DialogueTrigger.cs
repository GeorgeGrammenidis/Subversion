using UnityEngine;
using System.Collections;
public class DialogueTrigger : MonoBehaviour
{
    public string[] dialogueLines;
    // public string[][] test;
    public DialogueManager dialogueManager;
    public bool autoTrigger = false;
    public CharacterController player;
    public bool hasSpoken = false;
    private bool isPlayerNearby = false;
    public float X;
    public float Y;
    public float X2=100;
    public float Y2=100;

    void Start()
    {
        if (dialogueManager == null)
        {
            dialogueManager = FindObjectOfType<DialogueManager>();
        }
    }

    void Update()
    {
        if (player.transform.position.y > Y && player.transform.position.x > X && !hasSpoken && player.transform.position.y < Y2 && player.transform.position.x < X2 && !dialogueManager.IsDialogueActive() && autoTrigger)
        {
            
            dialogueManager.StartDialogue(dialogueLines);
            hasSpoken = true;

        }
        if (!autoTrigger && isPlayerNearby  && !dialogueManager.IsDialogueActive() && !hasSpoken)
        {
            
            dialogueManager.StartDialogue(dialogueLines);
            hasSpoken = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rosa") && Input.GetKeyDown(KeyCode.J) )
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Rosa"))
        {
            isPlayerNearby = false;
        }
    }

    public IEnumerator AutoTriggerDialogue()
    {
        yield return new WaitForSeconds(0.1f);
        dialogueManager.StartDialogue(dialogueLines);
    }
}
