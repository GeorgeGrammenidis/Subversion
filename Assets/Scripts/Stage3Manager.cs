using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;

public class Stage3Manager : MonoBehaviour
{
    static int keys = 0;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public Sprite mode1;
    public Sprite mode2;
    public Image mode;
    public Platforming player;
    public TextMeshProUGUI key_count;
    public GameObject storybox;
    public GameObject tutorialbox;
    public Sprite image1;
    public Sprite image2;
    public Image current_image;
    public Platforming Rosa;
    public TextMeshProUGUI story;
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
            key_count.text = "Gate Open";
            wall1.SetActive(false);
            wall2.SetActive(false);
            wall3.SetActive(false);
        }


        if (Rosa.transform.position.x > -22 && Rosa.transform.position.x < -6 && Rosa.transform.position.y > 269 && Rosa.transform.position.y < 282)
        {
            tutorialbox.SetActive(true);
            tutorial.text = "Press U to switch modes. Now you can press H to hit green boosters. Hitting them allows you an extra jump in the air.";
        }
        else if (Rosa.transform.position.x > -8.5 && Rosa.transform.position.x < 2.5 && Rosa.transform.position.y > 280 && Rosa.transform.position.y < 290)
        {
            tutorialbox.SetActive(true);
            tutorial.text = "Press U to switch back to normal. Now you can use H again to string bounces. Switch between the two when appropriate.";
        }
        else if (Rosa.transform.position.x > 62 && Rosa.transform.position.x < 80 && Rosa.transform.position.y > 273 && Rosa.transform.position.y < 280)
        {
            tutorialbox.SetActive(true);
            tutorial.text = "Collect five keys to open the gate";
        }
        else if (Rosa.transform.position.x > 98 && Rosa.transform.position.x < 108 && Rosa.transform.position.y > 279 && Rosa.transform.position.y < 285) { 
            tutorialbox.SetActive(true);
            tutorial.text = "Keep hitting green boosters and jumping to stay airborne";
        }
        else
        {
            tutorialbox.SetActive(false);
        }

        if (Rosa.transform.position.x > -33 && Rosa.transform.position.x < -8 && Rosa.transform.position.y > 441 && Rosa.transform.position.y < 445)
        {
            storybox.SetActive(true);
            story.text = "RUN AWAY ROSA IT'S NOT WORTH IT";
            current_image.sprite = image1;
        }
        else if (Rosa.transform.position.x > 207 && Rosa.transform.position.x < 249 && Rosa.transform.position.y > 334 && Rosa.transform.position.y < 350)
        {
            storybox.SetActive(true);
            story.text = "ROSA DON'T LOSE FOCUS.";
            current_image.sprite = image2;
        }
        else if (Rosa.transform.position.x > 331 && Rosa.transform.position.x < 387 && Rosa.transform.position.y > 418 && Rosa.transform.position.y < 425)
        {
            storybox.SetActive(true);
            story.text = "ROSA THIS IS SUICIDE";
            current_image.sprite = image1;
        }
        else if (Rosa.transform.position.x > 244 && Rosa.transform.position.x < 256 && Rosa.transform.position.y > 266 && Rosa.transform.position.y < 275)
        {
            storybox.SetActive(true);
            story.text = "FOR ALEX AND XANDOVIA";
            current_image.sprite = image2;
        }
        else
        {
            storybox.SetActive(false);
        }


    }

    
}
