using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;

public class Stage8Manager : MonoBehaviour
{
    public Sprite mode1;
    public Sprite mode2;
    public Image mode;
    public Platforming Rosa;
    public GameObject storybox;
    public Sprite image1;
    public Sprite image2;
    public Image current_image;
    public TextMeshProUGUI story;

    void Start()
    {
        
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
        
        if (Rosa.transform.position.x > 0 && Rosa.transform.position.x < 40 && Rosa.transform.position.y > -19 && Rosa.transform.position.y < 6)
        {
            storybox.SetActive(true);
            story.text = "I AM A PERSON NOT A MEANS TO AN END";
            current_image.sprite = image1;
        }
        else if (Rosa.transform.position.x > 82 && Rosa.transform.position.x < 95 && Rosa.transform.position.y > 218 && Rosa.transform.position.y < 230)
        {
            storybox.SetActive(true);
            story.text = "You are a monster.";
            current_image.sprite = image1;
        }
        else if (Rosa.transform.position.x > 308 && Rosa.transform.position.x < 320 && Rosa.transform.position.y > 265 && Rosa.transform.position.y < 278)
        {
            storybox.SetActive(true);
            story.text = "You took advantage of my love";
            current_image.sprite = image1;
        }
        else if (Rosa.transform.position.x > 610 && Rosa.transform.position.x < 630 && Rosa.transform.position.y > 212 && Rosa.transform.position.y < 222)
        {
            storybox.SetActive(true);
            story.text = "You killed my mother";
            current_image.sprite = image1;
        }
        else if (Rosa.transform.position.x > 820 && Rosa.transform.position.x < 836 && Rosa.transform.position.y > 197 && Rosa.transform.position.y < 210)
        {
            storybox.SetActive(true);
            story.text = "Rosa don't look focus. You can do this. You are in control";
            current_image.sprite = image2;
        }
        else
        {
            storybox.SetActive(false);
        }
    }
}
