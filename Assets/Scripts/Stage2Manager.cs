using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2Manager : MonoBehaviour
{
    public string next_scene;
    public Platforming Rosa;
    public static bool checkpoint = false;
    void Start()
    {
        if (PlayerPrefs.GetInt("Check2", 0)==1)
        {
            Rosa.transform.position = new Vector2(3, 296);
        }
    }


    void Update()
    {

        if (Rosa.transform.position.x < 3 && Rosa.transform.position.y > 294)
        {
            PlayerPrefs.SetInt("Check2", 1);
        }


    }

    public void Win()
    {
        int stagesCompleted = PlayerPrefs.GetInt("StagesCompleted", 0);
        SceneManager.LoadScene(next_scene);
    }
}
