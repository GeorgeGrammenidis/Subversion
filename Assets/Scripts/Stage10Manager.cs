using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography;

public class Stage10Manager : MonoBehaviour
{
    int keys = 0;
    public GameObject Wall;
    public Sprite mode1;
    public Sprite mode2;
    public Image mode;
    public TextMeshProUGUI key_count;
    public Platforming Rosa;
    public static bool checkpoint = false;
    public Enemy enemy;
    void Start()
    {
        Platforming.keys = 0;
        if (PlayerPrefs.GetInt("Check9", 0)==1)
        {
            Rosa.transform.position = new Vector2(261, 16);
            enemy.transform.position = new Vector2(211, 16);
            Platforming.keys = 5;
            Wall.SetActive(false);
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
        if (keys < 5)
        {
            key_count.text = keys.ToString() + "/5 keys";
        }
        if (keys >= 5)
        {
            key_count.text = "Gate Open";
            Wall.SetActive(false);

        }

        

        

        if (Rosa.transform.position.x > 217 && Rosa.transform.position.y > -3)
        {
            PlayerPrefs.SetInt("Check9", 1);
        }
    }
}