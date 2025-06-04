using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;

public class Stage5Manager : MonoBehaviour
{
    static int keys = 0;
    public GameObject wall;
    public Sprite mode1;
    public Sprite mode2;
    public Image mode;
    public Platforming player;
    public TextMeshProUGUI key_count;
    public GameObject storybox;
    public Sprite image1;
    public Image current_image;
    public Platforming Rosa;
    public TextMeshProUGUI story;
    public static bool checkpoint = false;
    public TextMeshProUGUI tutorial;
    public Key key1;
    public Key key2;
    public Key key3;
    public Key key4;
    public Key key5;
    public static bool key1collected = false;
    public static bool key2collected = false;
    public static bool key3collected = false;
    public static bool key4collected = false;
    public static bool key5collected = false;
    void Start()
    {
        if (checkpoint)
        {
            Rosa.transform.position = new Vector2(127, 268);
        }
    }

    void Update()
    {
        if (key1.isCollected)
        {
            key1collected = true;
        }
        if (key2.isCollected)
        {
            key2collected = true;
        }
        if (key3.isCollected)
        {
            key3collected = true;
        }
        if (key4.isCollected)
        {
            key4collected = true;
        }
        if (key5.isCollected)
        {
            key5collected = true;
        }

        if (key1collected)
        {
            key1.gameObject.SetActive(false);
        }
        if (key2collected)
        {
            key2.gameObject.SetActive(false);
        }
        if (key3collected)
        {
            key3.gameObject.SetActive(false);
        }
        if (key4collected)
        {
            key4.gameObject.SetActive(false);
        }
        if (key5collected)
        {
            key5.gameObject.SetActive(false);
        }
        keys = Platforming.keys;
        if (player.swap == false)
        {
            mode.sprite = mode1;
        }
        else
        {
            mode.sprite = mode2;
        }
        if (keys < 5)
        {
            key_count.text = keys.ToString() + "/5 keys";
        }
        if (keys == 5)
        {
            key_count.text = "The floor has disappeared";
            wall.SetActive(false);
            
        }



        if (Rosa.transform.position.x > 60 && Rosa.transform.position.x < 130 && Rosa.transform.position.y > 260 && Rosa.transform.position.y < 280)
        {
            storybox.SetActive(true);
            story.text = "I can't be the only one noticing a pattern here";
            current_image.sprite = image1;
        }
        else if (Rosa.transform.position.x > 10 && Rosa.transform.position.x < 100 && Rosa.transform.position.y > 330 && Rosa.transform.position.y < 380)
        {
            storybox.SetActive(true);
            story.text = "We don't know anything about her";
            current_image.sprite = image1;
        }
        else if (Rosa.transform.position.x > -144 && Rosa.transform.position.x < -122 && Rosa.transform.position.y > 399 && Rosa.transform.position.y < 410)
        {
            storybox.SetActive(true);
            story.text = "We let a stranger in and see what we got";
            current_image.sprite = image1;
        }
        else if (Rosa.transform.position.x > -200 && Rosa.transform.position.x < 256 && Rosa.transform.position.y > 640 && Rosa.transform.position.y < 700)
        {
            storybox.SetActive(true);
            story.text = "She killed everyone";
            current_image.sprite = image1;
        }
        else
        {
            storybox.SetActive(false);
        }

        if (Rosa.transform.position.x < 127 && Rosa.transform.position.y > 260)
        {
            checkpoint = true;
        }
    }
}

