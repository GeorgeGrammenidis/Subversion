using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;


public class Stage6Manager : MonoBehaviour
{
    int keys = 0;
    public GameObject wall;
    public Sprite mode1;
    public Sprite mode2;
    public Image mode;
    public TextMeshProUGUI key_count;
    public Platforming Rosa;
    public GameObject storybox;
    public Sprite image1;
    public Sprite image2;
    public Image current_image;
    public TextMeshProUGUI story;
    public static bool checkpoint = false;
    void Start()
    {
        key_count.text = "0/6 Keys";
        Platforming.keys = 0;
        if (checkpoint)
        {
            Rosa.transform.position = new Vector2(-268, 3);
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
        if (keys < 6)
        {
            key_count.text = keys.ToString() + "/6 keys";
        }
        if (keys == 6)
        {
            key_count.text = "Barier is gone";
            wall.SetActive(false);

        }

        if (Rosa.transform.position.x > -485 && Rosa.transform.position.x < -465 && Rosa.transform.position.y > -250 && Rosa.transform.position.y < -200)
        {
            storybox.SetActive(true);
            story.text = "You made a mess with no tangible results";
            current_image.sprite = image1;
        }
        else if (Rosa.transform.position.x > -460 && Rosa.transform.position.x < -448 && Rosa.transform.position.y > 334 && Rosa.transform.position.y < 350)
        {
            storybox.SetActive(true);
            story.text = "The end is near";
            current_image.sprite = image2;
        }
        else if (Rosa.transform.position.x > -455 && Rosa.transform.position.x < -435 && Rosa.transform.position.y > -190 && Rosa.transform.position.y < -140)
        {
            storybox.SetActive(true);
            story.text = "You are an insane person talking to yourself in the restroom";
            current_image.sprite = image1;
        }
        else if (Rosa.transform.position.x > -410 && Rosa.transform.position.x < -380 && Rosa.transform.position.y > -190 && Rosa.transform.position.y < -140)
        {
            storybox.SetActive(true);
            story.text = "You are doing great sweetheart";
            current_image.sprite = image2;
        }
        else if (Rosa.transform.position.x > -275 && Rosa.transform.position.x < -245 && Rosa.transform.position.y > 0 && Rosa.transform.position.y < 20)
        {
            storybox.SetActive(true);
            story.text = "The mission is insane and you are a broken crazy person";
            current_image.sprite = image1;
        }
        else
        {
            storybox.SetActive(false);
        }

        if (Rosa.transform.position.x > -268 && Rosa.transform.position.y > 2)
        {
            checkpoint = true;
        }
    }
}
