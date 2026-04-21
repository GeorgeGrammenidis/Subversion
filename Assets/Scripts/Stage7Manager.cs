using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;

public class Stage7Manager : MonoBehaviour
{
    static int keys = 0;
    static int placeholder_keys=0;
    public GameObject End;
    public Sprite mode1;
    public Sprite mode2;
    public Image mode;
    public TextMeshProUGUI key_count;
    public Platforming Rosa;
    public Key key1;
    public Key key2;
    public Key key3;
    public Key key4;
    public static bool key1collected = false;
    public static bool key2collected = false;
    public static bool key3collected = false;
    public static bool key4collected = false;
    void Start()
    {
        End.SetActive(false);
        keys = 0;
        if ((PlayerPrefs.GetInt("Key6.1", 0) == 1))
        {
            key1.gameObject.SetActive(false);
            key1collected = true;
            keys++;
        }
        if ((PlayerPrefs.GetInt("Key6.2", 0) == 1))
        {
            key2.gameObject.SetActive(false);
            key2collected = true;
            keys++;
        }
        if ((PlayerPrefs.GetInt("Key6.3", 0) == 1))
        {
            key3.gameObject.SetActive(false);
            key3collected = true;
            keys++;
        }
        if ((PlayerPrefs.GetInt("Key6.4", 0) == 1))
        {
            key4.gameObject.SetActive(false);
            key4collected = true;
            keys++;
        }
    }

    void Update()
    {
        if (key1.isCollected && !key1collected)
        {
            PlayerPrefs.SetInt("Key6.1", 1);
            key1collected = true;
            keys++;
        }
        if (key2.isCollected && !key2collected)
        {
            PlayerPrefs.SetInt("Key6.2", 1);
            key2collected = true;
            keys++;
        }
        if (key3.isCollected && !key3collected)
        {
            PlayerPrefs.SetInt("Key6.3", 1);
            key3collected = true;
            keys++;
        }
        if (key4.isCollected && !key4collected)
        {
            PlayerPrefs.SetInt("Key6.4", 1);
            key4collected = true;
            keys++;
        }


        
        if (Rosa.swap == false)
        {
            mode.sprite = mode1;
        }
        else
        {
            mode.sprite = mode2;
        }
        if (keys < 4)
        {
            key_count.text = keys.ToString() + "/4 keys";
        }
        if (keys == 4)
        {
            key_count.text = "Return to Start";
            End.SetActive(true);

        }

        

        
    }
}
