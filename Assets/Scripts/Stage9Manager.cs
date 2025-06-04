using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;


public class Stage9Manager : MonoBehaviour
{
    public Sprite mode1;
    public Sprite mode2;
    public Image mode;
    public GameObject storybox;
    public Platforming Rosa;
    public TextMeshProUGUI story;
    public static bool checkpoint = false;
    void Start()
    {
        storybox.SetActive(false);
        if (checkpoint)
        {
            Rosa.transform.position = new Vector2(-113, 75);
        }
    }

    void Update()
    {
        if (Rosa.swap == false)
        {
            mode.sprite = mode1;
        }
        else
        {
            mode.sprite = mode2;
        }

        if (Rosa.transform.position.x > -140 && Rosa.transform.position.x < -120 && Rosa.transform.position.y > -30 && Rosa.transform.position.y < 0)
        {
            storybox.SetActive(true);
            story.text = "But do you really love me";
        }
        else if (Rosa.transform.position.x > 60 && Rosa.transform.position.x < 80 && Rosa.transform.position.y > -25 && Rosa.transform.position.y < 0)
        {
            storybox.SetActive(true);
            story.text = "How can I trust you?";
        }
        else if (Rosa.transform.position.x > 180 && Rosa.transform.position.x < 210 && Rosa.transform.position.y > -13 && Rosa.transform.position.y < 3)
        {
            storybox.SetActive(true);
            story.text = "This is all happening so fast...";
        }
        else if (Rosa.transform.position.x > -120 && Rosa.transform.position.x < -100 && Rosa.transform.position.y > 65 && Rosa.transform.position.y < 85)
        {
            storybox.SetActive(true);
            story.text = "This is too good to be real";
        }
        else if (Rosa.transform.position.x > 110 && Rosa.transform.position.x < 130 && Rosa.transform.position.y > 125 && Rosa.transform.position.y < 140)
        {
            storybox.SetActive(true);
            story.text = "Is this really happening?";
        }
        else
        {
            storybox.SetActive(false);
        }

        if (Rosa.transform.position.y > 70 && Rosa.transform.position.x < -100)
        {
            checkpoint = true;
        }
    }
}
