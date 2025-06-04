using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageManager : MonoBehaviour
{
    public string next_scene;
    public GameObject storybox;
    public GameObject tutorialbox;
    public Platforming Rosa;
    public TextMeshProUGUI story;
    public TextMeshProUGUI tutorial;
    public static bool checkpoint=false;
    void Start()
    {
        storybox.SetActive(false);
        tutorialbox.SetActive(false);
        if (checkpoint)
        {
            Rosa.transform.position = new Vector2(503, 68);
        }
    }

    
    void Update()
    {
        if (Rosa.transform.position.x > -24 && Rosa.transform.position.x < -7 )
        {
            tutorialbox.SetActive( true );
            tutorial.text = "W to go left A to go right J to jump";
        }
        else if (Rosa.transform.position.x > 32 && Rosa.transform.position.x < 70)
        {
            tutorialbox.SetActive(true);
            tutorial.text = "Jump high and press K when falling to bounce. The closest to the ground you press K, the higher the bounce";
        }
        else if (Rosa.transform.position.x > 100 && Rosa.transform.position.x < 120)
        {
            tutorialbox.SetActive(true);
            tutorial.text = "Press H to bounce as well. These bounces are shorter, but you can do multiple in a row";
        }
        else if (Rosa.transform.position.x > 195 && Rosa.transform.position.x < 230)
        {
            tutorialbox.SetActive(true);
            tutorial.text = "When you collect a crystal, you can do one extra jump in the air";
        }
        else if (Rosa.transform.position.x > 264 && Rosa.transform.position.x < 276)
        {
            tutorialbox.SetActive(true);
            tutorial.text = "The height of your bounce depends on not only where you transform but also where you STARTED falling. Keep that in mind";
        }
        else if (Rosa.transform.position.x > 490 && Rosa.transform.position.x < 500)
        {
            tutorialbox.SetActive(true);
            tutorial.text = "You can wall jump!";
        }
        else if (Rosa.transform.position.x > 686 && Rosa.transform.position.x < 690)
        {
            tutorialbox.SetActive(true);
            tutorial.text = "Pick the correct bounce";
        }
        else if (Rosa.transform.position.x > 710 && Rosa.transform.position.x < 720)
        {
            tutorialbox.SetActive(true);
            tutorial.text = "You can bounce on moving platforms too!";
        }
        else
        {
            tutorialbox.SetActive( false );
        }


        if (Rosa.transform.position.x > 322 && Rosa.transform.position.x < 330)
        {
            storybox.SetActive(true);
            story.text = "ROSA JUST LEAVE ME HERE AND CONTINUE YOUR LIFE";
        }
        else if (Rosa.transform.position.x > 520 && Rosa.transform.position.x < 530 && Rosa.transform.position.y > 88 && Rosa.transform.position.y < 95)
        {
            storybox.SetActive(true);
            story.text = "ROSA DON'T DO THE MISSION. DON'T DIE FOR ME.";
        }
        else if (Rosa.transform.position.x > 522 && Rosa.transform.position.x < 550 && Rosa.transform.position.y > 180 && Rosa.transform.position.y < 190)
        {
            storybox.SetActive(true);
            story.text = "ROSA HOW WILL I KNOW IF YOU ARE ALIVE OR DEAD";
        }
        else if (Rosa.transform.position.x > 700 && Rosa.transform.position.x < 720 && Rosa.transform.position.y > 280 && Rosa.transform.position.y < 290)
        {
            storybox.SetActive(true);
            story.text = "ROSA PLEASE YOU DON'T HAVE TO DO THIS";
        }
        else if (Rosa.transform.position.x > 810 && Rosa.transform.position.x < 850 )
        {
            storybox.SetActive(true);
            story.text = "ROSA I LOVE YOU";
        }
        else
        {
            storybox.SetActive(false);
        }

        if (Rosa.transform.position.x > 500 && Rosa.transform.position.y > 60)
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
