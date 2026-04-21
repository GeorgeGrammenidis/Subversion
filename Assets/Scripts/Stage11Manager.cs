using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;

public class Stage11Manager : MonoBehaviour
{
    int keys = 0;
    public Sprite mode1;
    public Sprite mode2;
    public Image mode;
    public Platforming Rosa;
    static bool checkpoint;
    void Start()
    {
        if (PlayerPrefs.GetInt("Check5", 0)==1)
        {
            Rosa.transform.position = new Vector2(-160, 118);
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
        
        

        if (Rosa.transform.position.y > 112)
        {
            PlayerPrefs.SetInt("Check5", 1);
        }
    }
}