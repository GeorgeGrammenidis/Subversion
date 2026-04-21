using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;

public class Stage3Manager : MonoBehaviour
{
    static int keys = 0;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public Sprite mode1;
    public Sprite mode2;
    public Image mode;
    public Platforming player;
    public TextMeshProUGUI key_count;
    public GameObject tutorialbox;
    public Platforming Rosa;
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
        keys = 0;
        if ((PlayerPrefs.GetInt("Key3.1", 0) == 1))
        {
            key1.gameObject.SetActive(false);
            key1collected = true;
            keys++;
        }
        if ((PlayerPrefs.GetInt("Key3.2", 0) == 1))
        {
            key2.gameObject.SetActive(false);
            key2collected = true;
            keys++;
        }
        if ((PlayerPrefs.GetInt("Key3.3", 0) == 1))
        {
            key3.gameObject.SetActive(false);
            key3collected   = true;
            keys++;
        }
        if ((PlayerPrefs.GetInt("Key3.4", 0) == 1))
        {
            key4.gameObject.SetActive(false);
            key4collected = true;
            keys++;
        }
        if ((PlayerPrefs.GetInt("Key3.5", 0) == 1))
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
            PlayerPrefs.SetInt("Key3.1", 1);
            key1collected = true;
            keys++;
        }
        if (key2.isCollected && !key2collected)
        {
            PlayerPrefs.SetInt("Key3.2", 1);
            key2collected = true;
            keys++;
        }
        if (key3.isCollected && !key3collected)
        {
            PlayerPrefs.SetInt("Key3.3", 1);
            key3collected = true;
            keys++;
        }
        if (key4.isCollected && !key4collected)
        {
            PlayerPrefs.SetInt("Key3.4", 1);
            key4collected = true;
            keys++;
        }
        if (key5.isCollected && !key5collected)
        {
            PlayerPrefs.SetInt("Key3.5", 1);
            key5collected = true;
            keys++;
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
            key_count.text = "Gate Open";
            wall1.SetActive(false);
            wall2.SetActive(false);
            wall3.SetActive(false);
        }


        if (Rosa.transform.position.x > -22 && Rosa.transform.position.x < -6 && Rosa.transform.position.y > 260 && Rosa.transform.position.y < 282)
        {
            tutorialbox.SetActive(true);
            tutorial.text = "Press U to switch modes. Now you can press H to hit green boosters. Hitting them allows you an extra jump in the air.";
        }
        else if (Rosa.transform.position.x > -8.5 && Rosa.transform.position.x < 2.5 && Rosa.transform.position.y > 280 && Rosa.transform.position.y < 290)
        {
            tutorialbox.SetActive(true);
            tutorial.text = "Press U to switch back to normal. Now you can use H again to string bounces. Switch between the two when appropriate.";
        }
        else if (Rosa.transform.position.x > 62 && Rosa.transform.position.x < 80 && Rosa.transform.position.y > 273 && Rosa.transform.position.y < 280)
        {
            tutorialbox.SetActive(true);
            tutorial.text = "Collect five keys to open the gate";
        }
        else if (Rosa.transform.position.x > 98 && Rosa.transform.position.x < 108 && Rosa.transform.position.y > 279 && Rosa.transform.position.y < 285) { 
            tutorialbox.SetActive(true);
            tutorial.text = "Keep hitting green boosters and jumping to stay airborne";
        }
        else
        {
            tutorialbox.SetActive(false);
        }
        
        


    }

    
}
