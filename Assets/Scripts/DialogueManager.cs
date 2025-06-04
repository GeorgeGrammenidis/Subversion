using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;
    public CharacterController playerController;
    public Dictionary<string, Sprite> characterSprites = new Dictionary<string, Sprite>();
    public TextMeshProUGUI characterNameText;   
    public Image characterImage;
    public Sprite Rosa;
    public Sprite Alex;
    public Sprite Guard;
    public Sprite Boss;
    public Sprite Stranger1;
    public Sprite Stranger2;
    public Sprite Stranger3;
    public Sprite Barman;
    public Sprite Officer;
    public Sprite Ego;
    public Sprite SuperEgo;
    public Sprite Id;
    public Sprite Tristan;
    public Sprite Paul;
    public Sprite Coworker;
    public Sprite Jakob;
    public Sprite Selm;
    public Sprite Angel;
    public Sprite Monty;
    public Sprite Dabrovnu;
    public Sprite Dresda;
    public Sprite Saleghdu;
    public Sprite Lexa;
    public Sprite Dragon;
    public Sprite Delu;
    public Sprite Gladoru;
    public Sprite Irene;
    public Sprite Nava;
    public Sprite Isota;
    public Sprite Dabstra;

    public Scene1Manager scene1Manager;
    

    public float textspeed = 0.1f;

    private string[] lines;
    private int index;
    private bool isDialogueActive = false;
    string characterName;
    string dialogueLine;

    void Start()
    {
        dialogueBox.SetActive(false);
    }

    public void StartDialogue(string[] lines)
    {
        this.lines = lines; 
        index = 0;
        dialogueBox.SetActive(true);
        isDialogueActive = true;
        playerController.EnableMovement(false); 
        NextLine();
    }

    void Update()
    {
        
        if (isDialogueActive && Input.GetKeyDown(KeyCode.J))
        {
            if (dialogueText.text == dialogueLine)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLine;

            }
           
        }
    }

    IEnumerator TypeLine()
    {
        
        foreach (char c in dialogueLine.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length )
        {
            SetUp();
            index++;
            dialogueText.text = string.Empty;
           
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueBox.SetActive(false);  
            isDialogueActive = false;      
            playerController.EnableMovement(true);
            scene1Manager.cur++;
        }
    }

    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }

    public void SetUp()
    {
        string line = lines[index];
        string[] parts = line.Split(new string[] { ":" }, 2, System.StringSplitOptions.None);
        characterName = parts.Length > 1 ? parts[0].Trim() : "Unknown";
        characterNameText.text = characterName;
        dialogueLine = parts.Length > 1 ? parts[1].Trim() : line;
        if (characterName.Equals("Rosa"))
        {
            characterImage.sprite = Rosa;
        }
        else if (characterName.Equals("Alyx") || characterName.Equals("Alex"))
        {
            characterName = "Alex";
            characterImage.sprite = Alex;
        }
        else if (characterName.Equals("Guard"))
        {
            characterImage.sprite = Guard;
        }
        else if (characterName.Equals("Spy Boss"))
        {
            characterImage.sprite = Boss;
        }
        else if (characterName.Equals("Stranger 1"))
        {
            characterImage.sprite = Stranger1;
        }
        else if (characterName.Equals("Stranger 2"))
        {
            characterImage.sprite = Stranger2;
        }
        else if (characterName.Equals("Stranger 3"))
        {
            characterImage.sprite = Stranger3;
        }
        else if (characterName.Equals("Barman"))
        {
            characterImage.sprite = Barman;
        }
        else if (characterName.Equals("Officer 1") || characterName.Equals("Officer 2"))
        {
            characterImage.sprite = Officer;
        }else if (characterName.Equals("Super Ego"))
        {
            characterImage.sprite = SuperEgo;
        }
        else if (characterName.Equals("Id") || characterName.Equals("ID"))
        {
            characterImage.sprite = Id;
        }
        else if (characterName.Equals("Ego"))
        {
            characterImage.sprite = Ego;
        }
        else if (characterName.Equals("Tristan"))
        {
            characterImage.sprite = Tristan;
        }
        else if (characterName.Equals("Coworker"))
        {
            characterImage.sprite = Coworker;
        }
        else if (characterName.Equals("Boss"))
        {
            characterImage.sprite = Boss;
        }
        else if (characterName.Equals("Selm"))
        {
            characterImage.sprite = Selm;
        }
        else if (characterName.Equals("Angel"))
        {
            characterImage.sprite = Angel;
        }
        else if (characterName.Equals("Dabrovnu"))
        {
            characterImage.sprite = Dabrovnu;
        }
        else if (characterName.Equals("Irene"))
        {
            characterImage.sprite = Irene;
        }
        else if (characterName.Equals("Dragon"))
        {
            characterImage.sprite = Dragon;
        }
        else if (characterName.Equals("Lexa"))
        {
            characterImage.sprite = Lexa;
        }
        else if (characterName.Equals("Saleigdu") || characterName.Equals("Saleighdu"))
        {
            characterName = "Saleigdu";
            characterImage.sprite = Saleghdu;
        }
        else if (characterName.Equals("Gladoru"))
        {
            characterImage.sprite = Gladoru;
        }
        else if (characterName.Equals("Nava"))
        {
            characterImage.sprite = Nava;
        }
        else if (characterName.Equals("Dhelu"))
        {
            characterImage.sprite = Delu;
        }
        else if (characterName.Equals("Dresda"))
        {
            characterImage.sprite = Dresda;
        }
        else if (characterName.Equals("Drabstra"))
        {
            characterImage.sprite = Dabstra;
        }
        else if (characterName.Equals("Isota"))
        {
            characterImage.sprite = Isota;
        }
        else if (characterName.Equals("Monty"))
        {
            characterImage.sprite = Monty;
        }
        else if (characterName.Equals("Drabsta") || characterName.Equals("Dabstra"))
        {
            characterName = "Dabstra";
            characterImage.sprite = Dabstra;
        }
        else if (characterName.Equals("Jakob"))
        {
            characterImage.sprite = Jakob;
        }
        else if (characterName.Equals("Paul"))
        {
            characterImage.sprite = Paul;
        }
    }
}
