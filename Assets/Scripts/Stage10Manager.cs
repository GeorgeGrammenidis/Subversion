using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;

public class Stage10Manager : MonoBehaviour
{
    int keys = 0;
    public GameObject Wall;
    public Sprite mode1;
    public Sprite mode2;
    public Image mode;
    public TextMeshProUGUI key_count;
    public Platforming Rosa;
    public static bool checkpoint = false;
    public GameObject storybox;
    public TextMeshProUGUI story;
    public Enemy enemy;
    void Start()
    {
        Platforming.keys = 0;
        if (checkpoint)
        {
            Rosa.transform.position = new Vector2(261, 16);
            enemy.transform.position = new Vector2(211, 16);
            Platforming.keys = 5;
            Wall.SetActive(false);
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
        if (keys < 5)
        {
            key_count.text = keys.ToString() + "/5 keys";
        }
        if (keys >= 5)
        {
            key_count.text = "Gate Open";
            Wall.SetActive(false);

        }



        if (Rosa.transform.position.x > 100 && Rosa.transform.position.x < 130 && Rosa.transform.position.y > -7 && Rosa.transform.position.y < 20)
        {
            storybox.SetActive(true);
            story.text = "I can't trust a complete stranger";
        }
        else if (Rosa.transform.position.x > 403 && Rosa.transform.position.x < 424 && Rosa.transform.position.y > 121 && Rosa.transform.position.y < 150)
        {
            storybox.SetActive(true);
            story.text = "Who do you think you are";
        }
        else if (Rosa.transform.position.x > -515 && Rosa.transform.position.x < -480 && Rosa.transform.position.y > 535 && Rosa.transform.position.y < 555)
        {
            storybox.SetActive(true);
            story.text = "We have been doing this for years";
        }
        else if (Rosa.transform.position.x > -655 && Rosa.transform.position.x < -580 && Rosa.transform.position.y > 600 && Rosa.transform.position.y < 650)
        {
            storybox.SetActive(true);
            story.text = "Do you think you are better than us";
        }
        else
        {
            storybox.SetActive(false);
        }

        if (Rosa.transform.position.x > 217 && Rosa.transform.position.y > -3)
        {
            checkpoint = true;
        }
    }
}