using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;

public class BonusManager : MonoBehaviour
{
    public Sprite mode1;
    public Sprite mode2;
    public Image mode;
    public Platforming Rosa;
    public GameObject storybox;
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

        if (Rosa.transform.position.x > -745 && Rosa.transform.position.x < -720 && Rosa.transform.position.y > -100 && Rosa.transform.position.y < 100)
        {
            storybox.SetActive(true);
            story.text = "It's been so long...";
        }
        else if (Rosa.transform.position.x > 3450 && Rosa.transform.position.x < 500 && Rosa.transform.position.y > 100 && Rosa.transform.position.y < -100)
        {
            storybox.SetActive(true);
            story.text = "Will it ever be the same...";
        }
        else
        {
            storybox.SetActive(false);
        }
    }
}
