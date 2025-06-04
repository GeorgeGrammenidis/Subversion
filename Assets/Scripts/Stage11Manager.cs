using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;

public class Stage11Manager : MonoBehaviour
{
    int keys = 0;
    public Sprite mode1;
    public Sprite mode2;
    public Image mode;
    public GameObject storybox;
    public Platforming Rosa;
    public TextMeshProUGUI story;
    static bool checkpoint;
    void Start()
    {
        if (checkpoint)
        {
            Rosa.transform.position = new Vector2(-160, 118);
        }
    }

    void Update()
    {
        keys = Platforming.keys;
        if (Rosa.swap == false)
        {
            mode.sprite = mode1;
        }
        else
        {
            mode.sprite = mode2;
        }

        if (Rosa.transform.position.x > -10 && Rosa.transform.position.x < 10 && Rosa.transform.position.y > -10 && Rosa.transform.position.y < 10)
        {
            storybox.SetActive(true);
            story.text = "We can't let just anyone here";
        }
        else if (Rosa.transform.position.x > -165 && Rosa.transform.position.x < -155 && Rosa.transform.position.y > 110 && Rosa.transform.position.y < 120)
        {
            storybox.SetActive(true);
            story.text = "You are not even from around here";
        }
        else if (Rosa.transform.position.x > 805 && Rosa.transform.position.x < 820 && Rosa.transform.position.y > 295 && Rosa.transform.position.y < 340)
        {
            storybox.SetActive(true);
            story.text = "What are your intentions with our boy";
        }
        else if (Rosa.transform.position.x > -980 && Rosa.transform.position.x < -960 && Rosa.transform.position.y > 515 && Rosa.transform.position.y < 530)
        {
            storybox.SetActive(true);
            story.text = "What do you want from us";
        }
        else
        {
            storybox.SetActive(false);
        }

        if (Rosa.transform.position.y > 112)
        {
            checkpoint = true;
        }
    }
}