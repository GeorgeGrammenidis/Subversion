using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;


public class Stage9Manager : MonoBehaviour
{
    public Sprite mode1;
    public Sprite mode2;
    public Image mode;
    public Platforming Rosa;
    public static bool checkpoint = false;
    void Start()
    {
        
        if (PlayerPrefs.GetInt("Check4", 0)==1)
        {
            Rosa.transform.position = new Vector2(-113, 75);
        }
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
        

       

        if (Rosa.transform.position.y > 70 && Rosa.transform.position.x < -100)
        {
            PlayerPrefs.SetInt("Check4", 1);
        }
    }
}
