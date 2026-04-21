using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;


public class Stage6Manager : MonoBehaviour
{
    int keys = 0;
    public GameObject wall;
    public Sprite mode1;
    public Sprite mode2;
    public Image mode;
    public TextMeshProUGUI key_count;
    public Platforming Rosa;
    public Sprite image1;
    public Sprite image2;
    public Image current_image;
    public static bool checkpoint = false;
    void Start()
    {
        key_count.text = "0/6 Keys";
        Platforming.keys = 0;
        if (PlayerPrefs.GetInt("Check10", 0)==1)
        {
            Rosa.transform.position = new Vector2(-268, 3);
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
        if (keys < 6)
        {
            key_count.text = keys.ToString() + "/6 keys";
        }
        if (keys == 6)
        {
            key_count.text = "Barier is gone";
            wall.SetActive(false);

        }

        
        

        if (Rosa.transform.position.x > -268 && Rosa.transform.position.y > 2)
        {
            PlayerPrefs.SetInt("Check10", 1);
        }
    }
}
