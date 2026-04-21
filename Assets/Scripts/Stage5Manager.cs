using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;

public class Stage5Manager : MonoBehaviour
{
    static int keys = 0;
    public GameObject wall;
    public Sprite mode1;
    public Sprite mode2;
    public Image mode;
    public Platforming player;
    public TextMeshProUGUI key_count;
    public Sprite image1;
    public Image current_image;
    public Platforming Rosa;
    public static bool checkpoint = false;
    public TextMeshProUGUI tutorial;
    public Key key1;
    public Key key2;
    public Key key3;
    public Key key4;
    public Key key5;
    public static bool key1collected = false;
    public static bool key2collected = false;
    public static bool key3collected = false;
    public static bool key4collected = false;
    public static bool key5collected = false;
    void Start()
    {
        if (PlayerPrefs.GetInt("Check7", 0) ==1)
        {
            Rosa.transform.position = new Vector2(127, 268);
        }
        

        keys = 0;
        if ((PlayerPrefs.GetInt("Key7.1", 0) == 1))
        {
            key1.gameObject.SetActive(false);
            key1collected = true;
            keys++;
        }
        if ((PlayerPrefs.GetInt("Key7.2", 0) == 1))
        {
            key2.gameObject.SetActive(false);
            key2collected = true;
            keys++;
        }
        if ((PlayerPrefs.GetInt("Key7.3", 0) == 1))
        {
            key3.gameObject.SetActive(false);
            key3collected = true;
            keys++;
        }
        if ((PlayerPrefs.GetInt("Key7.4", 0) == 1))
        {
            key4.gameObject.SetActive(false);
            key4collected = true;
            keys++;
        }
        if ((PlayerPrefs.GetInt("Key7.5", 0) == 1))
        {
            key5.gameObject.SetActive(false);
            key5collected = true;
            keys++;
        }
    }

    void Update()
    {

        if (key1.isCollected && !key1collected)
        {
            PlayerPrefs.SetInt("Key7.1", 1);
            key1collected = true;
            keys++;
        }
        if (key2.isCollected && !key2collected)
        {
            PlayerPrefs.SetInt("Key7.2", 1);
            key2collected = true;
            keys++;
        }
        if (key3.isCollected && !key3collected)
        {
            PlayerPrefs.SetInt("Key7.3", 1);
            key3collected = true;
            keys++;
        }
        if (key4.isCollected && !key4collected)
        {
            PlayerPrefs.SetInt("Key7.4", 1);
            key4collected = true;
            keys++;
        }
        if (key5.isCollected && !key5collected)
        {
            PlayerPrefs.SetInt("Key7.5", 1);
            key5collected = true;
            keys++ ;
        }

        if (player.swap == false)
        {
            mode.sprite = mode1;
        }
        else
        {
            mode.sprite = mode2;
        }
        if (keys < 5)
        {
            key_count.text = keys.ToString() + "/5 keys";
        }
        if (keys == 5)
        {
            key_count.text = "The floor is gone";
            wall.SetActive(false);
            
        }

        if (Rosa.transform.position.x < 127 && Rosa.transform.position.y > 260)
        {
            PlayerPrefs.SetInt("Check7", 1);
        }
    }
}

