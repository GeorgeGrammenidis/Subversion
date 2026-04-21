using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageManager : MonoBehaviour
{
    public string next_scene;
    public GameObject tutorialbox;
    public Platforming Rosa;
    public TextMeshProUGUI tutorial;
    public static bool checkpoint=false;
    void Start()
    {
        tutorialbox.SetActive(false);
        if (PlayerPrefs.GetInt("Check1", 0) == 1)
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

        if (Rosa.transform.position.x > 500 && Rosa.transform.position.y > 60)
        {
            PlayerPrefs.SetInt("Check1", 1);
            checkpoint = true;
        }

    }

    public void Win()
    {
        int stagesCompleted = PlayerPrefs.GetInt("StagesCompleted", 0);
        SceneManager.LoadScene(next_scene);
    }
}
