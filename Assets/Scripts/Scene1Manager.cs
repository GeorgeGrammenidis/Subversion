using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1Manager : MonoBehaviour
{
    public int max = 2;
    public int cur = 0;
    public string next_scene;
    int stagesCompleted;
    void Start()
    {
        stagesCompleted = PlayerPrefs.GetInt("StagesCompleted", 0);
    }

    
    void Update()
    {
        if (cur == max)
        {
            Initiate.Fade(next_scene, Color.black, 0.5f);
            //SceneManager.LoadScene(next_scene);
        }
    }
}
