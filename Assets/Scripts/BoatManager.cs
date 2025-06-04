using System.Collections;
using System.Security.Cryptography;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatManager : MonoBehaviour
{
    public GameObject Boat;
    private float horizontalInput;
    public float speed;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;
    public TextMeshProUGUI characterNameText;
    public Image characterImage;
    public Sprite Rosa;
    Rigidbody2D body;
    void Start()
    {
        body = Boat.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (Boat.transform.position.x > -20 && Boat.transform.position.x < -10)
        {
            dialogueBox.SetActive(true);
            dialogueText.text = "So this is how I found myself in this insane predicament. I was scared out of my mind. The stakes were abnormally high... If I failed, best case scenario Alyx dies in prison, betrayed and abandoned by me...Worst case scenario, the Raxlians invade and it's game over for my nation...";
            characterNameText.text = "Rosa";
            characterImage.sprite = Rosa;
        }
        else if (Boat.transform.position.x > 0 && Boat.transform.position.x < 10 )
        {
            dialogueBox.SetActive(true);
            dialogueText.text = "But I did have some confidence. Besides my standard training in martial arts and weaponry, my deductive skills, my people reading skills, my pattern recognition skills and my gaslighting skills are second to none.";
            characterImage.sprite = Rosa;
        }
        else if (Boat.transform.position.x > 20 && Boat.transform.position.x < 30)
        {
            dialogueBox.SetActive(true);
            dialogueText.text = "My immediate priority was to settle in, make some local friends, speak to people, get informed on all the news and get a broader image of the country..";
            characterImage.sprite = Rosa;
        }
        else if (Boat.transform.position.x > 40)
        {
            Initiate.Fade("Chapter2.2", Color.black, 0.5f);
        }
        else
        {
            dialogueBox.SetActive(false);
        }
    }
}
