using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2Manager : MonoBehaviour
{
    public string next_scene;
    public GameObject storybox;
    public Platforming Rosa;
    public TextMeshProUGUI story;
    public static bool checkpoint = false;
    void Start()
    {
        storybox.SetActive(false);
        if (checkpoint)
        {
            Rosa.transform.position = new Vector2(3, 296);
        }
    }


    void Update()
    {
        


        if (Rosa.transform.position.x > -20 && Rosa.transform.position.x < -4 && Rosa.transform.position.y > 227 && Rosa.transform.position.y < 240)
        {
            storybox.SetActive(true);
            story.text = "Who are you?";
        }
        else if (Rosa.transform.position.x > 80 && Rosa.transform.position.x < 378 && Rosa.transform.position.y > 310 && Rosa.transform.position.y < 380)
        {
            storybox.SetActive(true);
            story.text = "Why are you alone outside this late at night?";
        }
        else if (Rosa.transform.position.x > -50 && Rosa.transform.position.x < 13 && Rosa.transform.position.y > 294 && Rosa.transform.position.y < 350)
        {
            storybox.SetActive(true);
            story.text = "You seem like you are not from around here";
        }
        else if (Rosa.transform.position.x > -120 && Rosa.transform.position.x < -50 && Rosa.transform.position.y > 294 && Rosa.transform.position.y < 350)
        {
            storybox.SetActive(true);
            story.text = "Female foreigner alone late at night?";
        }
        else if (Rosa.transform.position.x > -500 && Rosa.transform.position.x < -480 && Rosa.transform.position.y > 328 && Rosa.transform.position.y < 340)
        {
            storybox.SetActive(true);
            story.text = "You are very suspicious";
        }
        else
        {
            storybox.SetActive(false);
        }

        if (Rosa.transform.position.x < 3 && Rosa.transform.position.y > 294)
        {
            checkpoint = true;
        }






    }

    public void Win()
    {
        int stagesCompleted = PlayerPrefs.GetInt("StagesCompleted", 0);
        SceneManager.LoadScene(next_scene);
    }
}
