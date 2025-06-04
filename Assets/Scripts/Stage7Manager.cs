using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;

public class Stage7Manager : MonoBehaviour
{
    static int keys = 0;
    static int placeholder_keys=0;
    public GameObject End;
    public Sprite mode1;
    public Sprite mode2;
    public Image mode;
    public TextMeshProUGUI key_count;
    public Platforming Rosa;
    public GameObject storybox;
    public TextMeshProUGUI story;
    public Key key1;
    public Key key2;
    public Key key3;
    public Key key4;
    public static bool key1collected = false;
    public static bool key2collected = false;
    public static bool key3collected = false;
    public static bool key4collected = false;
    void Start()
    {
        key_count.text = "0/4 Keys";
        End.SetActive(false);
    }

    // Update is called once per frame
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
        
        keys = Platforming.keys;
        if (Rosa.swap == false)
        {
            mode.sprite = mode1;
        }
        else
        {
            mode.sprite = mode2;
        }
        if (keys < 4)
        {
            key_count.text = keys.ToString() + "/4 keys";
        }
        if (keys == 4)
        {
            key_count.text = "Return to Start";
            End.SetActive(true);

        }
        if (Rosa.transform.position.x > -1050 && Rosa.transform.position.x < -1000 && Rosa.transform.position.y > -332 && Rosa.transform.position.y < 0)
        {
            storybox.SetActive(true);
            story.text = "It's too late now";
        }
        else if (Rosa.transform.position.x > -910 && Rosa.transform.position.x < -870 && Rosa.transform.position.y > -332 && Rosa.transform.position.y < 0)
        {
            storybox.SetActive(true);
            story.text = "All is lost";
        }
        else if (Rosa.transform.position.x > -740 && Rosa.transform.position.x < -716 && Rosa.transform.position.y > -332 && Rosa.transform.position.y < 0)
        {
            storybox.SetActive(true);
            story.text = "This is a suicide mission";
        }
        else if (Rosa.transform.position.x > -632 && Rosa.transform.position.x < -606 && Rosa.transform.position.y > -332 && Rosa.transform.position.y < 0)
        {
            storybox.SetActive(true);
            story.text = "You are gonna mess up and compromise me too";
        }
        else
        {
            storybox.SetActive(false);
        }
    }
}
